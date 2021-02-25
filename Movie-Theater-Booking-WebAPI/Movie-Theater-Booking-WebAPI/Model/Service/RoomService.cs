using Microsoft.EntityFrameworkCore;
using Movie_Theater_Booking_WebAPI.Data;
using Movie_Theater_Booking_WebAPI.Model.DTO;
using Movie_Theater_Booking_WebAPI.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie_Theater_Booking_WebAPI.Model.Service
{
    public class RoomService : IRoom
    {

        private TheaterDbContext _context;
        private readonly IMovie _movie;

        /// <summary>
        /// injects the db into the class
        /// </summary>
        /// <param name="context"> Database</param>
        public RoomService(TheaterDbContext context , IMovie movie)
        {
            _context = context;
            _movie = movie;
        }

        public async Task<RoomDTO> CreateRoom(RoomDTO roomdto)
        {
            Room room = new Room
            {
                RoomNumber = roomdto.RoomNumber,
                Floor = roomdto.Floor,
                Seats = roomdto.Seats,
            };
            _context.Entry(room).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return roomdto;
        }


        public async Task<RoomDTO> GetRoom(int id)
        {
            Room room = await _context.Rooms.FindAsync(id);
            // add all movies in the room
            var roomMovies = await _context.RoomToMovies.Where(x => x.RoomId == id)
                                                        .Include(x => x.movie)
                                                        .FirstOrDefaultAsync();
            MovieDTO movieDto = await _movie.GetMovie(roomMovies.MovieId);
            RoomDTO roomdto = new RoomDTO
            {

                RoomNumber = room.RoomNumber,
                Floor = room.Floor,
                Seats = room.Seats,
                moviedto = movieDto,
            };
        

            return roomdto;
        }

        public async Task<List<RoomDTO>> GetAllRooms()
        {
            var rooms = await _context.Rooms.ToListAsync();
            var roomdto = new List<RoomDTO>();
            foreach(var room in rooms)
            {
                roomdto.Add(await GetRoom(room.Id));
            }
            return roomdto;
        }

        public async Task<RoomDTO> UpdateRoom(RoomDTO roomdto)
        {
            Room room = new Room
            {
               
                RoomNumber = roomdto.RoomNumber,
                Floor = roomdto.Floor,
                Seats = roomdto.Seats,
            };
            _context.Entry(room).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return roomdto;
        }

        public async Task Delete(int id)
        {
            Room room = await _context.Rooms.FindAsync(id);
            _context.Entry(room).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task AddRoomToMovie (int roomId, int movieId)
        {
            RoomToMovie roomToMovie = new RoomToMovie
            {
                RoomId = roomId,
                MovieId = movieId,
            };
            _context.Entry(roomToMovie).State = EntityState.Added;
            await _context.SaveChangesAsync();
        }

        public async Task RemoveRoomToMovie (int roomId, int movieId)
        {
            var roomToMovie =  _context.RoomToMovies.Where(x => x.RoomId == roomId && x.MovieId == movieId);
            _context.Entry(roomToMovie).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }
    }
}
