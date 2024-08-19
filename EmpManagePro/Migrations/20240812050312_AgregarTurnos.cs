using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmpManagePro.Migrations
{
    /// <inheritdoc />
    public partial class AgregarTurnos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropColumn(
            //    name: "Rol",
            //    table: "Empleados");

            //migrationBuilder.AddColumn<string>(
            //    name: "RoleId",
            //    table: "Empleados",
            //    type: "nvarchar(450)",
            //    nullable: false,
            //    defaultValue: "");

            //migrationBuilder.AddColumn<string>(
            //    name: "EmpleadoID",
            //    table: "AspNetUsers",
            //    type: "nvarchar(450)",
            //    nullable: true);

            migrationBuilder.CreateTable(
                name: "Turnos",
                columns: table => new
                {
                    TurnoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaFin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TipoTurno = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turnos", x => x.TurnoID);
                });

            migrationBuilder.CreateTable(
                name: "TurnoEmpleados",
                columns: table => new
                {
                    TurnoEmpleadoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpleadoID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TurnoID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TurnoEmpleados", x => x.TurnoEmpleadoID);
                    table.ForeignKey(
                        name: "FK_TurnoEmpleados_Empleados_EmpleadoID",
                        column: x => x.EmpleadoID,
                        principalTable: "Empleados",
                        principalColumn: "EmpleadoID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TurnoEmpleados_Turnos_TurnoID",
                        column: x => x.TurnoID,
                        principalTable: "Turnos",
                        principalColumn: "TurnoID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Empleados_RoleId",
                table: "Empleados",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_EmpleadoID",
                table: "AspNetUsers",
                column: "EmpleadoID",
                unique: true,
                filter: "[EmpleadoID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_TurnoEmpleados_EmpleadoID",
                table: "TurnoEmpleados",
                column: "EmpleadoID");

            migrationBuilder.CreateIndex(
                name: "IX_TurnoEmpleados_TurnoID",
                table: "TurnoEmpleados",
                column: "TurnoID");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Empleados_EmpleadoID",
                table: "AspNetUsers",
                column: "EmpleadoID",
                principalTable: "Empleados",
                principalColumn: "EmpleadoID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Empleados_AspNetRoles_RoleId",
                table: "Empleados",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Empleados_EmpleadoID",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Empleados_AspNetRoles_RoleId",
                table: "Empleados");

            migrationBuilder.DropTable(
                name: "TurnoEmpleados");

            migrationBuilder.DropTable(
                name: "Turnos");

            migrationBuilder.DropIndex(
                name: "IX_Empleados_RoleId",
                table: "Empleados");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_EmpleadoID",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "Empleados");

            migrationBuilder.DropColumn(
                name: "EmpleadoID",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "Rol",
                table: "Empleados",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
