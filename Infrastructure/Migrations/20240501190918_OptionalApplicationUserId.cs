using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class OptionalApplicationUserId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DomainUser_AspNetUsers_ApplicationUserId",
                table: "DomainUser");

            migrationBuilder.DropIndex(
                name: "IX_DomainUser_ApplicationUserId",
                table: "DomainUser");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("294b9c01-3082-430c-b043-1b30258246d0"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("7436c1df-e590-41d1-9bed-7ef6ddfb6d34"));

            migrationBuilder.AlterColumn<Guid>(
                name: "ApplicationUserId",
                table: "DomainUser",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("8e9c9c27-42f0-43e3-8371-caca6737a15c"), "1", "Manager", "Manager" },
                    { new Guid("9039ff29-cfdc-49e6-ac97-3a7953174d33"), "2", "Coach", "Coach" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DomainUser_ApplicationUserId",
                table: "DomainUser",
                column: "ApplicationUserId",
                unique: true,
                filter: "[ApplicationUserId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_DomainUser_AspNetUsers_ApplicationUserId",
                table: "DomainUser",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DomainUser_AspNetUsers_ApplicationUserId",
                table: "DomainUser");

            migrationBuilder.DropIndex(
                name: "IX_DomainUser_ApplicationUserId",
                table: "DomainUser");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8e9c9c27-42f0-43e3-8371-caca6737a15c"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("9039ff29-cfdc-49e6-ac97-3a7953174d33"));

            migrationBuilder.AlterColumn<Guid>(
                name: "ApplicationUserId",
                table: "DomainUser",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("294b9c01-3082-430c-b043-1b30258246d0"), "2", "Coach", "Coach" },
                    { new Guid("7436c1df-e590-41d1-9bed-7ef6ddfb6d34"), "1", "Manager", "Manager" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DomainUser_ApplicationUserId",
                table: "DomainUser",
                column: "ApplicationUserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DomainUser_AspNetUsers_ApplicationUserId",
                table: "DomainUser",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
