using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CSharpestServer.Migrations
{
    /// <inheritdoc />
    public partial class seedItemsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "items",
                columns: new[] { "Id", "Description", "Name", "Price", "Stock", "bundleId" },
                values: new object[] { new Guid("958fe8be-b592-4ce6-b6c7-6761b997065f"), "candy", "Jolly Ranchers", 0.18m, 500, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "items",
                keyColumn: "Id",
                keyValue: new Guid("958fe8be-b592-4ce6-b6c7-6761b997065f"));
        }
    }
}
