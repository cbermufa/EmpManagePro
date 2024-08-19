using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmpManagePro.Migrations
{
    /// <inheritdoc />
    public partial class AddEvaluacionRendimiento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EvaluacionesRendimiento",
                columns: table => new
                {
                    EvaluacionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpleadoID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Objetivos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Seguimiento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Retroalimentacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaReunion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EvaluacionesRendimiento", x => x.EvaluacionID);
                    table.ForeignKey(
                        name: "FK_EvaluacionesRendimiento_Empleados_EmpleadoID",
                        column: x => x.EmpleadoID,
                        principalTable: "Empleados",
                        principalColumn: "EmpleadoID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EvaluacionesRendimiento_EmpleadoID",
                table: "EvaluacionesRendimiento",
                column: "EmpleadoID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EvaluacionesRendimiento");
        }
    }
}
