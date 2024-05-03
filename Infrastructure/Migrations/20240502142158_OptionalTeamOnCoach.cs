using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class OptionalTeamOnCoach : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Coach_Team_TeamId",
                table: "Coach");

            migrationBuilder.DropIndex(
                name: "IX_Coach_TeamId",
                table: "Coach");

            migrationBuilder.DropColumn(
                name: "TeamId",
                table: "Coach");

            migrationBuilder.CreateIndex(
                name: "IX_Team_CoachId",
                table: "Team",
                column: "CoachId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Team_Coach_CoachId",
                table: "Team",
                column: "CoachId",
                principalTable: "Coach",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Team_Coach_CoachId",
                table: "Team");

            migrationBuilder.DropIndex(
                name: "IX_Team_CoachId",
                table: "Team");

            migrationBuilder.AddColumn<Guid>(
                name: "TeamId",
                table: "Coach",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Coach_TeamId",
                table: "Coach",
                column: "TeamId",
                unique: true,
                filter: "[TeamId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Coach_Team_TeamId",
                table: "Coach",
                column: "TeamId",
                principalTable: "Team",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
