using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RentStation.Dtos;
using RentStation.Models;

namespace RentStation.Controllers.Api
{
    public class GameRentalsController : ApiController
    {
        private ApplicationDbContext _context;

        public GameRentalsController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult CreateNewGameRentals(GameRentalsDto newRentals)
        {
            var customer = _context.Customers.Single
                (c => c.Id == newRentals.customerId);

            var games = _context.Games.Where
                (m => newRentals.gameIds.Contains(m.Id));

            foreach (var game in games)
            {
                //if (movie.NumberAvailable == 0)
                //    return BadRequest("Movie is not available");
                //movie.NumberAvailable--;

                var rental = new GameRental()
                {
                    Customer = customer,
                    Game = game,
                    DateRented = DateTime.Now
                };

                _context.GameRentals.Add(rental);
            }

            _context.SaveChanges();
            return Ok();
        }
    }
}
