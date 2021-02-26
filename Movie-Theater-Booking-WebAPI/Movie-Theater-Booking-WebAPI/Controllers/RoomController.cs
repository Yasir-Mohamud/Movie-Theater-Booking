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
    public class RoomController : ControllerBase
    {
        private readonly IRoom _room;

        public RoomController(IRoom room)
        {
            _room = room;
        }
        // GET: api/<RoomController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoomDTO>>> GetAll()
        {
            return await _room.GetAllRooms();
        }

        // GET api/<RoomController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RoomDTO>> Get(int id)
        {
           RoomDTO roomdto = await _room.GetRoom(id);
            return roomdto;
        }

        // POST api/<RoomController>
        [HttpPost]
        public async Task<ActionResult<RoomDTO>> Post(RoomDTO roomdto)
        {
            await _room.CreateRoom(roomdto);
            return CreatedAtAction("GetRoom", new { id = roomdto.Id }, roomdto);
        }

        // PUT api/<RoomController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, RoomDTO roomdto)
        {
            if (id != roomdto.Id)
            {
                return BadRequest();
            }

            var updatedRoom = await _room.UpdateRoom(roomdto);

            return Ok(updatedRoom);
        }

        // DELETE api/<RoomController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Room>> Delete(int id)
        {
            await _room.Delete(id);
            return NoContent();
        }
        //Post 
        [HttpPost]
        [Route("{roomId}/{movieId}")]
        public async Task<IActionResult> AddRoomToMovie(int roomId, int movieId)
        {
            await _room.AddRoomToMovie(roomId, movieId);
            return Ok();
        }

        [HttpDelete]
        [Route("{roomId}/{movieId}")]
        public async Task<IActionResult> RemoveRoomToMovie(int roomId, int movieId)
        {
            await _room.RemoveRoomToMovie(roomId, movieId);
            return Ok();
        }
    }
}
