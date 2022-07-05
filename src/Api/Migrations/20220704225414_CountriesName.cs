using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    public partial class CountriesName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "pk_country",
                table: "country");

            migrationBuilder.RenameTable(
                name: "country",
                newName: "countries");

            migrationBuilder.AddPrimaryKey(
                name: "pk_countries",
                table: "countries",
                column: "country_code");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "pk_countries",
                table: "countries");

            migrationBuilder.RenameTable(
                name: "countries",
                newName: "country");

            migrationBuilder.AddPrimaryKey(
                name: "pk_country",
                table: "country",
                column: "country_code");
        }
    }
}
