using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class OneToManyTrainingMarkToCriterion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Criteria_TrainingMark_TrainingMarkId",
                table: "Criteria");

            migrationBuilder.DropIndex(
                name: "IX_Criteria_TrainingMarkId",
                table: "Criteria");

            migrationBuilder.DropColumn(
                name: "TrainingMarkId",
                table: "Criteria");

            migrationBuilder.RenameColumn(
                name: "CriteriaId",
                table: "TrainingMark",
                newName: "CriterionId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingMark_CriterionId",
                table: "TrainingMark",
                column: "CriterionId");

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingMark_Criteria_CriterionId",
                table: "TrainingMark",
                column: "CriterionId",
                principalTable: "Criteria",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrainingMark_Criteria_CriterionId",
                table: "TrainingMark");

            migrationBuilder.DropIndex(
                name: "IX_TrainingMark_CriterionId",
                table: "TrainingMark");

            migrationBuilder.RenameColumn(
                name: "CriterionId",
                table: "TrainingMark",
                newName: "CriteriaId");

            migrationBuilder.AddColumn<Guid>(
                name: "TrainingMarkId",
                table: "Criteria",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Criteria_TrainingMarkId",
                table: "Criteria",
                column: "TrainingMarkId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Criteria_TrainingMark_TrainingMarkId",
                table: "Criteria",
                column: "TrainingMarkId",
                principalTable: "TrainingMark",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
