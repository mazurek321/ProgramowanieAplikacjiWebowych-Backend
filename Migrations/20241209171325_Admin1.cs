using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace projekt.Migrations
{
    /// <inheritdoc />
    public partial class Admin1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "CreatedAt", "Email", "LastName", "Location", "Name", "Password", "Phone", "PostCode", "Role" },
                values: new object[] { new Guid("9fa77898-78c2-4ba6-9c87-7ae1b8b76bf5"), null, new DateTime(2024, 12, 9, 17, 13, 24, 741, DateTimeKind.Utc).AddTicks(2156), "admin@example.com", "Admin", null, "Admin", "21232F297A57A5A743894A0E4A801FC3", null, null, "admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("9fa77898-78c2-4ba6-9c87-7ae1b8b76bf5"));
        }
    }
}
