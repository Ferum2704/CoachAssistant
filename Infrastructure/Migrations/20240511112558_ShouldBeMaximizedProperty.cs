using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ShouldBeMaximizedProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsHigherPreferable",
                table: "ActionType");

            migrationBuilder.AddColumn<bool>(
                name: "ShouldBeMaximized",
                table: "Criterion",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShouldBeMaximized",
                table: "Criterion");

            migrationBuilder.AddColumn<bool>(
                name: "IsHigherPreferable",
                table: "ActionType",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
