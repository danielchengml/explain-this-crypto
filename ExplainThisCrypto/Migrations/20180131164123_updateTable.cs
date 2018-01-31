using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ExplainThisCrypto.Migrations
{
    public partial class updateTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Coins_AspNetUsers_UserId1",
                table: "Coins");

            migrationBuilder.DropForeignKey(
                name: "FK_Descriptions_AspNetUsers_UserId1",
                table: "Descriptions");

            migrationBuilder.DropIndex(
                name: "IX_Descriptions_UserId1",
                table: "Descriptions");

            migrationBuilder.DropIndex(
                name: "IX_Coins_UserId1",
                table: "Coins");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Descriptions");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Coins");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Descriptions",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Coins",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_Descriptions_UserId",
                table: "Descriptions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Coins_UserId",
                table: "Coins",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Coins_AspNetUsers_UserId",
                table: "Coins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Descriptions_AspNetUsers_UserId",
                table: "Descriptions",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Coins_AspNetUsers_UserId",
                table: "Coins");

            migrationBuilder.DropForeignKey(
                name: "FK_Descriptions_AspNetUsers_UserId",
                table: "Descriptions");

            migrationBuilder.DropIndex(
                name: "IX_Descriptions_UserId",
                table: "Descriptions");

            migrationBuilder.DropIndex(
                name: "IX_Coins_UserId",
                table: "Coins");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Descriptions",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "Descriptions",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Coins",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "Coins",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Descriptions_UserId1",
                table: "Descriptions",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Coins_UserId1",
                table: "Coins",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Coins_AspNetUsers_UserId1",
                table: "Coins",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Descriptions_AspNetUsers_UserId1",
                table: "Descriptions",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
