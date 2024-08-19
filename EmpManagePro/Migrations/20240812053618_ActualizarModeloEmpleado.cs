using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmpManagePro.Migrations
{
    /// <inheritdoc />
    public partial class ActualizarModeloEmpleado : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ConfirmPassword",
                table: "Empleados",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Empleados",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConfirmPassword",
                table: "Empleados");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Empleados");
        }
    }
}
