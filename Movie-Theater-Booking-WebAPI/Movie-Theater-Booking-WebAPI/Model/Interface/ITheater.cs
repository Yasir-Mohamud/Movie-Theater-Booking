using Movie_Theater_Booking_WebAPI.Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie_Theater_Booking_WebAPI.Model.Interface
{
    public interface ITheater
    {
        Task<TheaterDTO> CreateTheater(TheaterDTO theaterdto);
        Task<TheaterDTO> GetTheater(int id);
        Task<List<TheaterDTO>> GetAllTheaters();
        Task<TheaterDTO> UpdateTheater(TheaterDTO theaterdto);
        Task Delete(int id);
    }
}
