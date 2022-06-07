using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazorApp.Api.Migrations
{
    public partial class AddBookshelf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bookshelves",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Manufacturer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Condition = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Length = table.Column<double>(type: "float", nullable: false),
                    Width = table.Column<double>(type: "float", nullable: false),
                    Height = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookshelves", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Bookshelves",
                columns: new[] { "Id", "Code", "Condition", "Height", "Length", "Manufacturer", "Width" },
                values: new object[] { 1, "A1", "Few scratches on the left board", 300.0, 250.0, null, 50.0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookshelves");
        }
    }
}
