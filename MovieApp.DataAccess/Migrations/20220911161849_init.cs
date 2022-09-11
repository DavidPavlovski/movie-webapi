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
                    UserId = table.Column<int>(type: "int", nullable: false),
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
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    { 1, "description goes here", 1, new DateTime(2022, 9, 11, 18, 18, 49, 659, DateTimeKind.Local).AddTicks(7257), "some image url", "Star wars episode 4", 1, 1987 },
                    { 2, "description goes here", 1, new DateTime(2022, 9, 11, 18, 18, 49, 659, DateTimeKind.Local).AddTicks(7298), "some image url", "Star wars episode 5", 1, 1987 },
                    { 3, "description goes here", 1, new DateTime(2022, 9, 11, 18, 18, 49, 659, DateTimeKind.Local).AddTicks(7301), "some image url", "Star wars episode 6", 1, 1987 },
                    { 4, "description goes here", 1, new DateTime(2022, 9, 11, 18, 18, 49, 659, DateTimeKind.Local).AddTicks(7304), "some image url", "Star wars episode 7", 1, 1987 },
                    { 5, "description goes here", 1, new DateTime(2022, 9, 11, 18, 18, 49, 659, DateTimeKind.Local).AddTicks(7306), "some image url", "Harry Potter 1", 2, 1987 },
                    { 6, "description goes here", 1, new DateTime(2022, 9, 11, 18, 18, 49, 659, DateTimeKind.Local).AddTicks(7309), "some image url", "Harry Potter 2", 2, 1987 },
                    { 7, "description goes here", 1, new DateTime(2022, 9, 11, 18, 18, 49, 659, DateTimeKind.Local).AddTicks(7312), "some image url", "Harry Potter 3", 2, 1987 },
                    { 8, "description goes here", 1, new DateTime(2022, 9, 11, 18, 18, 49, 659, DateTimeKind.Local).AddTicks(7315), "some image url", "Harry Potter 4", 2, 1987 },
                    { 9, "description goes here", 1, new DateTime(2022, 9, 11, 18, 18, 49, 659, DateTimeKind.Local).AddTicks(7318), "some image url", "Harry Potter 5", 2, 1987 },
                    { 10, "description goes here", 1, new DateTime(2022, 9, 11, 18, 18, 49, 659, DateTimeKind.Local).AddTicks(7321), "some image url", "Movie 1", 3, 1987 },
                    { 11, "description goes here", 1, new DateTime(2022, 9, 11, 18, 18, 49, 659, DateTimeKind.Local).AddTicks(7323), "some image url", "Movie 2", 3, 1987 },
                    { 12, "description goes here", 1, new DateTime(2022, 9, 11, 18, 18, 49, 659, DateTimeKind.Local).AddTicks(7326), "some image url", "Movie 3", 3, 1987 },
                    { 13, "description goes here", 1, new DateTime(2022, 9, 11, 18, 18, 49, 659, DateTimeKind.Local).AddTicks(7329), "some image url", "Movie 4", 3, 1987 },
                    { 14, "description goes here", 1, new DateTime(2022, 9, 11, 18, 18, 49, 659, DateTimeKind.Local).AddTicks(7332), "some image url", "Movie 5", 3, 1987 },
                    { 15, "description goes here", 1, new DateTime(2022, 9, 11, 18, 18, 49, 659, DateTimeKind.Local).AddTicks(7335), "some image url", "Movie 6", 4, 1987 },
                    { 16, "description goes here", 1, new DateTime(2022, 9, 11, 18, 18, 49, 659, DateTimeKind.Local).AddTicks(7337), "some image url", "Movie 7", 4, 1987 },
                    { 17, "description goes here", 1, new DateTime(2022, 9, 11, 18, 18, 49, 659, DateTimeKind.Local).AddTicks(7340), "some image url", "Movie 8", 4, 1987 },
                    { 18, "description goes here", 1, new DateTime(2022, 9, 11, 18, 18, 49, 659, DateTimeKind.Local).AddTicks(7344), "some image url", "Movie 9", 4, 1987 }
                });

            migrationBuilder.InsertData(
                table: "Review",
                columns: new[] { "Id", "MovieId", "Posted", "Rating", "Review", "UserId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2022, 9, 11, 18, 18, 49, 659, DateTimeKind.Local).AddTicks(7372), 5, "Review from user 1 - 1 ", 1 },
                    { 2, 2, new DateTime(2022, 9, 11, 18, 18, 49, 659, DateTimeKind.Local).AddTicks(7377), 5, "Review from user 1 - 2 ", 1 },
                    { 3, 3, new DateTime(2022, 9, 11, 18, 18, 49, 659, DateTimeKind.Local).AddTicks(7380), 5, "Review from user 1 - 3 ", 1 },
                    { 4, 4, new DateTime(2022, 9, 11, 18, 18, 49, 659, DateTimeKind.Local).AddTicks(7383), 5, "Review from user 1 - 4 ", 1 },
                    { 5, 5, new DateTime(2022, 9, 11, 18, 18, 49, 659, DateTimeKind.Local).AddTicks(7385), 5, "Review from user 1 - 5 ", 1 },
                    { 6, 6, new DateTime(2022, 9, 11, 18, 18, 49, 659, DateTimeKind.Local).AddTicks(7388), 5, "Review from user 1 - 6 ", 1 },
                    { 7, 7, new DateTime(2022, 9, 11, 18, 18, 49, 659, DateTimeKind.Local).AddTicks(7390), 5, "Review from user 1 - 7 ", 1 },
                    { 8, 8, new DateTime(2022, 9, 11, 18, 18, 49, 659, DateTimeKind.Local).AddTicks(7393), 5, "Review from user 1 - 8 ", 1 },
                    { 9, 9, new DateTime(2022, 9, 11, 18, 18, 49, 659, DateTimeKind.Local).AddTicks(7395), 5, "Review from user 1 - 9 ", 1 },
                    { 10, 10, new DateTime(2022, 9, 11, 18, 18, 49, 659, DateTimeKind.Local).AddTicks(7398), 5, "Review from user 1 - 10 ", 1 },
                    { 11, 11, new DateTime(2022, 9, 11, 18, 18, 49, 659, DateTimeKind.Local).AddTicks(7400), 5, "Review from user 1 - 11 ", 1 },
                    { 12, 12, new DateTime(2022, 9, 11, 18, 18, 49, 659, DateTimeKind.Local).AddTicks(7403), 5, "Review from user 1 - 12 ", 1 },
                    { 13, 13, new DateTime(2022, 9, 11, 18, 18, 49, 659, DateTimeKind.Local).AddTicks(7405), 5, "Review from user 1 - 13 ", 1 },
                    { 14, 14, new DateTime(2022, 9, 11, 18, 18, 49, 659, DateTimeKind.Local).AddTicks(7408), 5, "Review from user 1 - 14 ", 1 },
                    { 15, 15, new DateTime(2022, 9, 11, 18, 18, 49, 659, DateTimeKind.Local).AddTicks(7410), 5, "Review from user 1 - 15 ", 1 },
                    { 16, 16, new DateTime(2022, 9, 11, 18, 18, 49, 659, DateTimeKind.Local).AddTicks(7413), 5, "Review from user 1 - 16 ", 1 },
                    { 17, 17, new DateTime(2022, 9, 11, 18, 18, 49, 659, DateTimeKind.Local).AddTicks(7416), 5, "Review from user 1 - 17 ", 1 },
                    { 18, 18, new DateTime(2022, 9, 11, 18, 18, 49, 659, DateTimeKind.Local).AddTicks(7418), 5, "Review from user 1 - 18 ", 1 },
                    { 19, 1, new DateTime(2022, 9, 11, 18, 18, 49, 659, DateTimeKind.Local).AddTicks(7421), 5, "Review from user 2 - 1 ", 2 },
                    { 20, 2, new DateTime(2022, 9, 11, 18, 18, 49, 659, DateTimeKind.Local).AddTicks(7423), 5, "Review from user 2 - 2 ", 2 },
                    { 21, 3, new DateTime(2022, 9, 11, 18, 18, 49, 659, DateTimeKind.Local).AddTicks(7426), 5, "Review from user 2 - 3 ", 2 },
                    { 22, 4, new DateTime(2022, 9, 11, 18, 18, 49, 659, DateTimeKind.Local).AddTicks(7429), 5, "Review from user 2 - 4 ", 2 },
                    { 23, 5, new DateTime(2022, 9, 11, 18, 18, 49, 659, DateTimeKind.Local).AddTicks(7431), 5, "Review from user 2 - 5 ", 2 },
                    { 24, 6, new DateTime(2022, 9, 11, 18, 18, 49, 659, DateTimeKind.Local).AddTicks(7434), 5, "Review from user 2 - 6 ", 2 },
                    { 25, 7, new DateTime(2022, 9, 11, 18, 18, 49, 659, DateTimeKind.Local).AddTicks(7436), 5, "Review from user 2 - 7 ", 2 },
                    { 26, 8, new DateTime(2022, 9, 11, 18, 18, 49, 659, DateTimeKind.Local).AddTicks(7439), 5, "Review from user 2 - 8 ", 2 },
                    { 27, 9, new DateTime(2022, 9, 11, 18, 18, 49, 659, DateTimeKind.Local).AddTicks(7441), 5, "Review from user 2 - 9 ", 2 },
                    { 28, 10, new DateTime(2022, 9, 11, 18, 18, 49, 659, DateTimeKind.Local).AddTicks(7444), 5, "Review from user 2 - 10 ", 2 },
                    { 29, 11, new DateTime(2022, 9, 11, 18, 18, 49, 659, DateTimeKind.Local).AddTicks(7446), 5, "Review from user 2 - 11 ", 2 },
                    { 30, 12, new DateTime(2022, 9, 11, 18, 18, 49, 659, DateTimeKind.Local).AddTicks(7449), 5, "Review from user 2 - 12 ", 2 },
                    { 31, 13, new DateTime(2022, 9, 11, 18, 18, 49, 659, DateTimeKind.Local).AddTicks(7513), 5, "Review from user 2 - 13 ", 2 },
                    { 32, 14, new DateTime(2022, 9, 11, 18, 18, 49, 659, DateTimeKind.Local).AddTicks(7516), 5, "Review from user 2 - 14 ", 2 },
                    { 33, 15, new DateTime(2022, 9, 11, 18, 18, 49, 659, DateTimeKind.Local).AddTicks(7519), 5, "Review from user 2 - 15 ", 2 },
                    { 34, 16, new DateTime(2022, 9, 11, 18, 18, 49, 659, DateTimeKind.Local).AddTicks(7522), 5, "Review from user 2 - 16 ", 2 },
                    { 35, 17, new DateTime(2022, 9, 11, 18, 18, 49, 659, DateTimeKind.Local).AddTicks(7524), 5, "Review from user 2 - 17 ", 2 },
                    { 36, 18, new DateTime(2022, 9, 11, 18, 18, 49, 659, DateTimeKind.Local).AddTicks(7527), 5, "Review from user 2 - 18 ", 2 },
                    { 37, 1, new DateTime(2022, 9, 11, 18, 18, 49, 659, DateTimeKind.Local).AddTicks(7530), 5, "Review from user 3 - 1 ", 3 },
                    { 38, 2, new DateTime(2022, 9, 11, 18, 18, 49, 659, DateTimeKind.Local).AddTicks(7532), 5, "Review from user 3 - 2 ", 3 },
                    { 39, 3, new DateTime(2022, 9, 11, 18, 18, 49, 659, DateTimeKind.Local).AddTicks(7535), 5, "Review from user 3 - 3 ", 3 },
                    { 40, 4, new DateTime(2022, 9, 11, 18, 18, 49, 659, DateTimeKind.Local).AddTicks(7537), 5, "Review from user 3 - 4 ", 3 },
                    { 41, 5, new DateTime(2022, 9, 11, 18, 18, 49, 659, DateTimeKind.Local).AddTicks(7539), 5, "Review from user 3 - 5 ", 3 },
                    { 42, 6, new DateTime(2022, 9, 11, 18, 18, 49, 659, DateTimeKind.Local).AddTicks(7542), 5, "Review from user 3 - 6 ", 3 }
                });

            migrationBuilder.InsertData(
                table: "Review",
                columns: new[] { "Id", "MovieId", "Posted", "Rating", "Review", "UserId" },
                values: new object[,]
                {
                    { 43, 7, new DateTime(2022, 9, 11, 18, 18, 49, 659, DateTimeKind.Local).AddTicks(7545), 5, "Review from user 3 - 7 ", 3 },
                    { 44, 8, new DateTime(2022, 9, 11, 18, 18, 49, 659, DateTimeKind.Local).AddTicks(7547), 5, "Review from user 3 - 8 ", 3 },
                    { 45, 9, new DateTime(2022, 9, 11, 18, 18, 49, 659, DateTimeKind.Local).AddTicks(7549), 5, "Review from user 3 - 9 ", 3 },
                    { 46, 10, new DateTime(2022, 9, 11, 18, 18, 49, 659, DateTimeKind.Local).AddTicks(7552), 5, "Review from user 3 - 10 ", 3 },
                    { 47, 11, new DateTime(2022, 9, 11, 18, 18, 49, 659, DateTimeKind.Local).AddTicks(7555), 5, "Review from user 3 - 11 ", 3 },
                    { 48, 12, new DateTime(2022, 9, 11, 18, 18, 49, 659, DateTimeKind.Local).AddTicks(7557), 5, "Review from user 3 - 12 ", 3 },
                    { 49, 13, new DateTime(2022, 9, 11, 18, 18, 49, 659, DateTimeKind.Local).AddTicks(7560), 5, "Review from user 3 - 13 ", 3 },
                    { 50, 14, new DateTime(2022, 9, 11, 18, 18, 49, 659, DateTimeKind.Local).AddTicks(7562), 5, "Review from user 3 - 14 ", 3 },
                    { 51, 15, new DateTime(2022, 9, 11, 18, 18, 49, 659, DateTimeKind.Local).AddTicks(7564), 5, "Review from user 3 - 15 ", 3 },
                    { 52, 16, new DateTime(2022, 9, 11, 18, 18, 49, 659, DateTimeKind.Local).AddTicks(7567), 5, "Review from user 3 - 16 ", 3 },
                    { 53, 17, new DateTime(2022, 9, 11, 18, 18, 49, 659, DateTimeKind.Local).AddTicks(7569), 5, "Review from user 3 - 17 ", 3 },
                    { 54, 18, new DateTime(2022, 9, 11, 18, 18, 49, 659, DateTimeKind.Local).AddTicks(7572), 5, "Review from user 3 - 18 ", 3 },
                    { 55, 1, new DateTime(2022, 9, 11, 18, 18, 49, 659, DateTimeKind.Local).AddTicks(7574), 5, "Review from user 4 - 1 ", 3 },
                    { 56, 2, new DateTime(2022, 9, 11, 18, 18, 49, 659, DateTimeKind.Local).AddTicks(7577), 5, "Review from user 4 - 2 ", 3 },
                    { 57, 3, new DateTime(2022, 9, 11, 18, 18, 49, 659, DateTimeKind.Local).AddTicks(7580), 5, "Review from user 4 - 3 ", 3 },
                    { 58, 4, new DateTime(2022, 9, 11, 18, 18, 49, 659, DateTimeKind.Local).AddTicks(7582), 5, "Review from user 4 - 4 ", 3 },
                    { 59, 5, new DateTime(2022, 9, 11, 18, 18, 49, 659, DateTimeKind.Local).AddTicks(7585), 5, "Review from user 4 - 5 ", 3 },
                    { 60, 6, new DateTime(2022, 9, 11, 18, 18, 49, 659, DateTimeKind.Local).AddTicks(7587), 5, "Review from user 4 - 6 ", 3 },
                    { 61, 7, new DateTime(2022, 9, 11, 18, 18, 49, 659, DateTimeKind.Local).AddTicks(7590), 5, "Review from user 4 - 7 ", 3 },
                    { 62, 8, new DateTime(2022, 9, 11, 18, 18, 49, 659, DateTimeKind.Local).AddTicks(7592), 5, "Review from user 4 - 8 ", 3 },
                    { 63, 9, new DateTime(2022, 9, 11, 18, 18, 49, 659, DateTimeKind.Local).AddTicks(7595), 5, "Review from user 4 - 9 ", 3 },
                    { 64, 10, new DateTime(2022, 9, 11, 18, 18, 49, 659, DateTimeKind.Local).AddTicks(7598), 5, "Review from user 4 - 10 ", 3 },
                    { 65, 11, new DateTime(2022, 9, 11, 18, 18, 49, 659, DateTimeKind.Local).AddTicks(7600), 5, "Review from user 4 - 11 ", 3 },
                    { 66, 12, new DateTime(2022, 9, 11, 18, 18, 49, 659, DateTimeKind.Local).AddTicks(7603), 5, "Review from user 4 - 12 ", 3 },
                    { 67, 13, new DateTime(2022, 9, 11, 18, 18, 49, 659, DateTimeKind.Local).AddTicks(7605), 5, "Review from user 4 - 13 ", 3 },
                    { 68, 14, new DateTime(2022, 9, 11, 18, 18, 49, 659, DateTimeKind.Local).AddTicks(7608), 5, "Review from user 4 - 14 ", 3 },
                    { 69, 15, new DateTime(2022, 9, 11, 18, 18, 49, 659, DateTimeKind.Local).AddTicks(7610), 5, "Review from user 4 - 15 ", 3 },
                    { 70, 16, new DateTime(2022, 9, 11, 18, 18, 49, 659, DateTimeKind.Local).AddTicks(7613), 5, "Review from user 4 - 16 ", 3 },
                    { 71, 17, new DateTime(2022, 9, 11, 18, 18, 49, 659, DateTimeKind.Local).AddTicks(7615), 5, "Review from user 4 - 17 ", 3 },
                    { 72, 18, new DateTime(2022, 9, 11, 18, 18, 49, 659, DateTimeKind.Local).AddTicks(7618), 5, "Review from user 4 - 18 ", 3 }
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
