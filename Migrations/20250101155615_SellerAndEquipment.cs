using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MelisaIuliaProiect.Migrations
{
    /// <inheritdoc />
    public partial class SellerAndEquipment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Equipment",
                table: "Car");

            migrationBuilder.DropColumn(
                name: "Seller",
                table: "Car");

            migrationBuilder.AddColumn<int>(
                name: "EquipmentID",
                table: "Car",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SellerID",
                table: "Car",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Equipment",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EquipmentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Infotainment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Upholstery = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Wheels = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParkingAssist = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipment", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Seller",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SellerName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seller", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Car_EquipmentID",
                table: "Car",
                column: "EquipmentID");

            migrationBuilder.CreateIndex(
                name: "IX_Car_SellerID",
                table: "Car",
                column: "SellerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Car_Equipment_EquipmentID",
                table: "Car",
                column: "EquipmentID",
                principalTable: "Equipment",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Car_Seller_SellerID",
                table: "Car",
                column: "SellerID",
                principalTable: "Seller",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Car_Equipment_EquipmentID",
                table: "Car");

            migrationBuilder.DropForeignKey(
                name: "FK_Car_Seller_SellerID",
                table: "Car");

            migrationBuilder.DropTable(
                name: "Equipment");

            migrationBuilder.DropTable(
                name: "Seller");

            migrationBuilder.DropIndex(
                name: "IX_Car_EquipmentID",
                table: "Car");

            migrationBuilder.DropIndex(
                name: "IX_Car_SellerID",
                table: "Car");

            migrationBuilder.DropColumn(
                name: "EquipmentID",
                table: "Car");

            migrationBuilder.DropColumn(
                name: "SellerID",
                table: "Car");

            migrationBuilder.AddColumn<string>(
                name: "Equipment",
                table: "Car",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Seller",
                table: "Car",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
