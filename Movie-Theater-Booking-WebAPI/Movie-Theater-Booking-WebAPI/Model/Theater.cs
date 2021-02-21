using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie_Theater_Booking_WebAPI.Model
{
    public class Theater
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Phone { get; set; }
        public string BusinessHours { get; set; }

        // Navigation Properties
        public List<TheaterToRoom> theaterToRooms { get; set; }
    }
}
