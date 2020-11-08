using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using System.Data.Entity;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class GameController : Controller
    {
        private ApplicationDbContext _context;

        public GameController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult New()
        {
            var categories = _context.Categories.ToList();
            var viewModel = new GameFormViewModel()
            {
                Categories = categories
            };

            return View("GameForm", viewModel);
        }

        [HttpPost]
        public ActionResult Save(Game game)
        {
            if (game.Id == 0)
                _context.Games.Add(game);
            else
            {
                var gameInDb = _context.Games.Single(c => c.Id == game.Id);
                gameInDb.Name = game.Name;
                gameInDb.Category = game.Category;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Game");
        }

        public ViewResult Index()
        {
            var games = _context.Games.Include(c => c.Category).ToList();

            return View(games);
        }

        public ActionResult Details(int id)
        {
            var games = _context.Games.Include(c => c.Category).SingleOrDefault(c => c.Id == id);

            if (games == null)
                return HttpNotFound();

            return View(games);
        }

        public ActionResult Edit(int id)
        {
            var games = _context.Games.SingleOrDefault(c => c.Id == id);

            if (games == null)
                return HttpNotFound();

            var viewModel = new GameFormViewModel()
            {
                Games = games,
                Categories = _context.Categories.ToList()
            };

            return View("GameForm", viewModel);
        }

        //public ViewResult Index()
        //{
        //    var games = GetGame();

        //    return View(games);
        //}

        //public ActionResult Details(int id)
        //{
        //    var games = GetGame().SingleOrDefault(g => g.Id == id);

        //    if (games == null)
        //        return HttpNotFound();

        //    return View(games);
        //}

        //private IEnumerable<Game> GetGame()
        //{
        //    return new List<Game>
        //    {
        //        new Game { Id = 1, Name = "Player Unknown Battle Ground" },
        //        new Game { Id = 2, Name = "Call Of Duty" }
        //    };
        //}
    }
}