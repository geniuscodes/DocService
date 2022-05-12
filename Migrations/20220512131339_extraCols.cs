using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DocService.Migrations
{
    public partial class extraCols : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Nurses_LineManagers_LineManagerId",
                table: "Nurses");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "LineManagers",
                newName: "Role");

            migrationBuilder.AlterColumn<int>(
                name: "LineManagerId",
                table: "Nurses",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "EmailAddress",
                table: "LineManagers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "LineManagers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "LineManagers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Speciality",
                table: "Doctors",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Doctors",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddForeignKey(
                name: "FK_Nurses_LineManagers_LineManagerId",
                table: "Nurses",
                column: "LineManagerId",
                principalTable: "LineManagers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Nurses_LineManagers_LineManagerId",
                table: "Nurses");

            migrationBuilder.DropColumn(
                name: "EmailAddress",
                table: "LineManagers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "LineManagers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "LineManagers");

            migrationBuilder.RenameColumn(
                name: "Role",
                table: "LineManagers",
                newName: "Name");

            migrationBuilder.AlterColumn<int>(
                name: "LineManagerId",
                table: "Nurses",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Speciality",
                table: "Doctors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Doctors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Nurses_LineManagers_LineManagerId",
                table: "Nurses",
                column: "LineManagerId",
                principalTable: "LineManagers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
