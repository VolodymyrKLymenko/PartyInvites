using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PartySite.Models;

namespace PartySite.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            int hour = DateTime.Now.Hour;

            ViewBag.Greeting = hour < 12 ? "Good morning" : "Good afternoon";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpGet]
        public ActionResult RsvpForm()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RsvpForm(GuestResponse guestResponse)
        {
            if (ModelState.IsValid)
            {
                using (ResponseContext db = new ResponseContext())
                {
                    db.Responses.Add(guestResponse);
                    db.SaveChanges();
                }
                return View("Thanks", guestResponse);
            }
            else
                return View();
        }
    }
}