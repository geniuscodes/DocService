using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DocService.Migrations
{
    public partial class eMangersTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Nurses_LineMaLnagers_LineManagerId",
                table: "Nurses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LineMaLnagers",
                table: "LineMaLnagers");

            migrationBuilder.RenameTable(
                name: "LineMaLnagers",
                newName: "LineManagers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LineManagers",
                table: "LineManagers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Nurses_LineManagers_LineManagerId",
                table: "Nurses",
                column: "LineManagerId",
                principalTable: "LineManagers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Nurses_LineManagers_LineManagerId",
                table: "Nurses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LineManagers",
                table: "LineManagers");

            migrationBuilder.RenameTable(
                name: "LineManagers",
                newName: "LineMaLnagers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LineMaLnagers",
                table: "LineMaLnagers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Nurses_LineMaLnagers_LineManagerId",
                table: "Nurses",
                column: "LineManagerId",
                principalTable: "LineMaLnagers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
