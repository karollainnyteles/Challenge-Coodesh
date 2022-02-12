using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Coodesh.Challenge.Data.Migrations
{
    public partial class SetCharToLaunch : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Launch",
                type: "char(36)",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(16)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "Id",
                table: "Launch",
                type: "varbinary(16)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "char(36)");
        }
    }
}
