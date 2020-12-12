using Microsoft.EntityFrameworkCore.Migrations;

namespace Cars.Api.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Manufacturers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manufacturers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Model = table.Column<string>(type: "TEXT", nullable: true),
                    Speed = table.Column<int>(type: "INTEGER", nullable: false),
                    ManufacturerId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cars_Manufacturers_ManufacturerId",
                        column: x => x.ManufacturerId,
                        principalTable: "Manufacturers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Manufacturers",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Volkswagen" });

            migrationBuilder.InsertData(
                table: "Manufacturers",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Fiat" });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "ManufacturerId", "Model", "Speed" },
                values: new object[] { 1, 1, "Gol", 100 });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "ManufacturerId", "Model", "Speed" },
                values: new object[] { 3, 1, "Fox", 120 });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "ManufacturerId", "Model", "Speed" },
                values: new object[] { 2, 2, "Palio", 90 });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "ManufacturerId", "Model", "Speed" },
                values: new object[] { 4, 2, "Punto", 110 });

            migrationBuilder.CreateIndex(
                name: "IX_Cars_ManufacturerId",
                table: "Cars",
                column: "ManufacturerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "Manufacturers");
        }
    }
}
