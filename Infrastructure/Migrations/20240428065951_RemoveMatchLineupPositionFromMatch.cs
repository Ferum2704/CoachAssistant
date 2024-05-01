using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemoveMatchLineupPositionFromMatch : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MatchLineupPosition_Match_MatchId",
                table: "MatchLineupPosition");

            migrationBuilder.DropIndex(
                name: "IX_MatchLineupPosition_MatchId",
                table: "MatchLineupPosition");

            migrationBuilder.DropColumn(
                name: "MatchId",
                table: "MatchLineupPosition");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "MatchId",
                table: "MatchLineupPosition",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MatchLineupPosition_MatchId",
                table: "MatchLineupPosition",
                column: "MatchId");

            migrationBuilder.AddForeignKey(
                name: "FK_MatchLineupPosition_Match_MatchId",
                table: "MatchLineupPosition",
                column: "MatchId",
                principalTable: "Match",
                principalColumn: "Id");
        }
    }
}
