using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Scrumy.Data.Migrations
{
    public partial class spadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProjectSettings",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    EstimatedSPsum = table.Column<int>(nullable: false),
                    EstimatedTeamSpeed = table.Column<int>(nullable: false),
                    SprintAmount = table.Column<int>(nullable: false),
                    SprintLength = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectSettings", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectSettings");
        }
    }
}
