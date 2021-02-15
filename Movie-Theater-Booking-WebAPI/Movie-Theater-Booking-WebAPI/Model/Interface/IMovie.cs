using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie_Theater_Booking_WebAPI.Model.Interface
{
    public interface IMovie
    {

        Task<Movie> CreateMovie(Movie movie);
        Task<Movie> GetMovie(int id);
        Task<Movie> UpdateMovie(Movie movie);
        Task Delete(int id);
    }
}
