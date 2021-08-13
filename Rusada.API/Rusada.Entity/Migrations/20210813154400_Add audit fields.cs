using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Rusada.Entity.Migrations
{
    public partial class Addauditfields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "SightDetails",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "SightDetails",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "Modified",
                table: "SightDetails",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "ModifiedBy",
                table: "SightDetails",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "SightDetails",
                rowVersion: true,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Created",
                table: "SightDetails");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "SightDetails");

            migrationBuilder.DropColumn(
                name: "Modified",
                table: "SightDetails");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "SightDetails");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "SightDetails");
        }
    }
}
