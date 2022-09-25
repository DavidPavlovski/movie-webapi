using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieApp.DataAccess.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FavouriteGenre = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movie",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PosterUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Genre = table.Column<int>(type: "int", nullable: false),
                    Posted = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movie", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Movie_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Review",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    Review = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    Posted = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Review", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Review_Movie_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Review_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Email", "FavouriteGenre", "FirstName", "LastName", "Password", "Username" },
                values: new object[,]
                {
                    { 1, "david.pavlovski@hotmail.com", 1, "David", "Pavlovski", "H,?????mI??I8", "dPavlovski" },
                    { 2, "marko.pavlovski@hotmail.com", 2, "Marko", "Pavlovski", "H,?????mI??I8", "mPavlovski" },
                    { 3, "rade.pavlovski@hotmail.com", 3, "Rade", "Pavlovski", "H,?????mI??I8", "rPavlovski" },
                    { 4, "bob.bobsky@hotmail.com", 4, "Bob", "Bobsky", "H,?????mI??I8", "bBobsky" }
                });

            migrationBuilder.InsertData(
                table: "Movie",
                columns: new[] { "Id", "Description", "Genre", "Posted", "PosterUrl", "Title", "UserId", "Year" },
                values: new object[,]
                {
                    { 1, "description goes here", 1, new DateTime(2022, 9, 12, 22, 53, 47, 400, DateTimeKind.Local).AddTicks(2061), "some image url", "Star wars episode 4", 1, 1987 },
                    { 2, "description goes here", 1, new DateTime(2022, 9, 12, 22, 53, 47, 400, DateTimeKind.Local).AddTicks(2099), "some image url", "Star wars episode 5", 1, 1987 },
                    { 3, "description goes here", 1, new DateTime(2022, 9, 12, 22, 53, 47, 400, DateTimeKind.Local).AddTicks(2102), "some image url", "Star wars episode 6", 1, 1987 },
                    { 4, "description goes here", 1, new DateTime(2022, 9, 12, 22, 53, 47, 400, DateTimeKind.Local).AddTicks(2104), "some image url", "Star wars episode 7", 1, 1987 },
                    { 5, "description goes here", 1, new DateTime(2022, 9, 12, 22, 53, 47, 400, DateTimeKind.Local).AddTicks(2107), "some image url", "Harry Potter 1", 2, 1987 },
                    { 6, "description goes here", 1, new DateTime(2022, 9, 12, 22, 53, 47, 400, DateTimeKind.Local).AddTicks(2110), "some image url", "Harry Potter 2", 2, 1987 },
                    { 7, "description goes here", 1, new DateTime(2022, 9, 12, 22, 53, 47, 400, DateTimeKind.Local).AddTicks(2113), "some image url", "Harry Potter 3", 2, 1987 },
                    { 8, "description goes here", 1, new DateTime(2022, 9, 12, 22, 53, 47, 400, DateTimeKind.Local).AddTicks(2115), "some image url", "Harry Potter 4", 2, 1987 },
                    { 9, "description goes here", 1, new DateTime(2022, 9, 12, 22, 53, 47, 400, DateTimeKind.Local).AddTicks(2119), "some image url", "Harry Potter 5", 2, 1987 },
                    { 10, "description goes here", 1, new DateTime(2022, 9, 12, 22, 53, 47, 400, DateTimeKind.Local).AddTicks(2122), "some image url", "Movie 1", 3, 1987 },
                    { 11, "description goes here", 1, new DateTime(2022, 9, 12, 22, 53, 47, 400, DateTimeKind.Local).AddTicks(2124), "some image url", "Movie 2", 3, 1987 },
                    { 12, "description goes here", 1, new DateTime(2022, 9, 12, 22, 53, 47, 400, DateTimeKind.Local).AddTicks(2127), "some image url", "Movie 3", 3, 1987 },
                    { 13, "description goes here", 1, new DateTime(2022, 9, 12, 22, 53, 47, 400, DateTimeKind.Local).AddTicks(2130), "some image url", "Movie 4", 3, 1987 },
                    { 14, "description goes here", 1, new DateTime(2022, 9, 12, 22, 53, 47, 400, DateTimeKind.Local).AddTicks(2133), "some image url", "Movie 5", 3, 1987 },
                    { 15, "description goes here", 1, new DateTime(2022, 9, 12, 22, 53, 47, 400, DateTimeKind.Local).AddTicks(2136), "some image url", "Movie 6", 4, 1987 },
                    { 16, "description goes here", 1, new DateTime(2022, 9, 12, 22, 53, 47, 400, DateTimeKind.Local).AddTicks(2138), "some image url", "Movie 7", 4, 1987 },
                    { 17, "description goes here", 1, new DateTime(2022, 9, 12, 22, 53, 47, 400, DateTimeKind.Local).AddTicks(2141), "some image url", "Movie 8", 4, 1987 },
                    { 18, "description goes here", 1, new DateTime(2022, 9, 12, 22, 53, 47, 400, DateTimeKind.Local).AddTicks(2144), "some image url", "Movie 9", 4, 1987 }
                });

            migrationBuilder.InsertData(
                table: "Review",
                columns: new[] { "Id", "MovieId", "Posted", "Rating", "Review", "UserId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2022, 9, 12, 22, 53, 47, 400, DateTimeKind.Local).AddTicks(2171), 5, "Review from user 1 - 1 ", 1 },
                    { 2, 2, new DateTime(2022, 9, 12, 22, 53, 47, 400, DateTimeKind.Local).AddTicks(2174), 5, "Review from user 1 - 2 ", 1 },
                    { 3, 3, new DateTime(2022, 9, 12, 22, 53, 47, 400, DateTimeKind.Local).AddTicks(2177), 5, "Review from user 1 - 3 ", 1 },
                    { 4, 4, new DateTime(2022, 9, 12, 22, 53, 47, 400, DateTimeKind.Local).AddTicks(2180), 5, "Review from user 1 - 4 ", 1 },
                    { 5, 5, new DateTime(2022, 9, 12, 22, 53, 47, 400, DateTimeKind.Local).AddTicks(2182), 5, "Review from user 1 - 5 ", 1 },
                    { 6, 6, new DateTime(2022, 9, 12, 22, 53, 47, 400, DateTimeKind.Local).AddTicks(2185), 5, "Review from user 1 - 6 ", 1 },
                    { 7, 7, new DateTime(2022, 9, 12, 22, 53, 47, 400, DateTimeKind.Local).AddTicks(2188), 5, "Review from user 1 - 7 ", 1 },
                    { 8, 8, new DateTime(2022, 9, 12, 22, 53, 47, 400, DateTimeKind.Local).AddTicks(2190), 5, "Review from user 1 - 8 ", 1 },
                    { 9, 9, new DateTime(2022, 9, 12, 22, 53, 47, 400, DateTimeKind.Local).AddTicks(2193), 5, "Review from user 1 - 9 ", 1 },
                    { 10, 10, new DateTime(2022, 9, 12, 22, 53, 47, 400, DateTimeKind.Local).AddTicks(2196), 5, "Review from user 1 - 10 ", 1 },
                    { 11, 11, new DateTime(2022, 9, 12, 22, 53, 47, 400, DateTimeKind.Local).AddTicks(2198), 5, "Review from user 1 - 11 ", 1 },
                    { 12, 12, new DateTime(2022, 9, 12, 22, 53, 47, 400, DateTimeKind.Local).AddTicks(2201), 5, "Review from user 1 - 12 ", 1 },
                    { 13, 13, new DateTime(2022, 9, 12, 22, 53, 47, 400, DateTimeKind.Local).AddTicks(2204), 5, "Review from user 1 - 13 ", 1 },
                    { 14, 14, new DateTime(2022, 9, 12, 22, 53, 47, 400, DateTimeKind.Local).AddTicks(2206), 5, "Review from user 1 - 14 ", 1 },
                    { 15, 15, new DateTime(2022, 9, 12, 22, 53, 47, 400, DateTimeKind.Local).AddTicks(2209), 5, "Review from user 1 - 15 ", 1 },
                    { 16, 16, new DateTime(2022, 9, 12, 22, 53, 47, 400, DateTimeKind.Local).AddTicks(2211), 5, "Review from user 1 - 16 ", 1 },
                    { 17, 17, new DateTime(2022, 9, 12, 22, 53, 47, 400, DateTimeKind.Local).AddTicks(2214), 5, "Review from user 1 - 17 ", 1 },
                    { 18, 18, new DateTime(2022, 9, 12, 22, 53, 47, 400, DateTimeKind.Local).AddTicks(2217), 5, "Review from user 1 - 18 ", 1 },
                    { 19, 1, new DateTime(2022, 9, 12, 22, 53, 47, 400, DateTimeKind.Local).AddTicks(2219), 5, "Review from user 2 - 1 ", 2 },
                    { 20, 2, new DateTime(2022, 9, 12, 22, 53, 47, 400, DateTimeKind.Local).AddTicks(2222), 5, "Review from user 2 - 2 ", 2 },
                    { 21, 3, new DateTime(2022, 9, 12, 22, 53, 47, 400, DateTimeKind.Local).AddTicks(2225), 5, "Review from user 2 - 3 ", 2 },
                    { 22, 4, new DateTime(2022, 9, 12, 22, 53, 47, 400, DateTimeKind.Local).AddTicks(2228), 5, "Review from user 2 - 4 ", 2 },
                    { 23, 5, new DateTime(2022, 9, 12, 22, 53, 47, 400, DateTimeKind.Local).AddTicks(2231), 5, "Review from user 2 - 5 ", 2 },
                    { 24, 6, new DateTime(2022, 9, 12, 22, 53, 47, 400, DateTimeKind.Local).AddTicks(2234), 5, "Review from user 2 - 6 ", 2 },
                    { 25, 7, new DateTime(2022, 9, 12, 22, 53, 47, 400, DateTimeKind.Local).AddTicks(2236), 5, "Review from user 2 - 7 ", 2 },
                    { 26, 8, new DateTime(2022, 9, 12, 22, 53, 47, 400, DateTimeKind.Local).AddTicks(2239), 5, "Review from user 2 - 8 ", 2 },
                    { 27, 9, new DateTime(2022, 9, 12, 22, 53, 47, 400, DateTimeKind.Local).AddTicks(2241), 5, "Review from user 2 - 9 ", 2 },
                    { 28, 10, new DateTime(2022, 9, 12, 22, 53, 47, 400, DateTimeKind.Local).AddTicks(2244), 5, "Review from user 2 - 10 ", 2 },
                    { 29, 11, new DateTime(2022, 9, 12, 22, 53, 47, 400, DateTimeKind.Local).AddTicks(2247), 5, "Review from user 2 - 11 ", 2 },
                    { 30, 12, new DateTime(2022, 9, 12, 22, 53, 47, 400, DateTimeKind.Local).AddTicks(2249), 5, "Review from user 2 - 12 ", 2 },
                    { 31, 13, new DateTime(2022, 9, 12, 22, 53, 47, 400, DateTimeKind.Local).AddTicks(2314), 5, "Review from user 2 - 13 ", 2 },
                    { 32, 14, new DateTime(2022, 9, 12, 22, 53, 47, 400, DateTimeKind.Local).AddTicks(2317), 5, "Review from user 2 - 14 ", 2 },
                    { 33, 15, new DateTime(2022, 9, 12, 22, 53, 47, 400, DateTimeKind.Local).AddTicks(2320), 5, "Review from user 2 - 15 ", 2 },
                    { 34, 16, new DateTime(2022, 9, 12, 22, 53, 47, 400, DateTimeKind.Local).AddTicks(2323), 5, "Review from user 2 - 16 ", 2 },
                    { 35, 17, new DateTime(2022, 9, 12, 22, 53, 47, 400, DateTimeKind.Local).AddTicks(2325), 5, "Review from user 2 - 17 ", 2 },
                    { 36, 18, new DateTime(2022, 9, 12, 22, 53, 47, 400, DateTimeKind.Local).AddTicks(2328), 5, "Review from user 2 - 18 ", 2 },
                    { 37, 1, new DateTime(2022, 9, 12, 22, 53, 47, 400, DateTimeKind.Local).AddTicks(2330), 5, "Review from user 3 - 1 ", 3 },
                    { 38, 2, new DateTime(2022, 9, 12, 22, 53, 47, 400, DateTimeKind.Local).AddTicks(2333), 5, "Review from user 3 - 2 ", 3 },
                    { 39, 3, new DateTime(2022, 9, 12, 22, 53, 47, 400, DateTimeKind.Local).AddTicks(2338), 5, "Review from user 3 - 3 ", 3 },
                    { 40, 4, new DateTime(2022, 9, 12, 22, 53, 47, 400, DateTimeKind.Local).AddTicks(2341), 5, "Review from user 3 - 4 ", 3 },
                    { 41, 5, new DateTime(2022, 9, 12, 22, 53, 47, 400, DateTimeKind.Local).AddTicks(2344), 5, "Review from user 3 - 5 ", 3 },
                    { 42, 6, new DateTime(2022, 9, 12, 22, 53, 47, 400, DateTimeKind.Local).AddTicks(2346), 5, "Review from user 3 - 6 ", 3 }
                });

            migrationBuilder.InsertData(
                table: "Review",
                columns: new[] { "Id", "MovieId", "Posted", "Rating", "Review", "UserId" },
                values: new object[,]
                {
                    { 43, 7, new DateTime(2022, 9, 12, 22, 53, 47, 400, DateTimeKind.Local).AddTicks(2349), 5, "Review from user 3 - 7 ", 3 },
                    { 44, 8, new DateTime(2022, 9, 12, 22, 53, 47, 400, DateTimeKind.Local).AddTicks(2351), 5, "Review from user 3 - 8 ", 3 },
                    { 45, 9, new DateTime(2022, 9, 12, 22, 53, 47, 400, DateTimeKind.Local).AddTicks(2354), 5, "Review from user 3 - 9 ", 3 },
                    { 46, 10, new DateTime(2022, 9, 12, 22, 53, 47, 400, DateTimeKind.Local).AddTicks(2357), 5, "Review from user 3 - 10 ", 3 },
                    { 47, 11, new DateTime(2022, 9, 12, 22, 53, 47, 400, DateTimeKind.Local).AddTicks(2360), 5, "Review from user 3 - 11 ", 3 },
                    { 48, 12, new DateTime(2022, 9, 12, 22, 53, 47, 400, DateTimeKind.Local).AddTicks(2362), 5, "Review from user 3 - 12 ", 3 },
                    { 49, 13, new DateTime(2022, 9, 12, 22, 53, 47, 400, DateTimeKind.Local).AddTicks(2365), 5, "Review from user 3 - 13 ", 3 },
                    { 50, 14, new DateTime(2022, 9, 12, 22, 53, 47, 400, DateTimeKind.Local).AddTicks(2368), 5, "Review from user 3 - 14 ", 3 },
                    { 51, 15, new DateTime(2022, 9, 12, 22, 53, 47, 400, DateTimeKind.Local).AddTicks(2370), 5, "Review from user 3 - 15 ", 3 },
                    { 52, 16, new DateTime(2022, 9, 12, 22, 53, 47, 400, DateTimeKind.Local).AddTicks(2373), 5, "Review from user 3 - 16 ", 3 },
                    { 53, 17, new DateTime(2022, 9, 12, 22, 53, 47, 400, DateTimeKind.Local).AddTicks(2375), 5, "Review from user 3 - 17 ", 3 },
                    { 54, 18, new DateTime(2022, 9, 12, 22, 53, 47, 400, DateTimeKind.Local).AddTicks(2378), 5, "Review from user 3 - 18 ", 3 },
                    { 55, 1, new DateTime(2022, 9, 12, 22, 53, 47, 400, DateTimeKind.Local).AddTicks(2381), 5, "Review from user 4 - 1 ", 4 },
                    { 56, 2, new DateTime(2022, 9, 12, 22, 53, 47, 400, DateTimeKind.Local).AddTicks(2383), 5, "Review from user 4 - 2 ", 4 },
                    { 57, 3, new DateTime(2022, 9, 12, 22, 53, 47, 400, DateTimeKind.Local).AddTicks(2386), 5, "Review from user 4 - 3 ", 4 },
                    { 58, 4, new DateTime(2022, 9, 12, 22, 53, 47, 400, DateTimeKind.Local).AddTicks(2388), 5, "Review from user 4 - 4 ", 4 },
                    { 59, 5, new DateTime(2022, 9, 12, 22, 53, 47, 400, DateTimeKind.Local).AddTicks(2391), 5, "Review from user 4 - 5 ", 4 },
                    { 60, 6, new DateTime(2022, 9, 12, 22, 53, 47, 400, DateTimeKind.Local).AddTicks(2394), 5, "Review from user 4 - 6 ", 4 },
                    { 61, 7, new DateTime(2022, 9, 12, 22, 53, 47, 400, DateTimeKind.Local).AddTicks(2396), 5, "Review from user 4 - 7 ", 4 },
                    { 62, 8, new DateTime(2022, 9, 12, 22, 53, 47, 400, DateTimeKind.Local).AddTicks(2399), 5, "Review from user 4 - 8 ", 4 },
                    { 63, 9, new DateTime(2022, 9, 12, 22, 53, 47, 400, DateTimeKind.Local).AddTicks(2402), 5, "Review from user 4 - 9 ", 4 },
                    { 64, 10, new DateTime(2022, 9, 12, 22, 53, 47, 400, DateTimeKind.Local).AddTicks(2404), 5, "Review from user 4 - 10 ", 4 },
                    { 65, 11, new DateTime(2022, 9, 12, 22, 53, 47, 400, DateTimeKind.Local).AddTicks(2407), 5, "Review from user 4 - 11 ", 4 },
                    { 66, 12, new DateTime(2022, 9, 12, 22, 53, 47, 400, DateTimeKind.Local).AddTicks(2409), 5, "Review from user 4 - 12 ", 4 },
                    { 67, 13, new DateTime(2022, 9, 12, 22, 53, 47, 400, DateTimeKind.Local).AddTicks(2412), 5, "Review from user 4 - 13 ", 4 },
                    { 68, 14, new DateTime(2022, 9, 12, 22, 53, 47, 400, DateTimeKind.Local).AddTicks(2414), 5, "Review from user 4 - 14 ", 4 },
                    { 69, 15, new DateTime(2022, 9, 12, 22, 53, 47, 400, DateTimeKind.Local).AddTicks(2417), 5, "Review from user 4 - 15 ", 4 },
                    { 70, 16, new DateTime(2022, 9, 12, 22, 53, 47, 400, DateTimeKind.Local).AddTicks(2419), 5, "Review from user 4 - 16 ", 4 },
                    { 71, 17, new DateTime(2022, 9, 12, 22, 53, 47, 400, DateTimeKind.Local).AddTicks(2422), 5, "Review from user 4 - 17 ", 4 },
                    { 72, 18, new DateTime(2022, 9, 12, 22, 53, 47, 400, DateTimeKind.Local).AddTicks(2425), 5, "Review from user 4 - 18 ", 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Movie_UserId",
                table: "Movie",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Review_MovieId",
                table: "Review",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Review_UserId",
                table: "Review",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Review");

            migrationBuilder.DropTable(
                name: "Movie");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
