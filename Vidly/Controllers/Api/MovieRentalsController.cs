﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
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

        [HttpPost]
        public  IHttpActionResult CreateNewMovieRentals(MovieRentalsDto newRentals)
        {
            var customer = _context.Customers.Single
                (c => c.Id == newRentals.CustomerId);

            var movies = _context.Movies.Where
                (m => newRentals.MovieIds.Contains(m.Id)).ToList();

            foreach (var movie in movies)
            {
                if (movie.NumberAvailable == 0)
                    return BadRequest("Movie is not available");
                movie.NumberAvailable--;

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
