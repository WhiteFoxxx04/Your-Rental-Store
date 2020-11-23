using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RentStation.Controllers
{
    public class MovieRentalController : Controller
    {
        // GET: MovieRental
        public ActionResult New()
        {
            return View();
        }
    }
}