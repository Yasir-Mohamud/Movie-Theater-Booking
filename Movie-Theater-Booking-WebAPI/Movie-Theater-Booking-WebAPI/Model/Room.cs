using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie_Theater_Booking_WebAPI.Model
{
    public class Room
    {
        public int Id { get; set; }
        public int Seats { get; set; }
        public int RoomNumber { get; set; }
        public int Floor { get; set; }

        // Navigation Properties
        public List<TheaterToRoom> theaterToRooms { get; set; }
        public RoomToMovie roomToMovies { get; set; }
    }
}
