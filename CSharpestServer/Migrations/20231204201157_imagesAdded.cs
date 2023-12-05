using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CSharpestServer.Migrations
{
    /// <inheritdoc />
    public partial class imagesAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "items",
                keyColumn: "Id",
                keyValue: new Guid("721b837e-057b-4278-80b7-4f79a65bc934"));

            migrationBuilder.InsertData(
                table: "items",
                columns: new[] { "Id", "Description", "ImageURL", "Name", "Price", "Stock", "bundleId" },
                values: new object[] { new Guid("aae2d4b0-3e96-4b25-87c3-7ce65c33c949"), "candy", "https://m.media-amazon.com/images/I/411ywWj2V+L._AC_UF1000,1000_QL80_.jpg", "Jolly Ranchers", 0.18m, 500, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "items",
                keyColumn: "Id",
                keyValue: new Guid("aae2d4b0-3e96-4b25-87c3-7ce65c33c949"));

            migrationBuilder.InsertData(
                table: "items",
                columns: new[] { "Id", "Description", "ImageURL", "Name", "Price", "Stock", "bundleId" },
                values: new object[] { new Guid("721b837e-057b-4278-80b7-4f79a65bc934"), "candy", "https://m.media-amazon.com/images/I/411ywWj2V+L._AC_UF1000,1000_QL80_.jpg", "Jolly Ranchers", 0.18m, 500, null });
        }
    }
}
