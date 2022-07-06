using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    public partial class Proposal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_experiences_studies_study_study_code",
                table: "experiences");

            migrationBuilder.RenameColumn(
                name: "study_study_type",
                table: "studies",
                newName: "study_type");

            migrationBuilder.RenameColumn(
                name: "study_study_code",
                table: "studies",
                newName: "study_code");

            migrationBuilder.RenameColumn(
                name: "study_study_code",
                table: "experiences",
                newName: "study_code");

            migrationBuilder.CreateTable(
                name: "cv",
                columns: table => new
                {
                    cv_code = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    cv_attach_files = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cv", x => x.cv_code);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "lines",
                columns: table => new
                {
                    lines_code = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    lines_name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_lines", x => x.lines_code);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "program",
                columns: table => new
                {
                    program_code = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    program_name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_program", x => x.program_code);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "projects",
                columns: table => new
                {
                    project_code = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    project_title = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    project_content = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_projects", x => x.project_code);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "proposal_evaluation",
                columns: table => new
                {
                    proposal_evaluation_code = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    proposal_evaluation_status = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    proposal_evaluation_feedback = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_proposal_evaluation", x => x.proposal_evaluation_code);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "proposals",
                columns: table => new
                {
                    proposals_code = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    proposals_title = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    proposals_date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    proposals_research_group = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    proposals_approach_problem = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    proposals_formulation_problem = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    proposals_justification_problem = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    proposals_general_objective = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    proposals_specific_objective = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    proposals_bibliography = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_proposals", x => x.proposals_code);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "teachers",
                columns: table => new
                {
                    person_document = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    teacher_position = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_people", x => x.person_document);
                    table.ForeignKey(
                        name: "fk_teachers_people_person_document",
                        column: x => x.person_document,
                        principalTable: "people",
                        principalColumn: "person_document",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "sublines",
                columns: table => new
                {
                    sublines_code = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    sublines_name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    line_investigation_code = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_sublines", x => x.sublines_code);
                    table.ForeignKey(
                        name: "fk_sublines_lines_line_investigation_code",
                        column: x => x.line_investigation_code,
                        principalTable: "lines",
                        principalColumn: "lines_code");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "project_evaluation",
                columns: table => new
                {
                    proposal_evaluation_code = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    project_evaluation_qualification = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_proposal_evaluation", x => x.proposal_evaluation_code);
                    table.ForeignKey(
                        name: "fk_project_evaluation_proposal_evaluation_proposal_evaluation_c",
                        column: x => x.proposal_evaluation_code,
                        principalTable: "proposal_evaluation",
                        principalColumn: "proposal_evaluation_code",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "student",
                columns: table => new
                {
                    person_document = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    student_program_code = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    student_credit_number = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    project_code = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    proposal_code = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_people", x => x.person_document);
                    table.ForeignKey(
                        name: "fk_student_people_person_document",
                        column: x => x.person_document,
                        principalTable: "people",
                        principalColumn: "person_document",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_student_projects_project_code",
                        column: x => x.project_code,
                        principalTable: "projects",
                        principalColumn: "project_code");
                    table.ForeignKey(
                        name: "fk_student_proposals_proposal_code",
                        column: x => x.proposal_code,
                        principalTable: "proposals",
                        principalColumn: "proposals_code");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "thematic-areas",
                columns: table => new
                {
                    thematicareas_code = table.Column<string>(name: "thematic-areas_code", type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    thematicareas_name = table.Column<string>(name: "thematic-areas_name", type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    subline_investigation_code = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_thematic_areas", x => x.thematicareas_code);
                    table.ForeignKey(
                        name: "fk_thematic_areas_sublines_subline_investigation_code",
                        column: x => x.subline_investigation_code,
                        principalTable: "sublines",
                        principalColumn: "sublines_code");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "ix_student_project_code",
                table: "student",
                column: "project_code");

            migrationBuilder.CreateIndex(
                name: "ix_student_proposal_code",
                table: "student",
                column: "proposal_code");

            migrationBuilder.CreateIndex(
                name: "ix_sublines_line_investigation_code",
                table: "sublines",
                column: "line_investigation_code");

            migrationBuilder.CreateIndex(
                name: "ix_thematic_areas_subline_investigation_code",
                table: "thematic-areas",
                column: "subline_investigation_code");

            migrationBuilder.AddForeignKey(
                name: "fk_experiences_studies_study_code",
                table: "experiences",
                column: "study_code",
                principalTable: "studies",
                principalColumn: "study_code",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_experiences_studies_study_code",
                table: "experiences");

            migrationBuilder.DropTable(
                name: "cv");

            migrationBuilder.DropTable(
                name: "program");

            migrationBuilder.DropTable(
                name: "project_evaluation");

            migrationBuilder.DropTable(
                name: "student");

            migrationBuilder.DropTable(
                name: "teachers");

            migrationBuilder.DropTable(
                name: "thematic-areas");

            migrationBuilder.DropTable(
                name: "proposal_evaluation");

            migrationBuilder.DropTable(
                name: "projects");

            migrationBuilder.DropTable(
                name: "proposals");

            migrationBuilder.DropTable(
                name: "sublines");

            migrationBuilder.DropTable(
                name: "lines");

            migrationBuilder.RenameColumn(
                name: "study_type",
                table: "studies",
                newName: "study_study_type");

            migrationBuilder.RenameColumn(
                name: "study_code",
                table: "studies",
                newName: "study_study_code");

            migrationBuilder.RenameColumn(
                name: "study_code",
                table: "experiences",
                newName: "study_study_code");

            migrationBuilder.AddForeignKey(
                name: "fk_experiences_studies_study_study_code",
                table: "experiences",
                column: "study_study_code",
                principalTable: "studies",
                principalColumn: "study_study_code",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
