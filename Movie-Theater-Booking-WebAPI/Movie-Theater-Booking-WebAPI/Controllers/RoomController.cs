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
    public class RoomController : ControllerBase
    {
        private readonly IRoom _room;

        public RoomController(IRoom room)
        {
            _room = room;
        }
        // GET: api/<RoomController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Room>>> GetAll()
        {
            return await _room.GetAllRooms();
        }

        // GET api/<RoomController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Room>> Get(int id)
        {
            return await _room.GetRoom(id);
        }

        // POST api/<RoomController>
        [HttpPost]
        public async Task<ActionResult<Room>> Post(Room room)
        {
            await _room.CreateRoom(room);
            return CreatedAtAction("GetRoom", new { id = room.Id }, room);
        }

        // PUT api/<RoomController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Room room)
        {
            if (id != room.Id)
            {
                return BadRequest();
            }

            var updatedRoom = await _room.UpdateRoom(room);

            return Ok(updatedRoom);
        }

        // DELETE api/<RoomController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Room>> Delete(int id)
        {
            await _room.Delete(id);
            return NoContent();
        }
    }
}
