using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie_Theater_Booking_WebAPI.Model.Interface
{
   public interface IRoom
    {
        Task<Room> CreateRoom(Room room);
        Task<Room> GetRoom(int id);
        Task<List<Room>> GetAllRooms();
        Task<Room> UpdateRoom(Room room);
        Task Delete(int id);
    }
}
