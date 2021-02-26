using Movie_Theater_Booking_WebAPI.Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie_Theater_Booking_WebAPI.Model.Interface
{
    public interface IMovie
    {

        Task<MovieDTO> CreateMovie(MovieDTO moviedto);
        Task<MovieDTO> GetMovie(int id);
        Task<List<MovieDTO>> GetAllMovies();
        Task<MovieDTO> UpdateMovie(MovieDTO moviedto);
        Task Delete(int id);
    }
}
