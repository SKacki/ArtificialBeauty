using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class ModelExamples2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ModelExample_ImageId",
                table: "ModelExample");

            migrationBuilder.CreateIndex(
                name: "IX_ModelExample_ImageId",
                table: "ModelExample",
                column: "ImageId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ModelExample_ImageId",
                table: "ModelExample");

            migrationBuilder.CreateIndex(
                name: "IX_ModelExample_ImageId",
                table: "ModelExample",
                column: "ImageId");
        }
    }
}
