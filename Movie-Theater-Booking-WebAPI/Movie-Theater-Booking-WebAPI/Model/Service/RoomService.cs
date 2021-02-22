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

        public Task<Room> CreateMovie(Room room)
        {
            _context.Entry(room).State = EntityState.Added;
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Room> GetMovie(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Room> UpdateMovie(Room room)
        {
            throw new NotImplementedException();
        }
    }
}
