using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie_Theater_Booking_WebAPI.Model.Interface
{
   public interface IRoom
    {
        Task<Room> CreateMovie(Room room);
        Task<Room> GetMovie(int id);
        Task<Room> UpdateMovie(Room room);
        Task Delete(int id);
    }
}
