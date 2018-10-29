using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace OOECAPI.Migrations
{
    public partial class third : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Score",
                table: "Lobbies",
                newName: "ScoreWinner");

            migrationBuilder.AlterColumn<string>(
                name: "DateStart",
                table: "Lobbies",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AddColumn<int>(
                name: "ScoreLoser",
                table: "Lobbies",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ScoreLoser",
                table: "Lobbies");

            migrationBuilder.RenameColumn(
                name: "ScoreWinner",
                table: "Lobbies",
                newName: "Score");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateStart",
                table: "Lobbies",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
