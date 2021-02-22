using Microsoft.EntityFrameworkCore;
using Movie_Theater_Booking_WebAPI.Data;
using Movie_Theater_Booking_WebAPI.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie_Theater_Booking_WebAPI.Model.Service
{
    public class TheaterService : ITheater
    {
        private readonly TheaterDbContext _context;

        /// <summary>
        /// injects the db into the class
        /// </summary>
        /// <param name="context"> Database</param>
        public TheaterService(TheaterDbContext context)
        {
            _context = context;
        }
        public async Task<Theater> CreateTheater(Theater theater)
        {
            _context.Entry(theater).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return theater;
        }

       

        public async Task<Theater> GetTheater(int id)
        {
            Theater theater = await _context.Theaters.Where(x => x.Id == id)
                                         .FirstOrDefaultAsync();
            return theater;
        }
        public async Task<List<Theater>> GetAllTheaters()
        {
            var theater = await _context.Theaters.ToListAsync();
            return theater;
        }
        public async Task<Theater> UpdateTheater(Theater theater)
        {
            _context.Entry(theater).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return theater;
        }

        public async Task Delete(int id)
        {
            Theater theater = await _context.Theaters.FindAsync(id);
            _context.Entry(theater).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }
    }
}
