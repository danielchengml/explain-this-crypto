using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ExplainThisCrypto.Migrations
{
    public partial class TwitterWidgetIdString : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TwitterWidgetId",
                table: "Coins",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "TwitterWidgetId",
                table: "Coins",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
