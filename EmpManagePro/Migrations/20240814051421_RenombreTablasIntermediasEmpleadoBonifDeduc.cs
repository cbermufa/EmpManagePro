using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmpManagePro.Migrations
{
    /// <inheritdoc />
    public partial class RenombreTablasIntermediasEmpleadoBonifDeduc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Bonificacion_Empleados_EmpleadoID",
            //    table: "Bonificacion");

            //migrationBuilder.DropTable(
            //    name: "DeduccionEmpleado");

            //migrationBuilder.DropTable(
            //    name: "EmpleadoBonificaciones");

            //migrationBuilder.DropTable(
            //    name: "EmpleadoDeducciones");

            //migrationBuilder.DropIndex(
            //    name: "IX_Bonificacion_EmpleadoID",
            //    table: "Bonificacion");

            //migrationBuilder.DropColumn(
            //    name: "BonificacionesID",
            //    table: "Empleados");

            //migrationBuilder.DropColumn(
            //    name: "EmpleadoID",
            //    table: "Bonificacion");

            migrationBuilder.CreateTable(
                name: "EmpleadosBonificaciones",
                columns: table => new
                {
                    EmpleadoID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BonificacionID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpleadosBonificaciones", x => new { x.EmpleadoID, x.BonificacionID });
                    table.ForeignKey(
                        name: "FK_EmpleadosBonificaciones_Bonificacion_BonificacionID",
                        column: x => x.BonificacionID,
                        principalTable: "Bonificacion",
                        principalColumn: "BonificacionID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmpleadosBonificaciones_Empleados_EmpleadoID",
                        column: x => x.EmpleadoID,
                        principalTable: "Empleados",
                        principalColumn: "EmpleadoID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmpleadosDeducciones",
                columns: table => new
                {
                    EmpleadoID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DeduccionID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpleadosDeducciones", x => new { x.EmpleadoID, x.DeduccionID });
                    table.ForeignKey(
                        name: "FK_EmpleadosDeducciones_Deduccion_DeduccionID",
                        column: x => x.DeduccionID,
                        principalTable: "Deduccion",
                        principalColumn: "DeduccionID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmpleadosDeducciones_Empleados_EmpleadoID",
                        column: x => x.EmpleadoID,
                        principalTable: "Empleados",
                        principalColumn: "EmpleadoID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmpleadosBonificaciones_BonificacionID",
                table: "EmpleadosBonificaciones",
                column: "BonificacionID");

            migrationBuilder.CreateIndex(
                name: "IX_EmpleadosDeducciones_DeduccionID",
                table: "EmpleadosDeducciones",
                column: "DeduccionID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmpleadosBonificaciones");

            migrationBuilder.DropTable(
                name: "EmpleadosDeducciones");

            migrationBuilder.AddColumn<string>(
                name: "BonificacionesID",
                table: "Empleados",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EmpleadoID",
                table: "Bonificacion",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DeduccionEmpleado",
                columns: table => new
                {
                    DeduccionesDeduccionID = table.Column<int>(type: "int", nullable: false),
                    EmpleadosEmpleadoID = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeduccionEmpleado", x => new { x.DeduccionesDeduccionID, x.EmpleadosEmpleadoID });
                    table.ForeignKey(
                        name: "FK_DeduccionEmpleado_Deduccion_DeduccionesDeduccionID",
                        column: x => x.DeduccionesDeduccionID,
                        principalTable: "Deduccion",
                        principalColumn: "DeduccionID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DeduccionEmpleado_Empleados_EmpleadosEmpleadoID",
                        column: x => x.EmpleadosEmpleadoID,
                        principalTable: "Empleados",
                        principalColumn: "EmpleadoID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmpleadoBonificaciones",
                columns: table => new
                {
                    EmpleadoID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BonificacionID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpleadoBonificaciones", x => new { x.EmpleadoID, x.BonificacionID });
                    table.ForeignKey(
                        name: "FK_EmpleadoBonificaciones_Bonificacion_BonificacionID",
                        column: x => x.BonificacionID,
                        principalTable: "Bonificacion",
                        principalColumn: "BonificacionID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmpleadoBonificaciones_Empleados_EmpleadoID",
                        column: x => x.EmpleadoID,
                        principalTable: "Empleados",
                        principalColumn: "EmpleadoID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmpleadoDeducciones",
                columns: table => new
                {
                    EmpleadoID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DeduccionID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpleadoDeducciones", x => new { x.EmpleadoID, x.DeduccionID });
                    table.ForeignKey(
                        name: "FK_EmpleadoDeducciones_Deduccion_DeduccionID",
                        column: x => x.DeduccionID,
                        principalTable: "Deduccion",
                        principalColumn: "DeduccionID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmpleadoDeducciones_Empleados_EmpleadoID",
                        column: x => x.EmpleadoID,
                        principalTable: "Empleados",
                        principalColumn: "EmpleadoID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bonificacion_EmpleadoID",
                table: "Bonificacion",
                column: "EmpleadoID");

            migrationBuilder.CreateIndex(
                name: "IX_DeduccionEmpleado_EmpleadosEmpleadoID",
                table: "DeduccionEmpleado",
                column: "EmpleadosEmpleadoID");

            migrationBuilder.CreateIndex(
                name: "IX_EmpleadoBonificaciones_BonificacionID",
                table: "EmpleadoBonificaciones",
                column: "BonificacionID");

            migrationBuilder.CreateIndex(
                name: "IX_EmpleadoDeducciones_DeduccionID",
                table: "EmpleadoDeducciones",
                column: "DeduccionID");

            migrationBuilder.AddForeignKey(
                name: "FK_Bonificacion_Empleados_EmpleadoID",
                table: "Bonificacion",
                column: "EmpleadoID",
                principalTable: "Empleados",
                principalColumn: "EmpleadoID");
        }
    }
}
