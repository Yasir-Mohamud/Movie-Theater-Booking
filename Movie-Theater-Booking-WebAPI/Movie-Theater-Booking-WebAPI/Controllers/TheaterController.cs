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
    public class TheaterController : ControllerBase
    {
        private readonly ITheater _theater;

        public TheaterController(ITheater theater)
        {
            _theater = theater;
        }
        // GET: api/<TheaterController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TheaterDTO>>> GetAll()
        {
            return await _theater.GetAllTheaters();
        }

        // GET api/<TheaterController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TheaterDTO>> Get(int id)
        {
            return await _theater.GetTheater(id);
        }

        // POST api/<TheaterController>
        [HttpPost]
        public async Task<ActionResult<TheaterDTO>> Post(TheaterDTO theaterdto)
        {
            await _theater.CreateTheater(theaterdto);
            return CreatedAtAction("GetTheater", new { id = theaterdto.Id }, theaterdto);
        }

        // PUT api/<TheaterController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, TheaterDTO theaterdto)
        {
            if (id != theaterdto.Id)
            {
                return BadRequest();
            }

            var updatedTheater = await _theater.UpdateTheater(theaterdto);

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
