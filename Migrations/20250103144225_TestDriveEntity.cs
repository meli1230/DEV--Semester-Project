using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MelisaIuliaProiect.Migrations
{
    /// <inheritdoc />
    public partial class TestDriveEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TestDrive",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerID = table.Column<int>(type: "int", nullable: true),
                    CarID = table.Column<int>(type: "int", nullable: true),
                    CarVIN = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    TestDriveDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestDrive", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TestDrive_Car_CarVIN",
                        column: x => x.CarVIN,
                        principalTable: "Car",
                        principalColumn: "VIN");
                    table.ForeignKey(
                        name: "FK_TestDrive_Customer_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customer",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TestDrive_CarVIN",
                table: "TestDrive",
                column: "CarVIN");

            migrationBuilder.CreateIndex(
                name: "IX_TestDrive_CustomerID",
                table: "TestDrive",
                column: "CustomerID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TestDrive");

            migrationBuilder.DropTable(
                name: "Customer");
        }
    }
}
