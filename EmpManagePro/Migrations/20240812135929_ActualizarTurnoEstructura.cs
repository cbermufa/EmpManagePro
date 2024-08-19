using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmpManagePro.Migrations
{
    /// <inheritdoc />
    public partial class ActualizarTurnoEstructura : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Eliminar las columnas antiguas
            migrationBuilder.DropColumn(
                name: "FechaInicio",
                table: "Turnos");

            migrationBuilder.DropColumn(
                name: "FechaFin",
                table: "Turnos");

            migrationBuilder.AddColumn<int>(
                name: "CantHoras",
                table: "Turnos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "DiasSeleccionados",
                table: "Turnos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "HoraEntrada",
                table: "Turnos",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "HoraSalida",
                table: "Turnos",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CantHoras",
                table: "Turnos");

            migrationBuilder.DropColumn(
                name: "DiasSeleccionados",
                table: "Turnos");

            migrationBuilder.DropColumn(
                name: "HoraEntrada",
                table: "Turnos");

            migrationBuilder.DropColumn(
                name: "HoraSalida",
                table: "Turnos");
        }
    }
}
