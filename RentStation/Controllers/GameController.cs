﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using RentStation.Models;
using RentStation.ViewModels;

namespace RentStation.Controllers
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

        public ViewResult Index()
        {
            if (User.IsInRole(RoleName.CanManageMoviesAndGames))
                return View("List");

            return View("ReadOnlyList");
        }

        [Authorize(Roles = RoleName.CanManageMoviesAndGames)]
        public ViewResult New()
        {
            var categories = _context.Categories.ToList();

            var viewModel = new GameFormViewModel()
            {
                Categories = categories
            };

            return View("GameForm", viewModel);
        }

        [Authorize(Roles = RoleName.CanManageMoviesAndGames)]
        public ActionResult Edit(int id)
        {
            var game = _context.Games.SingleOrDefault(g => g.Id == id);

            if (game == null)
                return HttpNotFound();

            var viewModel = new GameFormViewModel(game)
            {
                Categories = _context.Categories.ToList()
            };

            return View("GameForm", viewModel);
        }


        public ActionResult Details(int id)
        {
            var game = _context.Games.Include(m => m.Category).SingleOrDefault(m => m.Id == id);

            if (game == null)
                return HttpNotFound();

            return View(game);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.CanManageMoviesAndGames)]
        public ActionResult Save(Game game)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new GameFormViewModel(game)
                {
                    Categories = _context.Categories.ToList()
                };

                return View("GameForm", viewModel);
            }

            if (game.Id == 0)
            {
                _context.Games.Add(game);
            }
            else
            {
                var gameInDb = _context.Games.Single(c => c.Id == game.Id);
                gameInDb.Name = game.Name;
                gameInDb.Category = game.Category;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Game");
        }
    }
}