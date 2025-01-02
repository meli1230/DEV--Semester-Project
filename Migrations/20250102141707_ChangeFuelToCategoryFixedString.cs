using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MelisaIuliaProiect.Migrations
{
    /// <inheritdoc />
    public partial class ChangeFuelToCategoryFixedString : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarFuel_Car_CarVIN1",
                table: "CarFuel");

            migrationBuilder.DropIndex(
                name: "IX_CarFuel_CarVIN1",
                table: "CarFuel");

            migrationBuilder.DropColumn(
                name: "CarVIN1",
                table: "CarFuel");

            migrationBuilder.AlterColumn<string>(
                name: "CarVIN",
                table: "CarFuel",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_CarFuel_CarVIN",
                table: "CarFuel",
                column: "CarVIN");

            migrationBuilder.AddForeignKey(
                name: "FK_CarFuel_Car_CarVIN",
                table: "CarFuel",
                column: "CarVIN",
                principalTable: "Car",
                principalColumn: "VIN",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarFuel_Car_CarVIN",
                table: "CarFuel");

            migrationBuilder.DropIndex(
                name: "IX_CarFuel_CarVIN",
                table: "CarFuel");

            migrationBuilder.AlterColumn<int>(
                name: "CarVIN",
                table: "CarFuel",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "CarVIN1",
                table: "CarFuel",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CarFuel_CarVIN1",
                table: "CarFuel",
                column: "CarVIN1");

            migrationBuilder.AddForeignKey(
                name: "FK_CarFuel_Car_CarVIN1",
                table: "CarFuel",
                column: "CarVIN1",
                principalTable: "Car",
                principalColumn: "VIN");
        }
    }
}
