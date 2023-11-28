using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_Proyecto3.Migrations
{
    public partial class APIDBv3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TarifaHora",
                table: "Tiquete",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TarifaMediaHora",
                table: "Tiquete",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TarifaHora",
                table: "Tiquete");

            migrationBuilder.DropColumn(
                name: "TarifaMediaHora",
                table: "Tiquete");
        }
    }
}
