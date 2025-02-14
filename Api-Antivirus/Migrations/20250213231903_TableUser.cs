using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api_Antivirus.Migrations
{
    /// <inheritdoc />
    public partial class TableUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OpportunityInstitutions_Opportunities_OpportunityId",
                table: "OpportunityInstitutions");

            migrationBuilder.DropForeignKey(
                name: "FK_UserOpportunities_Opportunities_OpportunityId",
                table: "UserOpportunities");

            migrationBuilder.DropIndex(
                name: "IX_UserOpportunities_OpportunityId",
                table: "UserOpportunities");

            migrationBuilder.RenameColumn(
                name: "Role",
                table: "Users",
                newName: "Password_Confirmation");

            migrationBuilder.AddColumn<DateTime>(
                name: "Birthdate",
                table: "Users",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Last_Name",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "UserOpportunitiesOpportunityId",
                table: "UserOpportunities",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserOpportunitiesUserId",
                table: "UserOpportunities",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OpportunityInstitutionsInstitutionId",
                table: "OpportunityInstitutions",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OpportunityInstitutionsOpportunityId",
                table: "OpportunityInstitutions",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_UserOpportunities_UserOpportunitiesUserId_UserOpportunities~",
                table: "UserOpportunities",
                columns: new[] { "UserOpportunitiesUserId", "UserOpportunitiesOpportunityId" });

            migrationBuilder.CreateIndex(
                name: "IX_OpportunityInstitutions_OpportunityInstitutionsOpportunityI~",
                table: "OpportunityInstitutions",
                columns: new[] { "OpportunityInstitutionsOpportunityId", "OpportunityInstitutionsInstitutionId" });

            migrationBuilder.AddForeignKey(
                name: "FK_OpportunityInstitutions_OpportunityInstitutions_Opportunity~",
                table: "OpportunityInstitutions",
                columns: new[] { "OpportunityInstitutionsOpportunityId", "OpportunityInstitutionsInstitutionId" },
                principalTable: "OpportunityInstitutions",
                principalColumns: new[] { "OpportunityId", "InstitutionId" },
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserOpportunities_UserOpportunities_UserOpportunitiesUserId~",
                table: "UserOpportunities",
                columns: new[] { "UserOpportunitiesUserId", "UserOpportunitiesOpportunityId" },
                principalTable: "UserOpportunities",
                principalColumns: new[] { "UserId", "OpportunityId" },
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OpportunityInstitutions_OpportunityInstitutions_Opportunity~",
                table: "OpportunityInstitutions");

            migrationBuilder.DropForeignKey(
                name: "FK_UserOpportunities_UserOpportunities_UserOpportunitiesUserId~",
                table: "UserOpportunities");

            migrationBuilder.DropIndex(
                name: "IX_UserOpportunities_UserOpportunitiesUserId_UserOpportunities~",
                table: "UserOpportunities");

            migrationBuilder.DropIndex(
                name: "IX_OpportunityInstitutions_OpportunityInstitutionsOpportunityI~",
                table: "OpportunityInstitutions");

            migrationBuilder.DropColumn(
                name: "Birthdate",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Last_Name",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserOpportunitiesOpportunityId",
                table: "UserOpportunities");

            migrationBuilder.DropColumn(
                name: "UserOpportunitiesUserId",
                table: "UserOpportunities");

            migrationBuilder.DropColumn(
                name: "OpportunityInstitutionsInstitutionId",
                table: "OpportunityInstitutions");

            migrationBuilder.DropColumn(
                name: "OpportunityInstitutionsOpportunityId",
                table: "OpportunityInstitutions");

            migrationBuilder.RenameColumn(
                name: "Password_Confirmation",
                table: "Users",
                newName: "Role");

            migrationBuilder.CreateIndex(
                name: "IX_UserOpportunities_OpportunityId",
                table: "UserOpportunities",
                column: "OpportunityId");

            migrationBuilder.AddForeignKey(
                name: "FK_OpportunityInstitutions_Opportunities_OpportunityId",
                table: "OpportunityInstitutions",
                column: "OpportunityId",
                principalTable: "Opportunities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserOpportunities_Opportunities_OpportunityId",
                table: "UserOpportunities",
                column: "OpportunityId",
                principalTable: "Opportunities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
