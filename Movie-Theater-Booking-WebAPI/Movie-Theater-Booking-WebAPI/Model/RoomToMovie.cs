using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie_Theater_Booking_WebAPI.Model
{
    public class RoomToMovie
    {
        public int RoomId { get; set; }
        public int MovieId { get; set; }

        // Navigation Properties
        public Room room { get; set; }
        public Movie movie { get; set; }
    }
}
