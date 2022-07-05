using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    public partial class Study : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "person_document",
                table: "users",
                type: "varchar(255)",
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "person_second_name",
                table: "people",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "person_second_last_name",
                table: "people",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "studies",
                columns: table => new
                {
                    study_study_code = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    study_institution = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    city_code = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    study_start_date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    study_end_date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    study_study_type = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    person_document1 = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_studies", x => x.study_study_code);
                    table.ForeignKey(
                        name: "fk_studies_cities_city_code",
                        column: x => x.city_code,
                        principalTable: "cities",
                        principalColumn: "city_code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_studies_people_person_document1",
                        column: x => x.person_document1,
                        principalTable: "people",
                        principalColumn: "person_document");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "experiences",
                columns: table => new
                {
                    study_study_code = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    experience_position = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    person_document = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_studies", x => x.study_study_code);
                    table.ForeignKey(
                        name: "fk_experiences_people_person_document",
                        column: x => x.person_document,
                        principalTable: "people",
                        principalColumn: "person_document");
                    table.ForeignKey(
                        name: "fk_experiences_studies_study_study_code",
                        column: x => x.study_study_code,
                        principalTable: "studies",
                        principalColumn: "study_study_code",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "ix_users_person_document",
                table: "users",
                column: "person_document");

            migrationBuilder.CreateIndex(
                name: "ix_experiences_person_document",
                table: "experiences",
                column: "person_document");

            migrationBuilder.CreateIndex(
                name: "ix_studies_city_code",
                table: "studies",
                column: "city_code");

            migrationBuilder.CreateIndex(
                name: "ix_studies_person_document1",
                table: "studies",
                column: "person_document1");

            migrationBuilder.AddForeignKey(
                name: "fk_users_people_person_document",
                table: "users",
                column: "person_document",
                principalTable: "people",
                principalColumn: "person_document",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_users_people_person_document",
                table: "users");

            migrationBuilder.DropTable(
                name: "experiences");

            migrationBuilder.DropTable(
                name: "studies");

            migrationBuilder.DropIndex(
                name: "ix_users_person_document",
                table: "users");

            migrationBuilder.DropColumn(
                name: "person_document",
                table: "users");

            migrationBuilder.UpdateData(
                table: "people",
                keyColumn: "person_second_name",
                keyValue: null,
                column: "person_second_name",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "person_second_name",
                table: "people",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "people",
                keyColumn: "person_second_last_name",
                keyValue: null,
                column: "person_second_last_name",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "person_second_last_name",
                table: "people",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }
    }
}
