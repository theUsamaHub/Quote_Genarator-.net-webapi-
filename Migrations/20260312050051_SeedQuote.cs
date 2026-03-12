using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Quote_genarator.Migrations
{
    /// <inheritdoc />
    public partial class SeedQuote : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Quotes",
                columns: new[] { "Id", "Author", "Category", "CreatedAt", "Text" },
                values: new object[,]
                {
                    { 1, "Steve Jobs", "Motivation", new DateTime(2026, 3, 12, 5, 0, 50, 633, DateTimeKind.Utc).AddTicks(9411), "Stay hungry, stay foolish." },
                    { 2, "Albert Einstein", "Wisdom", new DateTime(2026, 3, 12, 5, 0, 50, 633, DateTimeKind.Utc).AddTicks(9415), "Imagination is more important than knowledge." },
                    { 3, "Bruce Lee", "Philosophy", new DateTime(2026, 3, 12, 5, 0, 50, 633, DateTimeKind.Utc).AddTicks(9417), "Be water, my friend." },
                    { 4, "Yoda", "Motivation", new DateTime(2026, 3, 12, 5, 0, 50, 633, DateTimeKind.Utc).AddTicks(9419), "Do or do not, there is no try." }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Quotes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Quotes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Quotes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Quotes",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
