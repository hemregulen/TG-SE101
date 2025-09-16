using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TG_SE101.Domain.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Order",
                newName: "CreateDate");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "Product",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "Product",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "OrderItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "OrderItems",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "Order",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "Category",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "Category",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "Category");

            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "Order",
                newName: "Date");
        }
    }
}
