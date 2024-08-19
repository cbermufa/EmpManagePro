using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmpManagePro.Migrations
{
    /// <inheritdoc />
    public partial class AgregarTablasNomina : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropColumn(
            //    name: "FechaFin",
            //    table: "Turnos");

            //migrationBuilder.DropColumn(
            //    name: "FechaInicio",
            //    table: "Turnos");

            migrationBuilder.AddColumn<string>(
                name: "BonificacionesID",
                table: "Empleados",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "[]");

            migrationBuilder.AddColumn<string>(
                name: "DeduccionesID",
                table: "Empleados",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "[]");

            migrationBuilder.AddColumn<int>(
                name: "PuestoID",
                table: "Empleados",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Bonificacion",
                columns: table => new
                {
                    BonificacionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Monto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EmpleadoID = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bonificacion", x => x.BonificacionID);
                    table.ForeignKey(
                        name: "FK_Bonificacion_Empleados_EmpleadoID",
                        column: x => x.EmpleadoID,
                        principalTable: "Empleados",
                        principalColumn: "EmpleadoID");
                });

            migrationBuilder.CreateTable(
                name: "Deduccion",
                columns: table => new
                {
                    DeduccionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Porcentaje = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EmpleadoID = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deduccion", x => x.DeduccionID);
                    table.ForeignKey(
                        name: "FK_Deduccion_Empleados_EmpleadoID",
                        column: x => x.EmpleadoID,
                        principalTable: "Empleados",
                        principalColumn: "EmpleadoID");
                });

            migrationBuilder.CreateTable(
                name: "Puesto",
                columns: table => new
                {
                    PuestoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Salario = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Puesto", x => x.PuestoID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Empleados_PuestoID",
                table: "Empleados",
                column: "PuestoID");

            migrationBuilder.CreateIndex(
                name: "IX_Bonificacion_EmpleadoID",
                table: "Bonificacion",
                column: "EmpleadoID");

            migrationBuilder.CreateIndex(
                name: "IX_Deduccion_EmpleadoID",
                table: "Deduccion",
                column: "EmpleadoID");

            migrationBuilder.AddForeignKey(
                name: "FK_Empleados_Puesto_PuestoID",
                table: "Empleados",
                column: "PuestoID",
                principalTable: "Puesto",
                principalColumn: "PuestoID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Empleados_Puesto_PuestoID",
                table: "Empleados");

            migrationBuilder.DropTable(
                name: "Bonificacion");

            migrationBuilder.DropTable(
                name: "Deduccion");

            migrationBuilder.DropTable(
                name: "Puesto");

            migrationBuilder.DropIndex(
                name: "IX_Empleados_PuestoID",
                table: "Empleados");

            migrationBuilder.DropColumn(
                name: "BonificacionesID",
                table: "Empleados");

            migrationBuilder.DropColumn(
                name: "DeduccionesID",
                table: "Empleados");

            migrationBuilder.DropColumn(
                name: "PuestoID",
                table: "Empleados");

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaFin",
                table: "Turnos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaInicio",
                table: "Turnos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
