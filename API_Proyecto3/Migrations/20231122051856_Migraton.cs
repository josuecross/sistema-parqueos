using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_Proyecto3.Migrations
{
    public partial class Migraton : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Parqueo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaxVehiculos = table.Column<int>(type: "int", nullable: false),
                    HoraApertura = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HoraCierre = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalVendido = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parqueo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Empleado",
                columns: table => new
                {
                    EmpleadoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ingreso = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellidos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NumCedula = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonaContacto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParqueoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleado", x => x.EmpleadoId);
                    table.ForeignKey(
                        name: "FK_Empleado_Parqueo_ParqueoId",
                        column: x => x.ParqueoId,
                        principalTable: "Parqueo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tiquete",
                columns: table => new
                {
                    TiqueteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ingreso = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Salida = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Placa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TarifaHora = table.Column<int>(type: "int", nullable: false),
                    TarifaMediaHora = table.Column<int>(type: "int", nullable: false),
                    EnUso = table.Column<bool>(type: "bit", nullable: false),
                    Monto_Pagado = table.Column<int>(type: "int", nullable: true),
                    ParqueoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tiquete", x => x.TiqueteId);
                    table.ForeignKey(
                        name: "FK_Tiquete_Parqueo_ParqueoId",
                        column: x => x.ParqueoId,
                        principalTable: "Parqueo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Empleado_ParqueoId",
                table: "Empleado",
                column: "ParqueoId");

            migrationBuilder.CreateIndex(
                name: "IX_Tiquete_ParqueoId",
                table: "Tiquete",
                column: "ParqueoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Empleado");

            migrationBuilder.DropTable(
                name: "Tiquete");

            migrationBuilder.DropTable(
                name: "Parqueo");
        }
    }
}
