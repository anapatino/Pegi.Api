// <auto-generated />
using System;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Api.Migrations
{
    [DbContext(typeof(PegiDbContext))]
    partial class PegiDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Entities.AcademicProgram", b =>
                {
                    b.Property<int>("Code")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("academic_program_code");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("academic_program_name");

                    b.HasKey("Code")
                        .HasName("pk_academic_programs");

                    b.ToTable("academic_programs", (string)null);
                });

            modelBuilder.Entity("Entities.City", b =>
                {
                    b.Property<string>("Code")
                        .HasColumnType("varchar(255)")
                        .HasColumnName("city_code");

                    b.Property<string>("DepartmentCode")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("department_code");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("city_name");

                    b.HasKey("Code")
                        .HasName("pk_cities");

                    b.HasIndex("DepartmentCode")
                        .HasDatabaseName("ix_cities_department_code");

                    b.ToTable("cities", (string)null);
                });

            modelBuilder.Entity("Entities.Country", b =>
                {
                    b.Property<string>("Code")
                        .HasColumnType("varchar(255)")
                        .HasColumnName("country_code");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("country_name");

                    b.HasKey("Code")
                        .HasName("pk_countries");

                    b.ToTable("countries", (string)null);
                });

            modelBuilder.Entity("Entities.CV", b =>
                {
                    b.Property<int>("Code")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("cv_code");

                    b.Property<string>("AttachFiles")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("cv_attach_files");

                    b.HasKey("Code")
                        .HasName("pk_cv");

                    b.ToTable("cv", (string)null);
                });

            modelBuilder.Entity("Entities.Department", b =>
                {
                    b.Property<string>("Code")
                        .HasColumnType("varchar(255)")
                        .HasColumnName("department_code");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("department_name");

                    b.HasKey("Code")
                        .HasName("pk_departments");

                    b.ToTable("departments", (string)null);
                });

            modelBuilder.Entity("Entities.InvestigationSubLine", b =>
                {
                    b.Property<int>("Code")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("sublines_code");

                    b.Property<int>("LineCode")
                        .HasColumnType("int")
                        .HasColumnName("line_code");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("sublines_name");

                    b.HasKey("Code")
                        .HasName("pk_sublines");

                    b.HasIndex("LineCode")
                        .HasDatabaseName("ix_sublines_line_code");

                    b.ToTable("sublines", (string)null);
                });

            modelBuilder.Entity("Entities.LineInvestigation", b =>
                {
                    b.Property<int>("Code")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("lines_code");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("lines_name");

                    b.HasKey("Code")
                        .HasName("pk_lines");

                    b.ToTable("lines", (string)null);
                });

            modelBuilder.Entity("Entities.Member", b =>
                {
                    b.Property<string>("Document")
                        .HasColumnType("varchar(255)")
                        .HasColumnName("member_document");

                    b.Property<string>("CreditNumber")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("member_credit_number");

                    b.Property<string>("IdentificationType")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("member_identification_type");

                    b.Property<string>("Mail")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("member_email");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("member_name");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("member_phone");

                    b.Property<int>("ProgramCode")
                        .HasColumnType("int")
                        .HasColumnName("program_code");

                    b.Property<int?>("ProposalCode")
                        .HasColumnType("int")
                        .HasColumnName("proposal_code");

                    b.HasKey("Document")
                        .HasName("pk_members");

                    b.HasIndex("ProgramCode")
                        .HasDatabaseName("ix_members_program_code");

                    b.HasIndex("ProposalCode")
                        .HasDatabaseName("ix_members_proposal_code");

                    b.ToTable("members", (string)null);
                });

            modelBuilder.Entity("Entities.Person", b =>
                {
                    b.Property<string>("Document")
                        .HasColumnType("varchar(255)")
                        .HasColumnName("person_document");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("person_birth_date");

                    b.Property<string>("CivilState")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("person_civil_state");

                    b.Property<string>("CountryCode")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("country_code");

                    b.Property<string>("FirstLastName")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("person_first_last_name");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("person_first_name");

                    b.Property<string>("IdentificationType")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("person_identification_type");

                    b.Property<string>("InstitutionalMail")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("person_institutional_email");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("person_phone");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("person_position");

                    b.Property<int>("ProgramCode")
                        .HasColumnType("int")
                        .HasColumnName("program_code");

                    b.Property<string>("SecondLastName")
                        .HasColumnType("longtext")
                        .HasColumnName("person_second_last_name");

                    b.Property<string>("SecondName")
                        .HasColumnType("longtext")
                        .HasColumnName("person_second_name");

                    b.Property<string>("Sex")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("person_sex");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("person_type");

                    b.Property<string>("UserName")
                        .HasColumnType("varchar(255)")
                        .HasColumnName("user_name");

                    b.HasKey("Document")
                        .HasName("pk_people");

                    b.HasIndex("CountryCode")
                        .HasDatabaseName("ix_people_country_code");

                    b.HasIndex("ProgramCode")
                        .HasDatabaseName("ix_people_program_code");

                    b.HasIndex("UserName")
                        .HasDatabaseName("ix_people_user_name");

                    b.ToTable("people", (string)null);
                });

            modelBuilder.Entity("Entities.Project", b =>
                {
                    b.Property<int>("Code")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("project_code");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("project_content");

                    b.Property<string>("Feedback")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("project_feedback");

                    b.Property<int>("ProposalCode")
                        .HasColumnType("int")
                        .HasColumnName("proposal_code");

                    b.Property<string>("Qualification")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("project_qualification");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("project_status");

                    b.HasKey("Code")
                        .HasName("pk_projects");

                    b.HasIndex("ProposalCode")
                        .HasDatabaseName("ix_projects_proposal_code");

                    b.ToTable("projects", (string)null);
                });

            modelBuilder.Entity("Entities.Proposal", b =>
                {
                    b.Property<int>("Code")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("proposals_code");

                    b.Property<string>("ApproachProblem")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("proposals_approach_problem");

                    b.Property<string>("Bibliography")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("proposals_bibliography");

                    b.Property<string>("CodeEvaluation")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("proposals_evaluation_code");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("proposals_date");

                    b.Property<string>("Feedback")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("proposals_evaluation_feedback");

                    b.Property<string>("FormulationProblem")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("proposals_formulation_problem");

                    b.Property<string>("GeneralObjective")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("proposals_general_objective");

                    b.Property<string>("JustificationProblem")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("proposals_justification_problem");

                    b.Property<string>("ResearchGroup")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("proposals_research_group");

                    b.Property<string>("SpecificObjective")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("proposals_specific_objective");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("proposals_evaluation_status");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("proposals_title");

                    b.HasKey("Code")
                        .HasName("pk_proposals");

                    b.ToTable("proposals", (string)null);
                });

            modelBuilder.Entity("Entities.Study", b =>
                {
                    b.Property<int>("Code")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("study_code");

                    b.Property<string>("CityCode")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("city_code");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("study_end_date");

                    b.Property<string>("Institution")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("study_institution");

                    b.Property<string>("PersonDocument1")
                        .HasColumnType("varchar(255)")
                        .HasColumnName("person_document1");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("study_start_date");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("study_type");

                    b.HasKey("Code")
                        .HasName("pk_studies");

                    b.HasIndex("CityCode")
                        .HasDatabaseName("ix_studies_city_code");

                    b.HasIndex("PersonDocument1")
                        .HasDatabaseName("ix_studies_person_document1");

                    b.ToTable("studies", (string)null);
                });

            modelBuilder.Entity("Entities.ThematicArea", b =>
                {
                    b.Property<int>("Code")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("thematic_areas_code");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("thematic_areas_name");

                    b.Property<int>("SubLineCode")
                        .HasColumnType("int")
                        .HasColumnName("sub_line_code");

                    b.HasKey("Code")
                        .HasName("pk_thematic_areas");

                    b.HasIndex("SubLineCode")
                        .HasDatabaseName("ix_thematic_areas_sub_line_code");

                    b.ToTable("thematic_areas", (string)null);
                });

            modelBuilder.Entity("Entities.User", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("varchar(255)")
                        .HasColumnName("user_name");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("user_password");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("user_role");

                    b.HasKey("Name")
                        .HasName("pk_users");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasDatabaseName("ix_users_user_name");

                    b.ToTable("users", (string)null);
                });

            modelBuilder.Entity("Entities.Experience", b =>
                {
                    b.HasBaseType("Entities.Study");

                    b.Property<string>("PersonDocument")
                        .HasColumnType("varchar(255)")
                        .HasColumnName("person_document");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("experience_position");

                    b.HasIndex("PersonDocument")
                        .HasDatabaseName("ix_experiences_person_document");

                    b.ToTable("experiences");
                });

            modelBuilder.Entity("Entities.City", b =>
                {
                    b.HasOne("Entities.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_cities_departments_department_code");

                    b.Navigation("Department");
                });

            modelBuilder.Entity("Entities.InvestigationSubLine", b =>
                {
                    b.HasOne("Entities.LineInvestigation", "LineInvestigation")
                        .WithMany("SublinesInvestigation")
                        .HasForeignKey("LineCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_sublines_lines_line_code");

                    b.Navigation("LineInvestigation");
                });

            modelBuilder.Entity("Entities.Member", b =>
                {
                    b.HasOne("Entities.AcademicProgram", "AcademicProgram")
                        .WithMany()
                        .HasForeignKey("ProgramCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_members_academic_programs_program_code");

                    b.HasOne("Entities.Proposal", null)
                        .WithMany("Members")
                        .HasForeignKey("ProposalCode")
                        .HasConstraintName("fk_members_proposals_proposal_code");

                    b.Navigation("AcademicProgram");
                });

            modelBuilder.Entity("Entities.Person", b =>
                {
                    b.HasOne("Entities.Country", "Nationality")
                        .WithMany()
                        .HasForeignKey("CountryCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_people_countries_country_code");

                    b.HasOne("Entities.AcademicProgram", "AcademicProgram")
                        .WithMany()
                        .HasForeignKey("ProgramCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_people_academic_programs_program_code");

                    b.HasOne("Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserName")
                        .HasConstraintName("fk_people_users_user_name");

                    b.Navigation("AcademicProgram");

                    b.Navigation("Nationality");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Entities.Project", b =>
                {
                    b.HasOne("Entities.Proposal", "Proposal")
                        .WithMany()
                        .HasForeignKey("ProposalCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_projects_proposals_proposal_code");

                    b.Navigation("Proposal");
                });

            modelBuilder.Entity("Entities.Study", b =>
                {
                    b.HasOne("Entities.City", "City")
                        .WithMany()
                        .HasForeignKey("CityCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_studies_cities_city_code");

                    b.HasOne("Entities.Person", null)
                        .WithMany("Studies")
                        .HasForeignKey("PersonDocument1")
                        .HasConstraintName("fk_studies_people_person_document1");

                    b.Navigation("City");
                });

            modelBuilder.Entity("Entities.ThematicArea", b =>
                {
                    b.HasOne("Entities.InvestigationSubLine", "InvestigationSubLine")
                        .WithMany("ThematicAreas")
                        .HasForeignKey("SubLineCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_thematic_areas_sublines_sub_line_code");

                    b.Navigation("InvestigationSubLine");
                });

            modelBuilder.Entity("Entities.Experience", b =>
                {
                    b.HasOne("Entities.Study", null)
                        .WithOne()
                        .HasForeignKey("Entities.Experience", "Code")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_experiences_studies_study_code");

                    b.HasOne("Entities.Person", null)
                        .WithMany("Experiences")
                        .HasForeignKey("PersonDocument")
                        .HasConstraintName("fk_experiences_people_person_document");
                });

            modelBuilder.Entity("Entities.InvestigationSubLine", b =>
                {
                    b.Navigation("ThematicAreas");
                });

            modelBuilder.Entity("Entities.LineInvestigation", b =>
                {
                    b.Navigation("SublinesInvestigation");
                });

            modelBuilder.Entity("Entities.Person", b =>
                {
                    b.Navigation("Experiences");

                    b.Navigation("Studies");
                });

            modelBuilder.Entity("Entities.Proposal", b =>
                {
                    b.Navigation("Members");
                });
#pragma warning restore 612, 618
        }
    }
}
