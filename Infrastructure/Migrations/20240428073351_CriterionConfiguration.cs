using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CriterionConfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PositionCriteria_Criteria_CriterionId",
                table: "PositionCriteria");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainingMark_Criteria_CriterionId",
                table: "TrainingMark");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Criteria",
                table: "Criteria");

            migrationBuilder.RenameTable(
                name: "Criteria",
                newName: "Criterion");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Criterion",
                table: "Criterion",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PositionCriteria_Criterion_CriterionId",
                table: "PositionCriteria",
                column: "CriterionId",
                principalTable: "Criterion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingMark_Criterion_CriterionId",
                table: "TrainingMark",
                column: "CriterionId",
                principalTable: "Criterion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PositionCriteria_Criterion_CriterionId",
                table: "PositionCriteria");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainingMark_Criterion_CriterionId",
                table: "TrainingMark");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Criterion",
                table: "Criterion");

            migrationBuilder.RenameTable(
                name: "Criterion",
                newName: "Criteria");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Criteria",
                table: "Criteria",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PositionCriteria_Criteria_CriterionId",
                table: "PositionCriteria",
                column: "CriterionId",
                principalTable: "Criteria",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingMark_Criteria_CriterionId",
                table: "TrainingMark",
                column: "CriterionId",
                principalTable: "Criteria",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
