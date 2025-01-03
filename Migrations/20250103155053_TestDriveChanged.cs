using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MelisaIuliaProiect.Migrations
{
    /// <inheritdoc />
    public partial class TestDriveChanged : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CarID",
                table: "TestDrive");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CarID",
                table: "TestDrive",
                type: "int",
                nullable: true);
        }
    }
}
