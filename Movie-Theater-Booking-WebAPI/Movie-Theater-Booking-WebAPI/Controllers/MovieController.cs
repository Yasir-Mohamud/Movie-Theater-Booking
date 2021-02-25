using Microsoft.AspNetCore.Mvc;
using Movie_Theater_Booking_WebAPI.Model;
using Movie_Theater_Booking_WebAPI.Model.DTO;
using Movie_Theater_Booking_WebAPI.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Movie_Theater_Booking_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    
    public class MovieController : ControllerBase
    {
        private readonly IMovie _movie;

        // our constructor is bringing in a reference to our db through the interface
        public MovieController(IMovie movie)
        {
            _movie = movie;
        }

        // GET: api/<MovieController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieDTO>>> GetAll()
        {
            return await _movie.GetAllMovies();
        }

        // GET api/<MovieController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MovieDTO>> Get(int id)
        {
            return await _movie.GetMovie(id);
        }

        // POST api/<MovieController>
        [HttpPost]
        public async Task<ActionResult<MovieDTO>> Post(MovieDTO moviedto)
        {
            await _movie.CreateMovie(moviedto);
            return CreatedAtAction("GetMovie", new { id = moviedto.Id }, moviedto);
        }

        // PUT api/<MovieController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put (int id, MovieDTO moviedto)
        {
            if (id != moviedto.Id)
            {
                return BadRequest();
            }

            var updatedMovie = await _movie.UpdateMovie(moviedto);

            return Ok(updatedMovie);
        }

        // DELETE api/<MovieController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Movie>> Delete(int id)
        {
            await _movie.Delete(id);
            return NoContent();
        }
    }
}
