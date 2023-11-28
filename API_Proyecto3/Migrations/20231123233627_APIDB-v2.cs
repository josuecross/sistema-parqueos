using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_Proyecto3.Migrations
{
    public partial class APIDBv2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TarifaHora",
                table: "Tiquete");

            migrationBuilder.DropColumn(
                name: "TarifaMediaHora",
                table: "Tiquete");

            migrationBuilder.AddColumn<int>(
                name: "TarifaHora",
                table: "Parqueo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TarifaMediaHora",
                table: "Parqueo",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TarifaHora",
                table: "Parqueo");

            migrationBuilder.DropColumn(
                name: "TarifaMediaHora",
                table: "Parqueo");

            migrationBuilder.AddColumn<int>(
                name: "TarifaHora",
                table: "Tiquete",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TarifaMediaHora",
                table: "Tiquete",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
