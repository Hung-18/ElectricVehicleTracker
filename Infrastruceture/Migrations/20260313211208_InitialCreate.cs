using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ElectricVehicleTypes",
                columns: table => new
                {
                    ElectricVehicleTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TypeName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElectricVehicleTypes", x => x.ElectricVehicleTypeId);
                });

            migrationBuilder.CreateTable(
                name: "ReplacementParts",
                columns: table => new
                {
                    PartId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PartName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReplacementParts", x => x.PartId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdentityCard = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "AuditLogs",
                columns: table => new
                {
                    LogId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Action = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditLogs", x => x.LogId);
                    table.ForeignKey(
                        name: "FK_AuditLogs_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ElectricVehicles",
                columns: table => new
                {
                    ElectricVehicleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Year = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BatteryCapacity = table.Column<double>(type: "float", nullable: false),
                    RangePerCharge = table.Column<double>(type: "float", nullable: false),
                    ChargingTime = table.Column<double>(type: "float", nullable: false),
                    StateOfHealth = table.Column<int>(type: "int", nullable: false),
                    CurrentOdometer = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElectricVehicles", x => x.ElectricVehicleId);
                    table.ForeignKey(
                        name: "FK_ElectricVehicles_ElectricVehicleTypes_TypeId",
                        column: x => x.TypeId,
                        principalTable: "ElectricVehicleTypes",
                        principalColumn: "ElectricVehicleTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ElectricVehicles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RepairHistories",
                columns: table => new
                {
                    RepairId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ElectricVehicleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RepairDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RepairHistories", x => x.RepairId);
                    table.ForeignKey(
                        name: "FK_RepairHistories_ElectricVehicles_ElectricVehicleId",
                        column: x => x.ElectricVehicleId,
                        principalTable: "ElectricVehicles",
                        principalColumn: "ElectricVehicleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    PaymentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RepairId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.PaymentId);
                    table.ForeignKey(
                        name: "FK_Payments_RepairHistories_RepairId",
                        column: x => x.RepairId,
                        principalTable: "RepairHistories",
                        principalColumn: "RepairId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RepairHistoryParts",
                columns: table => new
                {
                    RepairPartId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RepairId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PartId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RepairHistoryParts", x => x.RepairPartId);
                    table.ForeignKey(
                        name: "FK_RepairHistoryParts_RepairHistories_RepairId",
                        column: x => x.RepairId,
                        principalTable: "RepairHistories",
                        principalColumn: "RepairId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RepairHistoryParts_ReplacementParts_PartId",
                        column: x => x.PartId,
                        principalTable: "ReplacementParts",
                        principalColumn: "PartId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuditLogs_UserId",
                table: "AuditLogs",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ElectricVehicles_TypeId",
                table: "ElectricVehicles",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ElectricVehicles_UserId",
                table: "ElectricVehicles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_RepairId",
                table: "Payments",
                column: "RepairId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RepairHistories_ElectricVehicleId",
                table: "RepairHistories",
                column: "ElectricVehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_RepairHistoryParts_PartId",
                table: "RepairHistoryParts",
                column: "PartId");

            migrationBuilder.CreateIndex(
                name: "IX_RepairHistoryParts_RepairId",
                table: "RepairHistoryParts",
                column: "RepairId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuditLogs");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "RepairHistoryParts");

            migrationBuilder.DropTable(
                name: "RepairHistories");

            migrationBuilder.DropTable(
                name: "ReplacementParts");

            migrationBuilder.DropTable(
                name: "ElectricVehicles");

            migrationBuilder.DropTable(
                name: "ElectricVehicleTypes");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
