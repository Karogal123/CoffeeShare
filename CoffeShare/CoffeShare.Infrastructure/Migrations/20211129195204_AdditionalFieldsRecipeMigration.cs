using Microsoft.EntityFrameworkCore.Migrations;

namespace CoffeeShare.Infrastructure.Migrations
{
    public partial class AdditionalFieldsRecipeMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CoffeeAmount",
                table: "Recipes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GrindLevel",
                table: "Recipes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "WaterAmount",
                table: "Recipes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "WaterTemperature",
                table: "Recipes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "744fc8e7-d0e4-407f-9f23-3142b624d856");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "7fb851cb-8478-4185-9c7b-07ccb8a58f80");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CoffeeAmount",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "GrindLevel",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "WaterAmount",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "WaterTemperature",
                table: "Recipes");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "690760b2-e927-4b7d-a04b-69e4952b0cf2");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "24665eeb-6626-4b90-9883-cb53865c3159");
        }
    }
}
