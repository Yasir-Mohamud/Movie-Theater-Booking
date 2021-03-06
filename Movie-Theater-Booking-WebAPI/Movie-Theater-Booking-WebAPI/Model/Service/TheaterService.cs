﻿using Microsoft.EntityFrameworkCore;
using Movie_Theater_Booking_WebAPI.Data;
using Movie_Theater_Booking_WebAPI.Model.DTO;
using Movie_Theater_Booking_WebAPI.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie_Theater_Booking_WebAPI.Model.Service
{
    public class TheaterService : ITheater
    {
        private readonly TheaterDbContext _context;

        /// <summary>
        /// injects the db into the class
        /// </summary>
        /// <param name="context"> Database</param>
        public TheaterService(TheaterDbContext context)
        {
            _context = context;
        }
        public async Task<TheaterDTO> CreateTheater(TheaterDTO theaterdto)
        {
            Theater theater = new Theater 
            {
                Name = theaterdto.Name,
                Address = theaterdto.Address,
                City = theaterdto.City,
                State = theaterdto.State,
                BusinessHours = theaterdto.BusinessHours,
                Phone = theaterdto.Phone
            };

            _context.Entry(theater).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return theaterdto;
        }

       

        public async Task<TheaterDTO> GetTheater(int id)
        {
            Theater theater = await _context.Theaters.Where(x => x.Id == id)
                                            .Include(x => x.theaterToRooms)
                                            .ThenInclude(x => x.room)
                                            .ThenInclude(x => x.roomToMovies)
                                            .ThenInclude(x => x.movie)
                                            .FirstOrDefaultAsync();
          
            TheaterDTO theaterdto = new TheaterDTO
            {
                Name = theater.Name,
                Address = theater.Address,
                City = theater.City,
                State = theater.State,
                BusinessHours = theater.BusinessHours,
                Phone = theater.Phone,
                theaterToRooms = theater.theaterToRooms
            };



            return theaterdto;
        }
        public async Task<List<TheaterDTO>> GetAllTheaters()
        {
            var theaters = await _context.Theaters.ToListAsync();
            var theaterdto = new List<TheaterDTO>();
            foreach(var theater in theaters)
            {
                theaterdto.Add(await GetTheater(theater.Id));
            }
            return theaterdto;
        }
        public async Task<TheaterDTO> UpdateTheater(TheaterDTO theaterdto)
        {
            Theater theater = new Theater
            {
                Name = theaterdto.Name,
                Address = theaterdto.Address,
                City = theaterdto.City,
                State = theaterdto.State,
                BusinessHours = theaterdto.BusinessHours,
                Phone = theaterdto.Phone
            };

            _context.Entry(theater).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return theaterdto;
        }

        public async Task Delete(int id)
        {
            Theater theater = await _context.Theaters.FindAsync(id);
            _context.Entry(theater).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }
    }
}
