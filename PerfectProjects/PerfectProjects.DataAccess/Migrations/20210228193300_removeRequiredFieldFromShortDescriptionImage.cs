using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PerfectProjects.DataAccess.Migrations
{
    public partial class removeRequiredFieldFromShortDescriptionImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "Image",
                table: "ShortDescriptions",
                type: "varbinary(max)",
                maxLength: 83886080,
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldMaxLength: 83886080);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "Image",
                table: "ShortDescriptions",
                type: "varbinary(max)",
                maxLength: 83886080,
                nullable: false,
                defaultValue: new byte[0],
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldMaxLength: 83886080,
                oldNullable: true);
        }
    }
}
