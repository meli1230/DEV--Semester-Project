using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MelisaIuliaProiect.Migrations
{
    /// <inheritdoc />
    public partial class ModelTypeTransmissionFuel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CarType",
                table: "Car");

            migrationBuilder.DropColumn(
                name: "FuelType",
                table: "Car");

            migrationBuilder.DropColumn(
                name: "Model",
                table: "Car");

            migrationBuilder.DropColumn(
                name: "Transmission",
                table: "Car");

            migrationBuilder.AddColumn<int>(
                name: "FuelID",
                table: "Car",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TransmissionID",
                table: "Car",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VehicleModelID",
                table: "Car",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VehicleTypeID",
                table: "Car",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Fuel",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FuelName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fuel", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Transmission",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransmissionName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transmission", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "VehicleModel",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleModelName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleModel", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "VehicleType",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleType", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Car_FuelID",
                table: "Car",
                column: "FuelID");

            migrationBuilder.CreateIndex(
                name: "IX_Car_TransmissionID",
                table: "Car",
                column: "TransmissionID");

            migrationBuilder.CreateIndex(
                name: "IX_Car_VehicleModelID",
                table: "Car",
                column: "VehicleModelID");

            migrationBuilder.CreateIndex(
                name: "IX_Car_VehicleTypeID",
                table: "Car",
                column: "VehicleTypeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Car_Fuel_FuelID",
                table: "Car",
                column: "FuelID",
                principalTable: "Fuel",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Car_Transmission_TransmissionID",
                table: "Car",
                column: "TransmissionID",
                principalTable: "Transmission",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Car_VehicleModel_VehicleModelID",
                table: "Car",
                column: "VehicleModelID",
                principalTable: "VehicleModel",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Car_VehicleType_VehicleTypeID",
                table: "Car",
                column: "VehicleTypeID",
                principalTable: "VehicleType",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Car_Fuel_FuelID",
                table: "Car");

            migrationBuilder.DropForeignKey(
                name: "FK_Car_Transmission_TransmissionID",
                table: "Car");

            migrationBuilder.DropForeignKey(
                name: "FK_Car_VehicleModel_VehicleModelID",
                table: "Car");

            migrationBuilder.DropForeignKey(
                name: "FK_Car_VehicleType_VehicleTypeID",
                table: "Car");

            migrationBuilder.DropTable(
                name: "Fuel");

            migrationBuilder.DropTable(
                name: "Transmission");

            migrationBuilder.DropTable(
                name: "VehicleModel");

            migrationBuilder.DropTable(
                name: "VehicleType");

            migrationBuilder.DropIndex(
                name: "IX_Car_FuelID",
                table: "Car");

            migrationBuilder.DropIndex(
                name: "IX_Car_TransmissionID",
                table: "Car");

            migrationBuilder.DropIndex(
                name: "IX_Car_VehicleModelID",
                table: "Car");

            migrationBuilder.DropIndex(
                name: "IX_Car_VehicleTypeID",
                table: "Car");

            migrationBuilder.DropColumn(
                name: "FuelID",
                table: "Car");

            migrationBuilder.DropColumn(
                name: "TransmissionID",
                table: "Car");

            migrationBuilder.DropColumn(
                name: "VehicleModelID",
                table: "Car");

            migrationBuilder.DropColumn(
                name: "VehicleTypeID",
                table: "Car");

            migrationBuilder.AddColumn<string>(
                name: "CarType",
                table: "Car",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FuelType",
                table: "Car",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Model",
                table: "Car",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Transmission",
                table: "Car",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
