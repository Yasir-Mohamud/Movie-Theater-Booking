
using Microsoft.EntityFrameworkCore;
using Movie_Theater_Booking_WebAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie_Theater_Booking_WebAPI.Data
{
    public class TheaterDbContext : DbContext
    {
        public TheaterDbContext(DbContextOptions<TheaterDbContext> options) : base(options)
        {

        }
         protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Movie>().HasData(
                new Movie
                {
                    Id = 1,
                    Name = "One Piece Stampede",
                    Description = " Luffy finds the out about an old crew mate of the Pirate King Gol D. Roger, and has the eternal compass to the ancient land " +
                    "Raftel, He has to over come this great foe in order to be closer to the greatest treasure , ONE PIECE",
                    Duration = "1hr and 30 mins",
                    Rating = "5 stars",


                }
                );

            modelBuilder.Entity<Theater>().HasData(
             new Theater
             {
                 Id = 1,
                 Name = "The Colosseum",
                 Address = " 123 sw ",
                 City = "Seattle",
                 State = "WA",
                 Phone = "123456789",
                 BusinessHours = " 9AM - 12AM",
             }
             );

            modelBuilder.Entity<Room>().HasData(
                new Room
                {
                    Id = 1,
                    Seats = 50,
                    RoomNumber = 12,
                    Floor = 2,
                }
                );
         }


        // to create an intial migration
        // add-migration intial
        // Install-Package Microsoft.EntityFrameworkCore.Tools
        // add-migration {migrationName}
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Theater> Theaters { get; set; }
        public DbSet<Room> Rooms { get; set; }
    }
}           
