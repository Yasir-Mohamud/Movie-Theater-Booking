using Microsoft.EntityFrameworkCore.Migrations;

namespace Movie_Theater_Booking_WebAPI.Migrations
{
    public partial class commit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RoomToMovies",
                columns: table => new
                {
                    RoomId = table.Column<int>(type: "int", nullable: false),
                    MovieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomToMovies", x => new { x.RoomId, x.MovieId });
                    table.ForeignKey(
                        name: "FK_RoomToMovies_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoomToMovies_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TheaterToRooms",
                columns: table => new
                {
                    TheaterId = table.Column<int>(type: "int", nullable: false),
                    RoomId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TheaterToRooms", x => new { x.RoomId, x.TheaterId });
                    table.ForeignKey(
                        name: "FK_TheaterToRooms_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TheaterToRooms_Theaters_TheaterId",
                        column: x => x.TheaterId,
                        principalTable: "Theaters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RoomToMovies_MovieId",
                table: "RoomToMovies",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_TheaterToRooms_TheaterId",
                table: "TheaterToRooms",
                column: "TheaterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoomToMovies");

            migrationBuilder.DropTable(
                name: "TheaterToRooms");
        }
    }
}
