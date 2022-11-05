using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Company_CRM.Migrations
{
    public partial class JobsPriority : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Hired",
                table: "employee",
                newName: "hired");

            migrationBuilder.AddColumn<string>(
                name: "Prior",
                table: "jobs",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<DateTime>(
                name: "hired",
                table: "employee",
                type: "timestamp",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Prior",
                table: "jobs");

            migrationBuilder.RenameColumn(
                name: "hired",
                table: "employee",
                newName: "Hired");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Hired",
                table: "employee",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp");
        }
    }
}
