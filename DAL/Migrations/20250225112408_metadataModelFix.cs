using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class metadataModelFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Images_MetadataId",
                table: "Images");

            migrationBuilder.CreateIndex(
                name: "IX_Images_MetadataId",
                table: "Images",
                column: "MetadataId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Images_MetadataId",
                table: "Images");

            migrationBuilder.CreateIndex(
                name: "IX_Images_MetadataId",
                table: "Images",
                column: "MetadataId");
        }
    }
}
