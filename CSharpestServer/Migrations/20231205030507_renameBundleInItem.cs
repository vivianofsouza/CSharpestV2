using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CSharpestServer.Migrations
{
    /// <inheritdoc />
    public partial class renameBundleInItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_items_bundles_bundleId",
                table: "items");

            migrationBuilder.DropIndex(
                name: "IX_items_bundleId",
                table: "items");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_items_bundleId",
                table: "items",
                column: "bundleId");

            migrationBuilder.AddForeignKey(
                name: "FK_items_bundles_bundleId",
                table: "items",
                column: "bundleId",
                principalTable: "bundles",
                principalColumn: "Id");
        }
    }
}
