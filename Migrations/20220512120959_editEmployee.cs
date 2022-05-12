using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DocService.Migrations
{
    public partial class editEmployee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Nurses_LineManagers_MangerId",
                table: "Nurses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LineManagers",
                table: "LineManagers");

            migrationBuilder.DropColumn(
                name: "ManagerId",
                table: "Nurses");

            migrationBuilder.RenameTable(
                name: "LineManagers",
                newName: "LineMaLnagers");

            migrationBuilder.RenameColumn(
                name: "MangerId",
                table: "Nurses",
                newName: "LineManagerId");

            migrationBuilder.RenameIndex(
                name: "IX_Nurses_MangerId",
                table: "Nurses",
                newName: "IX_Nurses_LineManagerId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameColumn(
                name: "LineManagerId",
                table: "Nurses",
                newName: "MangerId");

            migrationBuilder.RenameIndex(
                name: "IX_Nurses_LineManagerId",
                table: "Nurses",
                newName: "IX_Nurses_MangerId");

            migrationBuilder.AddColumn<int>(
                name: "ManagerId",
                table: "Nurses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_LineManagers",
                table: "LineManagers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Nurses_LineManagers_MangerId",
                table: "Nurses",
                column: "MangerId",
                principalTable: "LineManagers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
