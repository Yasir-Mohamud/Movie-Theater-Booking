using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie_Theater_Booking_WebAPI.Model
{
    public class TheaterToRoom
    {
        public int TheaterId { get; set; }
        public int RoomId { get; set; }

        // Navigation Properties
        public Theater theater { get; set; }
        public Room room { get; set; }
    }
}
