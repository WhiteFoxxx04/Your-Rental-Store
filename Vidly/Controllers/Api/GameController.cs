using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class GameController : ApiController
    {
        private ApplicationDbContext _context;

        public GameController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /api/games
        public IEnumerable<GameDto> GetGames()
        {
            return _context.Games.ToList().Select(Mapper.Map<Game, GameDto>);
        }

        // GET /api/games/1
        public IHttpActionResult GetGames(int id)
        {
            var game = _context.Games.SingleOrDefault(g => g.Id == id);

            if (game == null)
                return NotFound();

            return Ok(Mapper.Map<Game, GameDto>(game));
        }

        // POST /api/games
        [HttpPost]
        public IHttpActionResult CreateGame(GameDto gameDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var game = Mapper.Map<GameDto, Game>(gameDto);
            _context.Games.Add(game);
            _context.SaveChanges();

            gameDto.Id = game.Id;
            return Created(new Uri(Request.RequestUri + "/" + game.Id), gameDto);
        }

        // PUT /api/games/1
        [HttpPut]
        public void UpdateGame(int id, GameDto gameDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var gameInDb = _context.Games.SingleOrDefault(g => g.Id == id);

            if (gameInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(gameDto, gameInDb);

            _context.SaveChanges();
        }

        // DELETE /api/games/1
        [HttpDelete]
        public void DeleteGame(int id)
        {
            var gameInDb = _context.Games.SingleOrDefault(c => c.Id == id);

            if (gameInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Games.Remove(gameInDb);
            _context.SaveChanges();
        }
    }
}
