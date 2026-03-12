using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Quote_genarator.Migrations
{
    /// <inheritdoc />
    public partial class RemoveCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "Quotes");

            migrationBuilder.UpdateData(
                table: "Quotes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 12, 5, 20, 12, 343, DateTimeKind.Utc).AddTicks(8403));

            migrationBuilder.UpdateData(
                table: "Quotes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 12, 5, 20, 12, 343, DateTimeKind.Utc).AddTicks(8406));

            migrationBuilder.UpdateData(
                table: "Quotes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 12, 5, 20, 12, 343, DateTimeKind.Utc).AddTicks(8407));

            migrationBuilder.UpdateData(
                table: "Quotes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 12, 5, 20, 12, 343, DateTimeKind.Utc).AddTicks(8408));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Quotes",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Quotes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Category", "CreatedAt" },
                values: new object[] { "Motivation", new DateTime(2026, 3, 12, 5, 0, 50, 633, DateTimeKind.Utc).AddTicks(9411) });

            migrationBuilder.UpdateData(
                table: "Quotes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Category", "CreatedAt" },
                values: new object[] { "Wisdom", new DateTime(2026, 3, 12, 5, 0, 50, 633, DateTimeKind.Utc).AddTicks(9415) });

            migrationBuilder.UpdateData(
                table: "Quotes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Category", "CreatedAt" },
                values: new object[] { "Philosophy", new DateTime(2026, 3, 12, 5, 0, 50, 633, DateTimeKind.Utc).AddTicks(9417) });

            migrationBuilder.UpdateData(
                table: "Quotes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Category", "CreatedAt" },
                values: new object[] { "Motivation", new DateTime(2026, 3, 12, 5, 0, 50, 633, DateTimeKind.Utc).AddTicks(9419) });
        }
    }
}
