using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebPhim.Controllers
{
    public class RentalsController : Controller
    {
        [AllowAnonymous]
        // GET: Rentals
        public ActionResult New()
        {
            return View();
        }
    }
}