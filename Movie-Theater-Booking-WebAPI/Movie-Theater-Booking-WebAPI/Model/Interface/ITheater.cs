using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie_Theater_Booking_WebAPI.Model.Interface
{
    public interface ITheater
    {
        Task<Theater> CreateTheater(Theater theater);
        Task<Theater> GetTheater(int id);
        Task<List<Theater>> GetAllTheaters();
        Task<Theater> UpdateTheater(Theater theater);
        Task Delete(int id);
    }
}
