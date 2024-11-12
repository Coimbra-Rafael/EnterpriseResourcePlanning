using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EnterpriseResourcePlanning.Api.Migrations
{
    /// <inheritdoc />
    public partial class CorrectionTableEnterprise : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enterprises_Customers_CustomerId1",
                table: "Enterprises");

            migrationBuilder.DropIndex(
                name: "IX_Enterprises_CustomerId1",
                table: "Enterprises");

            migrationBuilder.DropColumn(
                name: "CustomerId1",
                table: "Enterprises");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CustomerId1",
                table: "Enterprises",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.CreateIndex(
                name: "IX_Enterprises_CustomerId1",
                table: "Enterprises",
                column: "CustomerId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Enterprises_Customers_CustomerId1",
                table: "Enterprises",
                column: "CustomerId1",
                principalTable: "Customers",
                principalColumn: "CustomerId");
        }
    }
}
