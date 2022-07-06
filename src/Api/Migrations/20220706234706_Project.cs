using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    public partial class Project : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "program");

            migrationBuilder.DropTable(
                name: "project_evaluation");

            migrationBuilder.DropTable(
                name: "student");

            migrationBuilder.DropTable(
                name: "teachers");

            migrationBuilder.DropTable(
                name: "proposal_evaluation");

            migrationBuilder.RenameColumn(
                name: "project_title",
                table: "projects",
                newName: "projects_title");

            migrationBuilder.RenameColumn(
                name: "project_content",
                table: "projects",
                newName: "projects_content");

            migrationBuilder.RenameColumn(
                name: "project_code",
                table: "projects",
                newName: "projects_code");

            migrationBuilder.AddColumn<string>(
                name: "proposals_evaluation_code",
                table: "proposals",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "proposals_evaluation_feedback",
                table: "proposals",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "proposals_evaluation_status",
                table: "proposals",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "projects_feedback",
                table: "projects",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "projects_qualification",
                table: "projects",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "projects_status",
                table: "projects",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "proposal_code",
                table: "projects",
                type: "varchar(255)",
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "person_position",
                table: "people",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "person_type",
                table: "people",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "program_code",
                table: "people",
                type: "varchar(255)",
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "academic_program",
                columns: table => new
                {
                    academic_program_code = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    academic_program_name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_academic_program", x => x.academic_program_code);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "members",
                columns: table => new
                {
                    member_document = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    member_identification_type = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    member_name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    program_code = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    member_credit_number = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    member_phone = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    member_email = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    proposal_code = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_members", x => x.member_document);
                    table.ForeignKey(
                        name: "fk_members_academic_program_program_code",
                        column: x => x.program_code,
                        principalTable: "academic_program",
                        principalColumn: "academic_program_code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_members_proposals_proposal_code",
                        column: x => x.proposal_code,
                        principalTable: "proposals",
                        principalColumn: "proposals_code");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "ix_projects_proposal_code",
                table: "projects",
                column: "proposal_code");

            migrationBuilder.CreateIndex(
                name: "ix_people_program_code",
                table: "people",
                column: "program_code");

            migrationBuilder.CreateIndex(
                name: "ix_members_program_code",
                table: "members",
                column: "program_code");

            migrationBuilder.CreateIndex(
                name: "ix_members_proposal_code",
                table: "members",
                column: "proposal_code");

            migrationBuilder.AddForeignKey(
                name: "fk_people_academic_program_program_code",
                table: "people",
                column: "program_code",
                principalTable: "academic_program",
                principalColumn: "academic_program_code",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_projects_proposals_proposal_code",
                table: "projects",
                column: "proposal_code",
                principalTable: "proposals",
                principalColumn: "proposals_code",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_people_academic_program_program_code",
                table: "people");

            migrationBuilder.DropForeignKey(
                name: "fk_projects_proposals_proposal_code",
                table: "projects");

            migrationBuilder.DropTable(
                name: "members");

            migrationBuilder.DropTable(
                name: "academic_program");

            migrationBuilder.DropIndex(
                name: "ix_projects_proposal_code",
                table: "projects");

            migrationBuilder.DropIndex(
                name: "ix_people_program_code",
                table: "people");

            migrationBuilder.DropColumn(
                name: "proposals_evaluation_code",
                table: "proposals");

            migrationBuilder.DropColumn(
                name: "proposals_evaluation_feedback",
                table: "proposals");

            migrationBuilder.DropColumn(
                name: "proposals_evaluation_status",
                table: "proposals");

            migrationBuilder.DropColumn(
                name: "projects_feedback",
                table: "projects");

            migrationBuilder.DropColumn(
                name: "projects_qualification",
                table: "projects");

            migrationBuilder.DropColumn(
                name: "projects_status",
                table: "projects");

            migrationBuilder.DropColumn(
                name: "proposal_code",
                table: "projects");

            migrationBuilder.DropColumn(
                name: "person_position",
                table: "people");

            migrationBuilder.DropColumn(
                name: "person_type",
                table: "people");

            migrationBuilder.DropColumn(
                name: "program_code",
                table: "people");

            migrationBuilder.RenameColumn(
                name: "projects_title",
                table: "projects",
                newName: "project_title");

            migrationBuilder.RenameColumn(
                name: "projects_content",
                table: "projects",
                newName: "project_content");

            migrationBuilder.RenameColumn(
                name: "projects_code",
                table: "projects",
                newName: "project_code");

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
                name: "proposal_evaluation",
                columns: table => new
                {
                    proposal_evaluation_code = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    proposal_evaluation_feedback = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    proposal_evaluation_status = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_proposal_evaluation", x => x.proposal_evaluation_code);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "student",
                columns: table => new
                {
                    person_document = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    student_credit_number = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    student_program_code = table.Column<string>(type: "longtext", nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "ix_student_project_code",
                table: "student",
                column: "project_code");

            migrationBuilder.CreateIndex(
                name: "ix_student_proposal_code",
                table: "student",
                column: "proposal_code");
        }
    }
}
