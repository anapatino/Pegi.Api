using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    public partial class PeopleLocations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_people_cities_city_code",
                table: "people");

            migrationBuilder.DropColumn(
                name: "person_birthPlace",
                table: "people");

            migrationBuilder.RenameColumn(
                name: "person_secondName",
                table: "people",
                newName: "person_second_name");

            migrationBuilder.RenameColumn(
                name: "person_secondLastName",
                table: "people",
                newName: "person_second_last_name");

            migrationBuilder.RenameColumn(
                name: "person_institutionalMail",
                table: "people",
                newName: "person_institutional_email");

            migrationBuilder.RenameColumn(
                name: "person_firstName",
                table: "people",
                newName: "person_first_name");

            migrationBuilder.RenameColumn(
                name: "person_firstLastName",
                table: "people",
                newName: "person_first_last_name");

            migrationBuilder.RenameColumn(
                name: "person_civilState",
                table: "people",
                newName: "person_civil_state");

            migrationBuilder.RenameColumn(
                name: "person_birthDate",
                table: "people",
                newName: "person_birth_date");

            migrationBuilder.RenameColumn(
                name: "city_code",
                table: "people",
                newName: "country_code");

            migrationBuilder.RenameIndex(
                name: "ix_people_city_code",
                table: "people",
                newName: "ix_people_country_code");

            migrationBuilder.AddForeignKey(
                name: "fk_people_countries_country_code",
                table: "people",
                column: "country_code",
                principalTable: "countries",
                principalColumn: "country_code",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_people_countries_country_code",
                table: "people");

            migrationBuilder.RenameColumn(
                name: "person_second_name",
                table: "people",
                newName: "person_secondName");

            migrationBuilder.RenameColumn(
                name: "person_second_last_name",
                table: "people",
                newName: "person_secondLastName");

            migrationBuilder.RenameColumn(
                name: "person_institutional_email",
                table: "people",
                newName: "person_institutionalMail");

            migrationBuilder.RenameColumn(
                name: "person_first_name",
                table: "people",
                newName: "person_firstName");

            migrationBuilder.RenameColumn(
                name: "person_first_last_name",
                table: "people",
                newName: "person_firstLastName");

            migrationBuilder.RenameColumn(
                name: "person_civil_state",
                table: "people",
                newName: "person_civilState");

            migrationBuilder.RenameColumn(
                name: "person_birth_date",
                table: "people",
                newName: "person_birthDate");

            migrationBuilder.RenameColumn(
                name: "country_code",
                table: "people",
                newName: "city_code");

            migrationBuilder.RenameIndex(
                name: "ix_people_country_code",
                table: "people",
                newName: "ix_people_city_code");

            migrationBuilder.AddColumn<string>(
                name: "person_birthPlace",
                table: "people",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddForeignKey(
                name: "fk_people_cities_city_code",
                table: "people",
                column: "city_code",
                principalTable: "cities",
                principalColumn: "city_code",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
