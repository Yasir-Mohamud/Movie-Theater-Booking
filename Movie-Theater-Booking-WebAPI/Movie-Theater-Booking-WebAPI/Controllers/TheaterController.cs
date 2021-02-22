using Microsoft.AspNetCore.Mvc;
using Movie_Theater_Booking_WebAPI.Model;
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
    public class TheaterController : ControllerBase
    {
        private readonly ITheater _theater;

        public TheaterController(ITheater theater)
        {
            _theater = theater;
        }
        // GET: api/<TheaterController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Theater>>> GetAll()
        {
            return await _theater.GetAllTheaters();
        }

        // GET api/<TheaterController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Theater>> Get(int id)
        {
            return await _theater.GetTheater(id);
        }

        // POST api/<TheaterController>
        [HttpPost]
        public async Task<ActionResult<Theater>> Post(Theater theater)
        {
            await _theater.CreateTheater(theater);
            return CreatedAtAction("GetTheater", new { id = theater.Id }, theater);
        }

        // PUT api/<TheaterController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Theater theater)
        {
            if (id != theater.Id)
            {
                return BadRequest();
            }

            var updatedTheater = await _theater.UpdateTheater(theater);

            return Ok(updatedTheater);
        }

        // DELETE api/<TheaterController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Theater>> Delete(int id)
        {
            await _theater.Delete(id);
            return NoContent();
        }
    }
}
