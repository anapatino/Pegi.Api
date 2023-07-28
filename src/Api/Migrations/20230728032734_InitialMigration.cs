using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "academics_program",
                columns: table => new
                {
                    code_program = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_academics_program", x => x.code_program);
                });

            migrationBuilder.CreateTable(
                name: "departments",
                columns: table => new
                {
                    department_id = table.Column<string>(type: "text", nullable: false),
                    deparment_name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_departments", x => x.department_id);
                });

            migrationBuilder.CreateTable(
                name: "message",
                columns: table => new
                {
                    code = table.Column<string>(type: "text", nullable: false),
                    personDocument = table.Column<string>(type: "text", nullable: true),
                    name = table.Column<string>(type: "text", nullable: true),
                    message = table.Column<string>(type: "text", nullable: true),
                    date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_message", x => x.code);
                });

            migrationBuilder.CreateTable(
                name: "porposal_feedback",
                columns: table => new
                {
                    code = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    comment = table.Column<string>(type: "text", nullable: true),
                    status = table.Column<string>(type: "text", nullable: true),
                    date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_porposal_feedback", x => x.code);
                });

            migrationBuilder.CreateTable(
                name: "project_feedbacks",
                columns: table => new
                {
                    code = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    comment = table.Column<string>(type: "text", nullable: true),
                    status = table.Column<string>(type: "text", nullable: true),
                    Score = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_project_feedbacks", x => x.code);
                });

            migrationBuilder.CreateTable(
                name: "research_lines",
                columns: table => new
                {
                    code = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_research_lines", x => x.code);
                });

            migrationBuilder.CreateTable(
                name: "cities",
                columns: table => new
                {
                    city_id = table.Column<string>(type: "text", nullable: false),
                    city_name = table.Column<string>(type: "text", nullable: false),
                    DepartmentCode = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cities", x => x.city_id);
                    table.ForeignKey(
                        name: "FK_cities_departments_DepartmentCode",
                        column: x => x.DepartmentCode,
                        principalTable: "departments",
                        principalColumn: "department_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "research_group",
                columns: table => new
                {
                    code = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    teachers_andscribed = table.Column<string>(type: "text", nullable: false),
                    objetive = table.Column<string>(type: "text", nullable: false),
                    ResearchLineCode = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_research_group", x => x.code);
                    table.ForeignKey(
                        name: "FK_research_group_research_lines_ResearchLineCode",
                        column: x => x.ResearchLineCode,
                        principalTable: "research_lines",
                        principalColumn: "code");
                });

            migrationBuilder.CreateTable(
                name: "research_sublines",
                columns: table => new
                {
                    code = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: true),
                    ResearchLineCode = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_research_sublines", x => x.code);
                    table.ForeignKey(
                        name: "FK_research_sublines_research_lines_ResearchLineCode",
                        column: x => x.ResearchLineCode,
                        principalTable: "research_lines",
                        principalColumn: "code");
                });

            migrationBuilder.CreateTable(
                name: "people",
                columns: table => new
                {
                    document = table.Column<string>(type: "text", nullable: false),
                    person_identification_type = table.Column<string>(type: "text", nullable: false),
                    person_first_name = table.Column<string>(type: "text", nullable: true),
                    person_second_name = table.Column<string>(type: "text", nullable: true),
                    person_first_last_name = table.Column<string>(type: "text", nullable: true),
                    person_second_last_name = table.Column<string>(type: "text", nullable: true),
                    person_civil_state = table.Column<string>(type: "text", nullable: true),
                    person_gender = table.Column<string>(type: "text", nullable: true),
                    person_birth_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    person_phone = table.Column<string>(type: "text", nullable: true),
                    person_institutional_email = table.Column<string>(type: "text", nullable: true),
                    CitiesCode = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_people", x => x.document);
                    table.ForeignKey(
                        name: "FK_people_cities_CitiesCode",
                        column: x => x.CitiesCode,
                        principalTable: "cities",
                        principalColumn: "city_id");
                });

            migrationBuilder.CreateTable(
                name: "thematic_areas",
                columns: table => new
                {
                    code = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: true),
                    ResearchSublineCode = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_thematic_areas", x => x.code);
                    table.ForeignKey(
                        name: "FK_thematic_areas_research_sublines_ResearchSublineCode",
                        column: x => x.ResearchSublineCode,
                        principalTable: "research_sublines",
                        principalColumn: "code");
                });

            migrationBuilder.CreateTable(
                name: "experiences",
                columns: table => new
                {
                    experience_code = table.Column<string>(type: "text", nullable: false),
                    experience_institution = table.Column<string>(type: "text", nullable: false),
                    study_start_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    study_end_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CitiesCode = table.Column<string>(type: "text", nullable: false),
                    PeopleCode = table.Column<string>(type: "text", nullable: false),
                    experience_position = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_experiences", x => x.experience_code);
                    table.ForeignKey(
                        name: "FK_experiences_cities_CitiesCode",
                        column: x => x.CitiesCode,
                        principalTable: "cities",
                        principalColumn: "city_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_experiences_people_PeopleCode",
                        column: x => x.PeopleCode,
                        principalTable: "people",
                        principalColumn: "document",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "professor",
                columns: table => new
                {
                    Document = table.Column<string>(type: "text", nullable: false),
                    position = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_professor", x => x.Document);
                    table.ForeignKey(
                        name: "FK_professor_people_Document",
                        column: x => x.Document,
                        principalTable: "people",
                        principalColumn: "document",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "students",
                columns: table => new
                {
                    Document = table.Column<string>(type: "text", nullable: false),
                    amount_credits = table.Column<string>(type: "text", nullable: true),
                    AcademicProgramCode = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_students", x => x.Document);
                    table.ForeignKey(
                        name: "FK_students_academics_program_AcademicProgramCode",
                        column: x => x.AcademicProgramCode,
                        principalTable: "academics_program",
                        principalColumn: "code_program");
                    table.ForeignKey(
                        name: "FK_students_people_Document",
                        column: x => x.Document,
                        principalTable: "people",
                        principalColumn: "document",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "studies",
                columns: table => new
                {
                    study_code = table.Column<string>(type: "text", nullable: false),
                    study_institution = table.Column<string>(type: "text", nullable: false),
                    study_start_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    study_end_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CitiesCode = table.Column<string>(type: "text", nullable: false),
                    PeopleCode = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_studies", x => x.study_code);
                    table.ForeignKey(
                        name: "FK_studies_cities_CitiesCode",
                        column: x => x.CitiesCode,
                        principalTable: "cities",
                        principalColumn: "city_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_studies_people_PeopleCode",
                        column: x => x.PeopleCode,
                        principalTable: "people",
                        principalColumn: "document",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    user_name = table.Column<string>(type: "text", nullable: false),
                    user_password = table.Column<string>(type: "text", nullable: true),
                    user_rol = table.Column<string>(type: "text", nullable: true),
                    PersonDocument = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.user_name);
                    table.ForeignKey(
                        name: "FK_users_people_PersonDocument",
                        column: x => x.PersonDocument,
                        principalTable: "people",
                        principalColumn: "document");
                });

            migrationBuilder.CreateTable(
                name: "proposals",
                columns: table => new
                {
                    code = table.Column<string>(type: "text", nullable: false),
                    PersonDocument1 = table.Column<string>(type: "text", nullable: true),
                    PersonDocument2 = table.Column<string>(type: "text", nullable: true),
                    EvaluatorDocument = table.Column<string>(type: "text", nullable: true),
                    TutorDocument = table.Column<string>(type: "text", nullable: true),
                    title = table.Column<string>(type: "text", nullable: true),
                    date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    InvestigationGroup = table.Column<string>(type: "text", nullable: true),
                    approach = table.Column<string>(type: "text", nullable: true),
                    justification = table.Column<string>(type: "text", nullable: true),
                    generalObjective = table.Column<string>(type: "text", nullable: true),
                    specificObjective = table.Column<string>(type: "text", nullable: true),
                    biblioGraphical = table.Column<string>(type: "text", nullable: true),
                    status = table.Column<string>(type: "text", nullable: true),
                    ThematicAreaCode = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_proposals", x => x.code);
                    table.ForeignKey(
                        name: "FK_proposals_professor_EvaluatorDocument",
                        column: x => x.EvaluatorDocument,
                        principalTable: "professor",
                        principalColumn: "Document");
                    table.ForeignKey(
                        name: "FK_proposals_professor_TutorDocument",
                        column: x => x.TutorDocument,
                        principalTable: "professor",
                        principalColumn: "Document");
                    table.ForeignKey(
                        name: "FK_proposals_research_group_InvestigationGroup",
                        column: x => x.InvestigationGroup,
                        principalTable: "research_group",
                        principalColumn: "code");
                    table.ForeignKey(
                        name: "FK_proposals_students_PersonDocument1",
                        column: x => x.PersonDocument1,
                        principalTable: "students",
                        principalColumn: "Document");
                    table.ForeignKey(
                        name: "FK_proposals_students_PersonDocument2",
                        column: x => x.PersonDocument2,
                        principalTable: "students",
                        principalColumn: "Document");
                    table.ForeignKey(
                        name: "FK_proposals_thematic_areas_ThematicAreaCode",
                        column: x => x.ThematicAreaCode,
                        principalTable: "thematic_areas",
                        principalColumn: "code");
                });

            migrationBuilder.CreateTable(
                name: "history_proposals",
                columns: table => new
                {
                    code = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PorposalFeedBackCode = table.Column<int>(type: "integer", nullable: true),
                    ProposalCode = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_history_proposals", x => x.code);
                    table.ForeignKey(
                        name: "FK_history_proposals_porposal_feedback_PorposalFeedBackCode",
                        column: x => x.PorposalFeedBackCode,
                        principalTable: "porposal_feedback",
                        principalColumn: "code");
                    table.ForeignKey(
                        name: "FK_history_proposals_proposals_ProposalCode",
                        column: x => x.ProposalCode,
                        principalTable: "proposals",
                        principalColumn: "code");
                });

            migrationBuilder.CreateTable(
                name: "projects",
                columns: table => new
                {
                    code = table.Column<string>(type: "text", nullable: false),
                    PersonDocument1 = table.Column<string>(type: "text", nullable: true),
                    PersonDocument2 = table.Column<string>(type: "text", nullable: true),
                    EvaluatorDocument = table.Column<string>(type: "text", nullable: true),
                    TutorDocument = table.Column<string>(type: "text", nullable: true),
                    Content = table.Column<byte[]>(type: "bytea", nullable: true),
                    Status = table.Column<string>(type: "text", nullable: true),
                    Score = table.Column<int>(type: "integer", nullable: true),
                    ProposalCode = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_projects", x => x.code);
                    table.ForeignKey(
                        name: "FK_projects_professor_EvaluatorDocument",
                        column: x => x.EvaluatorDocument,
                        principalTable: "professor",
                        principalColumn: "Document");
                    table.ForeignKey(
                        name: "FK_projects_professor_TutorDocument",
                        column: x => x.TutorDocument,
                        principalTable: "professor",
                        principalColumn: "Document");
                    table.ForeignKey(
                        name: "FK_projects_proposals_ProposalCode",
                        column: x => x.ProposalCode,
                        principalTable: "proposals",
                        principalColumn: "code");
                    table.ForeignKey(
                        name: "FK_projects_students_PersonDocument1",
                        column: x => x.PersonDocument1,
                        principalTable: "students",
                        principalColumn: "Document");
                    table.ForeignKey(
                        name: "FK_projects_students_PersonDocument2",
                        column: x => x.PersonDocument2,
                        principalTable: "students",
                        principalColumn: "Document");
                });

            migrationBuilder.CreateTable(
                name: "history_projects",
                columns: table => new
                {
                    code = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProjectFeedBackCode = table.Column<int>(type: "integer", nullable: true),
                    ProjectCode = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_history_projects", x => x.code);
                    table.ForeignKey(
                        name: "FK_history_projects_project_feedbacks_ProjectFeedBackCode",
                        column: x => x.ProjectFeedBackCode,
                        principalTable: "project_feedbacks",
                        principalColumn: "code");
                    table.ForeignKey(
                        name: "FK_history_projects_projects_ProjectCode",
                        column: x => x.ProjectCode,
                        principalTable: "projects",
                        principalColumn: "code");
                });

            migrationBuilder.CreateIndex(
                name: "IX_cities_DepartmentCode",
                table: "cities",
                column: "DepartmentCode");

            migrationBuilder.CreateIndex(
                name: "IX_experiences_CitiesCode",
                table: "experiences",
                column: "CitiesCode");

            migrationBuilder.CreateIndex(
                name: "IX_experiences_PeopleCode",
                table: "experiences",
                column: "PeopleCode");

            migrationBuilder.CreateIndex(
                name: "IX_history_projects_ProjectCode",
                table: "history_projects",
                column: "ProjectCode");

            migrationBuilder.CreateIndex(
                name: "IX_history_projects_ProjectFeedBackCode",
                table: "history_projects",
                column: "ProjectFeedBackCode");

            migrationBuilder.CreateIndex(
                name: "IX_history_proposals_PorposalFeedBackCode",
                table: "history_proposals",
                column: "PorposalFeedBackCode");

            migrationBuilder.CreateIndex(
                name: "IX_history_proposals_ProposalCode",
                table: "history_proposals",
                column: "ProposalCode");

            migrationBuilder.CreateIndex(
                name: "IX_people_CitiesCode",
                table: "people",
                column: "CitiesCode");

            migrationBuilder.CreateIndex(
                name: "IX_projects_EvaluatorDocument",
                table: "projects",
                column: "EvaluatorDocument");

            migrationBuilder.CreateIndex(
                name: "IX_projects_PersonDocument1",
                table: "projects",
                column: "PersonDocument1");

            migrationBuilder.CreateIndex(
                name: "IX_projects_PersonDocument2",
                table: "projects",
                column: "PersonDocument2");

            migrationBuilder.CreateIndex(
                name: "IX_projects_ProposalCode",
                table: "projects",
                column: "ProposalCode");

            migrationBuilder.CreateIndex(
                name: "IX_projects_TutorDocument",
                table: "projects",
                column: "TutorDocument");

            migrationBuilder.CreateIndex(
                name: "IX_proposals_EvaluatorDocument",
                table: "proposals",
                column: "EvaluatorDocument");

            migrationBuilder.CreateIndex(
                name: "IX_proposals_InvestigationGroup",
                table: "proposals",
                column: "InvestigationGroup");

            migrationBuilder.CreateIndex(
                name: "IX_proposals_PersonDocument1",
                table: "proposals",
                column: "PersonDocument1");

            migrationBuilder.CreateIndex(
                name: "IX_proposals_PersonDocument2",
                table: "proposals",
                column: "PersonDocument2");

            migrationBuilder.CreateIndex(
                name: "IX_proposals_ThematicAreaCode",
                table: "proposals",
                column: "ThematicAreaCode");

            migrationBuilder.CreateIndex(
                name: "IX_proposals_TutorDocument",
                table: "proposals",
                column: "TutorDocument");

            migrationBuilder.CreateIndex(
                name: "IX_research_group_ResearchLineCode",
                table: "research_group",
                column: "ResearchLineCode");

            migrationBuilder.CreateIndex(
                name: "IX_research_sublines_ResearchLineCode",
                table: "research_sublines",
                column: "ResearchLineCode");

            migrationBuilder.CreateIndex(
                name: "IX_students_AcademicProgramCode",
                table: "students",
                column: "AcademicProgramCode");

            migrationBuilder.CreateIndex(
                name: "IX_studies_CitiesCode",
                table: "studies",
                column: "CitiesCode");

            migrationBuilder.CreateIndex(
                name: "IX_studies_PeopleCode",
                table: "studies",
                column: "PeopleCode");

            migrationBuilder.CreateIndex(
                name: "IX_thematic_areas_ResearchSublineCode",
                table: "thematic_areas",
                column: "ResearchSublineCode");

            migrationBuilder.CreateIndex(
                name: "IX_users_PersonDocument",
                table: "users",
                column: "PersonDocument");

            migrationBuilder.CreateIndex(
                name: "IX_users_user_name",
                table: "users",
                column: "user_name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "experiences");

            migrationBuilder.DropTable(
                name: "history_projects");

            migrationBuilder.DropTable(
                name: "history_proposals");

            migrationBuilder.DropTable(
                name: "message");

            migrationBuilder.DropTable(
                name: "studies");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "project_feedbacks");

            migrationBuilder.DropTable(
                name: "projects");

            migrationBuilder.DropTable(
                name: "porposal_feedback");

            migrationBuilder.DropTable(
                name: "proposals");

            migrationBuilder.DropTable(
                name: "professor");

            migrationBuilder.DropTable(
                name: "research_group");

            migrationBuilder.DropTable(
                name: "students");

            migrationBuilder.DropTable(
                name: "thematic_areas");

            migrationBuilder.DropTable(
                name: "academics_program");

            migrationBuilder.DropTable(
                name: "people");

            migrationBuilder.DropTable(
                name: "research_sublines");

            migrationBuilder.DropTable(
                name: "cities");

            migrationBuilder.DropTable(
                name: "research_lines");

            migrationBuilder.DropTable(
                name: "departments");
        }
    }
}
