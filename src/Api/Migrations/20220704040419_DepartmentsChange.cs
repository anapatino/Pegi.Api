using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    public partial class DepartmentsChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cities_departments_department_code",
                table: "cities");

            migrationBuilder.RenameColumn(
                name: "department_code",
                table: "cities",
                newName: "DepartmentCode");

            migrationBuilder.RenameIndex(
                name: "IX_cities_department_code",
                table: "cities",
                newName: "IX_cities_DepartmentCode");

            migrationBuilder.AddForeignKey(
                name: "FK_cities_departments_DepartmentCode",
                table: "cities",
                column: "DepartmentCode",
                principalTable: "departments",
                principalColumn: "department_code",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cities_departments_DepartmentCode",
                table: "cities");

            migrationBuilder.RenameColumn(
                name: "DepartmentCode",
                table: "cities",
                newName: "department_code");

            migrationBuilder.RenameIndex(
                name: "IX_cities_DepartmentCode",
                table: "cities",
                newName: "IX_cities_department_code");

            migrationBuilder.AddForeignKey(
                name: "FK_cities_departments_department_code",
                table: "cities",
                column: "department_code",
                principalTable: "departments",
                principalColumn: "department_code",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
