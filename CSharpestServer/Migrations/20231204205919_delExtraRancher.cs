using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CSharpestServer.Migrations
{
    /// <inheritdoc />
    public partial class delExtraRancher : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "items",
                keyColumn: "Id",
                keyValue: new Guid("54a4022e-bc9f-49d0-8745-f23b6f07d55c"));

            migrationBuilder.InsertData(
                table: "items",
                columns: new[] { "Id", "Description", "ImageURL", "Name", "Price", "Stock", "bundleId" },
                values: new object[] { new Guid("fb314af9-f915-4c7a-9b2c-cce2c144e12d"), "candy", "https://m.media-amazon.com/images/I/411ywWj2V+L._AC_UF1000,1000_QL80_.jpg", "Jolly Ranchers", 0.18m, 500, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "items",
                keyColumn: "Id",
                keyValue: new Guid("fb314af9-f915-4c7a-9b2c-cce2c144e12d"));

            migrationBuilder.InsertData(
                table: "items",
                columns: new[] { "Id", "Description", "ImageURL", "Name", "Price", "Stock", "bundleId" },
                values: new object[] { new Guid("54a4022e-bc9f-49d0-8745-f23b6f07d55c"), "candy", "https://m.media-amazon.com/images/I/411ywWj2V+L._AC_UF1000,1000_QL80_.jpg", "Jolly Ranchers", 0.18m, 500, null });
        }
    }
}
