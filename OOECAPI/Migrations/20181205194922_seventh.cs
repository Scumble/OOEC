using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace OOECAPI.Migrations
{
    public partial class seventh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "gamePlayerInfo");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Teams",
                newName: "TeamName");

            migrationBuilder.AddColumn<string>(
                name: "DateEnd",
                table: "Tournaments",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DateStart",
                table: "Tournaments",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Tournaments",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Game",
                table: "Tournaments",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Tag",
                table: "Teams",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Team_id_dire",
                table: "Lobbies",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Team_id_radiant",
                table: "Lobbies",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Lobbies_Team_id_dire",
                table: "Lobbies",
                column: "Team_id_dire");

            migrationBuilder.CreateIndex(
                name: "IX_Lobbies_Team_id_radiant",
                table: "Lobbies",
                column: "Team_id_radiant");

            migrationBuilder.AddForeignKey(
                name: "FK_Lobbies_Teams_Team_id_dire",
                table: "Lobbies",
                column: "Team_id_dire",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Lobbies_Teams_Team_id_radiant",
                table: "Lobbies",
                column: "Team_id_radiant",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lobbies_Teams_Team_id_dire",
                table: "Lobbies");

            migrationBuilder.DropForeignKey(
                name: "FK_Lobbies_Teams_Team_id_radiant",
                table: "Lobbies");

            migrationBuilder.DropIndex(
                name: "IX_Lobbies_Team_id_dire",
                table: "Lobbies");

            migrationBuilder.DropIndex(
                name: "IX_Lobbies_Team_id_radiant",
                table: "Lobbies");

            migrationBuilder.DropColumn(
                name: "DateEnd",
                table: "Tournaments");

            migrationBuilder.DropColumn(
                name: "DateStart",
                table: "Tournaments");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Tournaments");

            migrationBuilder.DropColumn(
                name: "Game",
                table: "Tournaments");

            migrationBuilder.DropColumn(
                name: "Tag",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "Team_id_dire",
                table: "Lobbies");

            migrationBuilder.DropColumn(
                name: "Team_id_radiant",
                table: "Lobbies");

            migrationBuilder.RenameColumn(
                name: "TeamName",
                table: "Teams",
                newName: "Name");

            migrationBuilder.CreateTable(
                name: "gamePlayerInfo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LobbyId = table.Column<int>(nullable: true),
                    PlayerId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_gamePlayerInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_gamePlayerInfo_Lobbies_LobbyId",
                        column: x => x.LobbyId,
                        principalTable: "Lobbies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_gamePlayerInfo_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_gamePlayerInfo_LobbyId",
                table: "gamePlayerInfo",
                column: "LobbyId");

            migrationBuilder.CreateIndex(
                name: "IX_gamePlayerInfo_PlayerId",
                table: "gamePlayerInfo",
                column: "PlayerId");
        }
    }
}
