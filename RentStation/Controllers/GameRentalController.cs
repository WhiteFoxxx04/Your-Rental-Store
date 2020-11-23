using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RentStation.Controllers
{
    public class GameRentalController : Controller
    {
        // GET: GameRental
        public ActionResult New()
        {
            return View();
        }
    }
}