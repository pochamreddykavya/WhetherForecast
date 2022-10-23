using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ResfulCrudOperations.Migrations
{
    public partial class initialsetup1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    CityId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityName = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    TouristRating = table.Column<int>(nullable: false),
                    DateEstablished = table.Column<DateTime>(nullable: false),
                    EstimatedPopulation = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.CityId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "City");
        }
    }
}
