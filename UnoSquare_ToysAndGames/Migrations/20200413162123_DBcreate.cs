using Microsoft.EntityFrameworkCore.Migrations;

namespace UnoSquare_ToysAndGames.Migrations
{
    public partial class DBcreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(maxLength: 100, nullable: true),
                    AgeRestriction = table.Column<int>(nullable: true),
                    Company = table.Column<string>(maxLength: 50, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(6,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "AgeRestriction", "Company", "Description", "Name", "Price" },
                values: new object[] { 1, 18, "Fake Company 1", "Fake product 1", "Seeded Name 1", 120m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "AgeRestriction", "Company", "Description", "Name", "Price" },
                values: new object[] { 2, 14, "Fake Company 2", "Fake product 2", "Seeded Name 2", 50m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
