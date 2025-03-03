using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class ModelExamples : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_OperationValues_OperationId",
                table: "OperationValues");

            migrationBuilder.CreateTable(
                name: "ModelExample",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageId = table.Column<int>(type: "int", nullable: false),
                    ModelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModelExample", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ModelExample_Images_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Images",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ModelExample_Model_ModelId",
                        column: x => x.ModelId,
                        principalTable: "Model",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OperationValues_OperationId",
                table: "OperationValues",
                column: "OperationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ModelExample_ImageId",
                table: "ModelExample",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_ModelExample_ModelId",
                table: "ModelExample",
                column: "ModelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ModelExample");

            migrationBuilder.DropIndex(
                name: "IX_OperationValues_OperationId",
                table: "OperationValues");

            migrationBuilder.CreateIndex(
                name: "IX_OperationValues_OperationId",
                table: "OperationValues",
                column: "OperationId");
        }
    }
}
