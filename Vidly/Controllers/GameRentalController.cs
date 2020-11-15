using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Vidly.Controllers
{
    public class GameRentalController : Controller
    {
        public ActionResult RentGames()
        {
            return View();
        }
    }
}