using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    public partial class LinesAndSublines : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_sublines_lines_line_investigation_code",
                table: "sublines");

            migrationBuilder.DropForeignKey(
                name: "fk_thematic_areas_sublines_investigation_sub_line_code",
                table: "thematic_areas");

            migrationBuilder.DropIndex(
                name: "ix_thematic_areas_investigation_sub_line_code",
                table: "thematic_areas");

            migrationBuilder.DropIndex(
                name: "ix_sublines_line_investigation_code",
                table: "sublines");

            migrationBuilder.DropColumn(
                name: "investigation_sub_line_code",
                table: "thematic_areas");

            migrationBuilder.DropColumn(
                name: "line_investigation_code",
                table: "sublines");

            migrationBuilder.AddColumn<int>(
                name: "sub_line_code",
                table: "thematic_areas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "line_code",
                table: "sublines",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "ix_thematic_areas_sub_line_code",
                table: "thematic_areas",
                column: "sub_line_code");

            migrationBuilder.CreateIndex(
                name: "ix_sublines_line_code",
                table: "sublines",
                column: "line_code");

            migrationBuilder.AddForeignKey(
                name: "fk_sublines_lines_line_code",
                table: "sublines",
                column: "line_code",
                principalTable: "lines",
                principalColumn: "lines_code",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_thematic_areas_sublines_sub_line_code",
                table: "thematic_areas",
                column: "sub_line_code",
                principalTable: "sublines",
                principalColumn: "sublines_code",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_sublines_lines_line_code",
                table: "sublines");

            migrationBuilder.DropForeignKey(
                name: "fk_thematic_areas_sublines_sub_line_code",
                table: "thematic_areas");

            migrationBuilder.DropIndex(
                name: "ix_thematic_areas_sub_line_code",
                table: "thematic_areas");

            migrationBuilder.DropIndex(
                name: "ix_sublines_line_code",
                table: "sublines");

            migrationBuilder.DropColumn(
                name: "sub_line_code",
                table: "thematic_areas");

            migrationBuilder.DropColumn(
                name: "line_code",
                table: "sublines");

            migrationBuilder.AddColumn<int>(
                name: "investigation_sub_line_code",
                table: "thematic_areas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "line_investigation_code",
                table: "sublines",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "ix_thematic_areas_investigation_sub_line_code",
                table: "thematic_areas",
                column: "investigation_sub_line_code");

            migrationBuilder.CreateIndex(
                name: "ix_sublines_line_investigation_code",
                table: "sublines",
                column: "line_investigation_code");

            migrationBuilder.AddForeignKey(
                name: "fk_sublines_lines_line_investigation_code",
                table: "sublines",
                column: "line_investigation_code",
                principalTable: "lines",
                principalColumn: "lines_code");

            migrationBuilder.AddForeignKey(
                name: "fk_thematic_areas_sublines_investigation_sub_line_code",
                table: "thematic_areas",
                column: "investigation_sub_line_code",
                principalTable: "sublines",
                principalColumn: "sublines_code");
        }
    }
}
