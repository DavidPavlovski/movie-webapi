using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieApp.DataAccess.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    Genre = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movie", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Movie",
                columns: new[] { "Id", "Description", "Genre", "PosterUrl", "Title", "Year" },
                values: new object[] { 1, "Description goes here", 7, "https://davidkoepp.com/wp-content/themes/blankslate/images/Movie%20Placeholder.jpg", "Star Wars", 1977 });

            migrationBuilder.InsertData(
                table: "Movie",
                columns: new[] { "Id", "Description", "Genre", "PosterUrl", "Title", "Year" },
                values: new object[] { 2, "Description goes here", 5, "https://davidkoepp.com/wp-content/themes/blankslate/images/Movie%20Placeholder.jpg", "Pulp Fiction", 1994 });

            migrationBuilder.InsertData(
                table: "Movie",
                columns: new[] { "Id", "Description", "Genre", "PosterUrl", "Title", "Year" },
                values: new object[] { 3, "Description goes here", 1, "https://davidkoepp.com/wp-content/themes/blankslate/images/Movie%20Placeholder.jpg", "Die Hard", 1988 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movie");
        }
    }
}
