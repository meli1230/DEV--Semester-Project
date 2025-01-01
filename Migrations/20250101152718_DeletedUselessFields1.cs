using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MelisaIuliaProiect.Migrations
{
    /// <inheritdoc />
    public partial class DeletedUselessFields1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Color",
                table: "Car");

            migrationBuilder.DropColumn(
                name: "ProductionDate",
                table: "Car");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "Car",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "ProductionDate",
                table: "Car",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
