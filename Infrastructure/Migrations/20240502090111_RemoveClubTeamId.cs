using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemoveClubTeamId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8e9c9c27-42f0-43e3-8371-caca6737a15c"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("9039ff29-cfdc-49e6-ac97-3a7953174d33"));

            migrationBuilder.DropColumn(
                name: "TeamId",
                table: "Club");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("0b34bba2-3bd2-4463-856e-f7ee3643b7ad"), "1", "Manager", "Manager" },
                    { new Guid("6a52c7de-36e9-46d1-9a20-27b346aaa0d4"), "2", "Coach", "Coach" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("0b34bba2-3bd2-4463-856e-f7ee3643b7ad"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("6a52c7de-36e9-46d1-9a20-27b346aaa0d4"));

            migrationBuilder.AddColumn<Guid>(
                name: "TeamId",
                table: "Club",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("8e9c9c27-42f0-43e3-8371-caca6737a15c"), "1", "Manager", "Manager" },
                    { new Guid("9039ff29-cfdc-49e6-ac97-3a7953174d33"), "2", "Coach", "Coach" }
                });
        }
    }
}
