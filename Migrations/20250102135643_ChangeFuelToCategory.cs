using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MelisaIuliaProiect.Migrations
{
    /// <inheritdoc />
    public partial class ChangeFuelToCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Car_Fuel_FuelID",
                table: "Car");

            migrationBuilder.DropIndex(
                name: "IX_Car_FuelID",
                table: "Car");

            migrationBuilder.DropColumn(
                name: "FuelID",
                table: "Car");

            migrationBuilder.CreateTable(
                name: "CarFuel",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarVIN = table.Column<int>(type: "int", nullable: false),
                    CarVIN1 = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    FuelID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarFuel", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CarFuel_Car_CarVIN1",
                        column: x => x.CarVIN1,
                        principalTable: "Car",
                        principalColumn: "VIN");
                    table.ForeignKey(
                        name: "FK_CarFuel_Fuel_FuelID",
                        column: x => x.FuelID,
                        principalTable: "Fuel",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarFuel_CarVIN1",
                table: "CarFuel",
                column: "CarVIN1");

            migrationBuilder.CreateIndex(
                name: "IX_CarFuel_FuelID",
                table: "CarFuel",
                column: "FuelID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarFuel");

            migrationBuilder.AddColumn<int>(
                name: "FuelID",
                table: "Car",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Car_FuelID",
                table: "Car",
                column: "FuelID");

            migrationBuilder.AddForeignKey(
                name: "FK_Car_Fuel_FuelID",
                table: "Car",
                column: "FuelID",
                principalTable: "Fuel",
                principalColumn: "ID");
        }
    }
}
