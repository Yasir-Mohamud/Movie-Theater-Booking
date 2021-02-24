using Movie_Theater_Booking_WebAPI.Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie_Theater_Booking_WebAPI.Model.Interface
{
   public interface IRoom
    {
        Task<RoomDTO> CreateRoom(RoomDTO roomdto);
        Task<RoomDTO> GetRoom(int id);
        Task<List<RoomDTO>> GetAllRooms();
        Task<RoomDTO> UpdateRoom(RoomDTO roomdto);
        Task Delete(int id);
    }
}
