using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    public partial class DepartmentRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cities_departments_DepartmentDeparmentCode",
                table: "cities");

            migrationBuilder.DropIndex(
                name: "IX_cities_DepartmentDeparmentCode",
                table: "cities");

            migrationBuilder.DropColumn(
                name: "DepartmentDeparmentCode",
                table: "cities");

            migrationBuilder.RenameColumn(
                name: "DepartmentCode",
                table: "cities",
                newName: "department_code");

            migrationBuilder.AlterColumn<string>(
                name: "department_code",
                table: "cities",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_cities_department_code",
                table: "cities",
                column: "department_code");

            migrationBuilder.AddForeignKey(
                name: "FK_cities_departments_department_code",
                table: "cities",
                column: "department_code",
                principalTable: "departments",
                principalColumn: "department_code",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cities_departments_department_code",
                table: "cities");

            migrationBuilder.DropIndex(
                name: "IX_cities_department_code",
                table: "cities");

            migrationBuilder.RenameColumn(
                name: "department_code",
                table: "cities",
                newName: "DepartmentCode");

            migrationBuilder.AlterColumn<string>(
                name: "DepartmentCode",
                table: "cities",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "DepartmentDeparmentCode",
                table: "cities",
                type: "varchar(255)",
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_cities_DepartmentDeparmentCode",
                table: "cities",
                column: "DepartmentDeparmentCode");

            migrationBuilder.AddForeignKey(
                name: "FK_cities_departments_DepartmentDeparmentCode",
                table: "cities",
                column: "DepartmentDeparmentCode",
                principalTable: "departments",
                principalColumn: "department_code",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
