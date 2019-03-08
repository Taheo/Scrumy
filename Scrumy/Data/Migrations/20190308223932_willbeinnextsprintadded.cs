using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Scrumy.Data.Migrations
{
    public partial class willbeinnextsprintadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "willBeInNextSprint",
                table: "SprintTasks",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "willBeInNextSprint",
                table: "SprintTasks");
        }
    }
}
