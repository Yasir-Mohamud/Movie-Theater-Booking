using Microsoft.EntityFrameworkCore;
using Movie_Theater_Booking_WebAPI.Data;
using Movie_Theater_Booking_WebAPI.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie_Theater_Booking_WebAPI.Model.Service
{
    public class RoomService : IRoom
    {

        private TheaterDbContext _context;

        /// <summary>
        /// injects the db into the class
        /// </summary>
        /// <param name="context"> Database</param>
        public RoomService(TheaterDbContext context)
        {
            _context = context;
        }

        public async Task<Room> CreateRoom(Room room)
        {
            _context.Entry(room).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return room;
        }


        public async Task<Room> GetRoom(int id)
        {
            Room room = await _context.Rooms.Where(x => x.Id == id)
                                          .FirstOrDefaultAsync();
            return room;
        }

        public async Task<List<Room>> GetAllRooms()
        {
            var room = await _context.Rooms.ToListAsync();
            return room;
        }

        public async Task<Room> UpdateRoom(Room room)
        {
            _context.Entry(room).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return room;
        }

        public async Task Delete(int id)
        {
            Movie movie = await _context.Movies.FindAsync(id);
            _context.Entry(movie).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }
    }
}
