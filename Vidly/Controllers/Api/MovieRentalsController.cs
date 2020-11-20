using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class MovieRentalsController : ApiController
    {

        private ApplicationDbContext _context;

        public MovieRentalsController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /api/rentals
        public IEnumerable<MovieRentalsDto> GetMovieRentals()
        {
            return _context.MovieRentals
                .ToList()
                .Select(Mapper.Map<MovieRental, MovieRentalsDto>);
        }

        // GET /api/rentals/1
        public IHttpActionResult GetMovieRental(int id)
        {
            var rentals = _context.MovieRentals.SingleOrDefault(g => g.Id == id);

            if (rentals == null)
                return NotFound();

            return Ok(Mapper.Map<MovieRental, MovieRentalsDto>(rentals));
        }

        [HttpPost]
        public  IHttpActionResult CreateNewMovieRentals(MovieRentalsDto newRentals)
        {
            var customer = _context.Customers.Single
                (c => c.Id == newRentals.customerId);

            var movies = _context.Movies.Where
                (m => newRentals.movieIds.Contains(m.Id));

            foreach (var movie in movies)
            {
                //if (movie.NumberAvailable == 0)
                //    return BadRequest("Movie is not available");
                //movie.NumberAvailable--;

                var rental = new MovieRental
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Now
                };

                _context.MovieRentals.Add(rental);
            }

            _context.SaveChanges();
            return Ok();
        }
    }
}
