using Microsoft.EntityFrameworkCore;
using Movie_Theater_Booking_WebAPI.Data;
using Movie_Theater_Booking_WebAPI.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie_Theater_Booking_WebAPI.Model.Service
{
    public class MovieService : IMovie
    {
        private TheaterDbContext _context;

        /// <summary>
        /// injects the db into the class
        /// </summary>
        /// <param name="context"> Database</param>
        public MovieService(TheaterDbContext context)
        {
            _context = context;
        }

        public async Task<Movie> CreateMovie (Movie movie)
        {
            _context.Entry(movie).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return movie;
        }

        public async Task<Movie> GetMovie(int id)
        {
            Movie movie = await _context.Movies.Where(x => x.Id == id)
                                          .FirstOrDefaultAsync();
            return movie;
        }

        public async Task<Movie> UpdateMovie (Movie movie)
        {
            _context.Entry(movie).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return movie;
        }

        public async Task Delete(int id)
        {
            Movie movie = await _context.Movies.FindAsync(id);
            _context.Entry(movie).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }
    }
}
