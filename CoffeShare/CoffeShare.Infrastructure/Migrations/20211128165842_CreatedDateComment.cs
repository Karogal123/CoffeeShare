﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CoffeeShare.Infrastructure.Migrations
{
    public partial class CreatedDateComment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Comments");

        }
    }
}
