using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedSuperAdmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Email", "IdentityCard", "IsActive", "Password", "PhoneNumber", "Role", "UserName" },
                values: new object[] { new Guid("a1b2c3d4-e5f6-4a5b-8c9d-0e1f2a3b4c5d"), "hungvd18@gmail.com", "012345667899", true, "$2a$11$JdYSVNQ6sh41E5eHTaC4Vu6M6dSiusX2NKc2/W7FN.oFkzjyLQnnu", "0826078586", "SuperAdmin", "Hưng" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("a1b2c3d4-e5f6-4a5b-8c9d-0e1f2a3b4c5d"));
        }
    }
}
