using Microsoft.EntityFrameworkCore;
using Movie_Theater_Booking_WebAPI.Data;
using Movie_Theater_Booking_WebAPI.Model.DTO;
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

        public async Task<MovieDTO> CreateMovie (MovieDTO moviedto)
        {
            Movie movie = new Movie
            {
                Name = moviedto.Name,
                Description = moviedto.Description,
                Duration = moviedto.Duration,
                Rating = moviedto.Rating
            };

            _context.Entry(movie).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return moviedto;
        }

        public async Task<MovieDTO> GetMovie(int id)
        {
            
            Movie movie = await _context.Movies.Where(x => x.Id == id)
                                          .FirstOrDefaultAsync();

            MovieDTO moviedto = new MovieDTO
            {
                Name = movie.Name,
                Description = movie.Description,
                Duration = movie.Duration,
                Rating = movie.Rating
            };
            return moviedto;
        }

        public async Task<List<MovieDTO>> GetAllMovies()
        {
            var movies = await _context.Movies.ToListAsync();
            var moviedto = new List<MovieDTO>();

            foreach(var movie in movies)
            {
                moviedto.Add(await GetMovie(movie.Id));
            }
            return moviedto;
        }

        public async Task<MovieDTO> UpdateMovie (MovieDTO moviedto)
        {
            Movie movie = new Movie 
            {
                Name = moviedto.Name,
                Description = moviedto.Description,
                Duration = moviedto.Duration,
                Rating = moviedto.Rating
            };

            _context.Entry(movie).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return moviedto;
        }

        public async Task Delete(int id)
        {
            Movie movie = await _context.Movies.FindAsync(id);
            _context.Entry(movie).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }
    }
}
