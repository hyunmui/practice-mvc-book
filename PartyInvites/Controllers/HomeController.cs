using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PartyInvites.Models;

namespace PartyInvites.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            int hour = DateTime.Now.Hour;
            ViewBag.Greeting = hour < 12 ? "Good morning" : "Good afternoon";

            return View();
        }

        //
        // GET: /Home/RsvpForm
        [HttpGet]
        public ViewResult RsvpForm()
        {
            return View();
        }

        //
        // POST : /Home/RsvpForm
        [HttpPost]
        public ViewResult RsvpForm(GuestResponse guestResponse)
        {
            // TODO: 파티 주쵲에게 guestResponse를 전자우편으로 발송한다.
            return View("Thanks", guestResponse);
        }
    }
}
