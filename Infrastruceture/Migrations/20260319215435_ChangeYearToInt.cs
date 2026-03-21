using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeYearToInt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Bước 1: Xóa cột Year cũ đang là DateTime
            migrationBuilder.DropColumn(
                name: "Year",
                table: "ElectricVehicles");

            // Bước 2: Thêm lại cột Year mới là int
            migrationBuilder.AddColumn<int>(
                name: "Year",
                table: "ElectricVehicles",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Ngược lại với Up: Xóa int, thêm lại DateTime
            migrationBuilder.DropColumn(
                name: "Year",
                table: "ElectricVehicles");

            migrationBuilder.AddColumn<DateTime>(
                name: "Year",
                table: "ElectricVehicles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
