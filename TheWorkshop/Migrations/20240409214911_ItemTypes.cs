using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheWorkshop.Migrations
{
    /// <inheritdoc />
    public partial class ItemTypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Item",
                table: "Item");

            migrationBuilder.RenameTable(
                name: "Item",
                newName: "Items");

            migrationBuilder.AddColumn<DateTime>(
                name: "DueDate",
                table: "Items",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsCompleted",
                table: "Items",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ItemType",
                table: "Items",
                type: "nvarchar(8)",
                maxLength: 8,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Items",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartTime",
                table: "Items",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Items",
                table: "Items",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Items",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "DueDate",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "IsCompleted",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "ItemType",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "StartTime",
                table: "Items");

            migrationBuilder.RenameTable(
                name: "Items",
                newName: "Item");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Item",
                table: "Item",
                column: "Id");
        }
    }
}
