﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CSharpestServer.Migrations
{
    /// <inheritdoc />
    public partial class delRanchersAgain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "items",
                keyColumn: "Id",
                keyValue: new Guid("7998baf7-0c1a-45a8-a790-c891ea0f0886"));

            migrationBuilder.InsertData(
                table: "items",
                columns: new[] { "Id", "Description", "ImageURL", "Name", "Price", "Stock", "bundleId" },
                values: new object[] { new Guid("72a5f674-8016-4787-9a8d-dbd5b0f23aa9"), "candy", "https://m.media-amazon.com/images/I/411ywWj2V+L._AC_UF1000,1000_QL80_.jpg", "Jolly Ranchers", 0.18m, 500, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "items",
                keyColumn: "Id",
                keyValue: new Guid("72a5f674-8016-4787-9a8d-dbd5b0f23aa9"));

            migrationBuilder.InsertData(
                table: "items",
                columns: new[] { "Id", "Description", "ImageURL", "Name", "Price", "Stock", "bundleId" },
                values: new object[] { new Guid("7998baf7-0c1a-45a8-a790-c891ea0f0886"), "candy", "https://m.media-amazon.com/images/I/411ywWj2V+L._AC_UF1000,1000_QL80_.jpg", "Jolly Ranchers", 0.18m, 500, null });
        }
    }
}