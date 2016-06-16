using EssentialTools.Models;
using System.Web.Mvc;
using Ninject;

namespace EssentialTools.Controllers
{
    public class HomeController : Controller
    {
        private Product[] products =  
                {
                    new Product { Name="Kayak", Category = "Watersports", Price = 275M },
                    new Product { Name="Lifejacket", Category = "Watersports", Price = 48.95M },
                    new Product { Name="Soccer ball", Category = "Soccer", Price = 19.5M },
                    new Product { Name="Corner flag", Category = "Soccer", Price = 34.95M },
                };

        // GET: Home
        public ActionResult Index()
        {
            IKernel ninjectKernel = new StandardKernel();
            ninjectKernel.Bind<IValueCalculator>().To<LinqValueCalculator>();       // 이부분이 의존성이 남아있음

            // 의존성 남아있음
            //IValueCalculator calc = new LinqValueCalculator();

            // NInject를 통해 의존성 제거
            IValueCalculator calc = ninjectKernel.Get<IValueCalculator>();

            ShoppingCart cart = new ShoppingCart(calc) { Products = products };

            decimal totalValue = cart.CalculateProductTotal();

            return View(totalValue);
        }
    }
}