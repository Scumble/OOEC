using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace OOECAPI.Migrations
{
    public partial class fifth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FacebookId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<long>(
                name: "PrizePool",
                table: "Tournaments",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IdentityId",
                table: "Tournaments",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tournaments_IdentityId",
                table: "Tournaments",
                column: "IdentityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tournaments_AspNetUsers_IdentityId",
                table: "Tournaments",
                column: "IdentityId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tournaments_AspNetUsers_IdentityId",
                table: "Tournaments");

            migrationBuilder.DropIndex(
                name: "IX_Tournaments_IdentityId",
                table: "Tournaments");

            migrationBuilder.DropColumn(
                name: "IdentityId",
                table: "Tournaments");

            migrationBuilder.AlterColumn<string>(
                name: "PrizePool",
                table: "Tournaments",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AddColumn<long>(
                name: "FacebookId",
                table: "AspNetUsers",
                nullable: true);
        }
    }
}
