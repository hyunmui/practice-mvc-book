using CsharpExample.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace CsharpExample.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public string Index()
        {
            return "Navigate to URL to show an example";
        }

        public ViewResult AutoProperty()
        {
            Product myProduct = new Product();

            myProduct.Name = "Kayak";

            string productName = myProduct.Name;

            return View("Result", (object)String.Format("Product name: {0}", productName));
        }

        public ViewResult UseExtension()
        {
            // Init Instance
            ShoppingCart cart = new ShoppingCart
            {
                Products = new System.Collections.Generic.List<Product>
                {
                    new Product { Name="Kayak", Price = 275M },
                    new Product { Name="Lifejacket", Price = 48.95M },
                    new Product { Name="Soccer ball", Price = 19.5M },
                    new Product { Name="Corner flag", Price = 34.95M },
                }
            };

            // Calculate Sum
            decimal cartTotal = cart.TotalPrices();

            return View("Result", (object)string.Format("Total : {0:c}", cartTotal));
        }

        public ViewResult UseExtensionEnumerable()
        {
            // Init Instance
            IEnumerable<Product> products = new ShoppingCart
            {
                Products = new List<Product>
                {
                    new Product { Name="Kayak", Price = 275M },
                    new Product { Name="Lifejacket", Price = 48.95M },
                    new Product { Name="Soccer ball", Price = 19.5M },
                    new Product { Name="Corner flag", Price = 34.95M },
                }
            };

            Product[] productArray = {
                    new Product { Name="Kayak", Price = 275M },
                    new Product { Name="Lifejacket", Price = 48.95M },
                    new Product { Name="Soccer ball", Price = 19.5M },
                    new Product { Name="Corner flag", Price = 34.95M },
                };

            // Calculate Sum
            decimal cartTotal = products.TotalPrices();
            decimal arrayTotal = productArray.TotalPrices();

            return View("Result", (object)string.Format("Total : {0:c}, Array Total : {1:c}", cartTotal, arrayTotal));
        }

        public ViewResult UseFilterExtensionMethod()
        {
            IEnumerable<Product> products = new ShoppingCart
            {
                Products = new List<Product>
                {
                    new Product { Name="Kayak", Category = "Watersports", Price = 275M },
                    new Product { Name="Lifejacket", Category = "Watersports", Price = 48.95M },
                    new Product { Name="Soccer ball", Category = "Soccer", Price = 19.5M },
                    new Product { Name="Corner flag", Category = "Soccer", Price = 34.95M },
                }
            };

            decimal total = 0;
            foreach (Product prod in products.FilterByCategory("Soccer"))
            {
                total += prod.Price;
            }

            return View("Result", (object)string.Format("Total : {0:c}", total));
        }
    }
}