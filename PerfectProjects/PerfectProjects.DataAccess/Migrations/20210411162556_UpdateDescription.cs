using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PerfectProjects.DataAccess.Migrations
{
    public partial class UpdateDescription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Descriptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LongDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image1 = table.Column<byte[]>(type: "varbinary(max)", maxLength: 83886080, nullable: true),
                    Image2 = table.Column<byte[]>(type: "varbinary(max)", maxLength: 83886080, nullable: true),
                    Image3 = table.Column<byte[]>(type: "varbinary(max)", maxLength: 83886080, nullable: true),
                    Image4 = table.Column<byte[]>(type: "varbinary(max)", maxLength: 83886080, nullable: true),
                    ShortDescriptionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Descriptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Descriptions_ShortDescriptions_ShortDescriptionId",
                        column: x => x.ShortDescriptionId,
                        principalTable: "ShortDescriptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Descriptions_ShortDescriptionId",
                table: "Descriptions",
                column: "ShortDescriptionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Descriptions");
        }
    }
}
