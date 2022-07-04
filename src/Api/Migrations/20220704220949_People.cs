using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    public partial class People : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_people_cities_city_code",
                table: "people");

            migrationBuilder.DropForeignKey(
                name: "fk_people_departments_department_code",
                table: "people");

            migrationBuilder.DropIndex(
                name: "ix_people_department_code",
                table: "people");

            migrationBuilder.DropColumn(
                name: "department_code",
                table: "people");

            migrationBuilder.RenameColumn(
                name: "person_placeBirth",
                table: "people",
                newName: "person_birthPlace");

            migrationBuilder.RenameColumn(
                name: "person_dateBirth",
                table: "people",
                newName: "person_birthDate");

            migrationBuilder.UpdateData(
                table: "people",
                keyColumn: "city_code",
                keyValue: null,
                column: "city_code",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "city_code",
                table: "people",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "person_document",
                table: "people",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddForeignKey(
                name: "fk_people_cities_city_code",
                table: "people",
                column: "city_code",
                principalTable: "cities",
                principalColumn: "city_code",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_people_cities_city_code",
                table: "people");

            migrationBuilder.RenameColumn(
                name: "person_birthPlace",
                table: "people",
                newName: "person_placeBirth");

            migrationBuilder.RenameColumn(
                name: "person_birthDate",
                table: "people",
                newName: "person_dateBirth");

            migrationBuilder.AlterColumn<string>(
                name: "city_code",
                table: "people",
                type: "varchar(255)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<int>(
                name: "person_document",
                table: "people",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "department_code",
                table: "people",
                type: "varchar(255)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "ix_people_department_code",
                table: "people",
                column: "department_code");

            migrationBuilder.AddForeignKey(
                name: "fk_people_cities_city_code",
                table: "people",
                column: "city_code",
                principalTable: "cities",
                principalColumn: "city_code");

            migrationBuilder.AddForeignKey(
                name: "fk_people_departments_department_code",
                table: "people",
                column: "department_code",
                principalTable: "departments",
                principalColumn: "department_code");
        }
    }
}
