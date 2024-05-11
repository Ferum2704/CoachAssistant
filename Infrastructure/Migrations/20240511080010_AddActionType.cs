using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddActionType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActionType",
                table: "MatchPlayerAction");

            migrationBuilder.AddColumn<Guid>(
                name: "ActionTypeId",
                table: "MatchPlayerAction",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<double>(
                name: "Score",
                table: "MatchLineupPositionPlayer",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateTable(
                name: "ActionType",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BenchmarkValue = table.Column<double>(type: "float", nullable: false),
                    IsHigherPreferable = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActionType", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MatchPlayerAction_ActionTypeId",
                table: "MatchPlayerAction",
                column: "ActionTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_MatchPlayerAction_ActionType_ActionTypeId",
                table: "MatchPlayerAction",
                column: "ActionTypeId",
                principalTable: "ActionType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MatchPlayerAction_ActionType_ActionTypeId",
                table: "MatchPlayerAction");

            migrationBuilder.DropTable(
                name: "ActionType");

            migrationBuilder.DropIndex(
                name: "IX_MatchPlayerAction_ActionTypeId",
                table: "MatchPlayerAction");

            migrationBuilder.DropColumn(
                name: "ActionTypeId",
                table: "MatchPlayerAction");

            migrationBuilder.DropColumn(
                name: "Score",
                table: "MatchLineupPositionPlayer");

            migrationBuilder.AddColumn<string>(
                name: "ActionType",
                table: "MatchPlayerAction",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
