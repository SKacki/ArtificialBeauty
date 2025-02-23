using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class DbRefactor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CollectionImagesCollection");

            migrationBuilder.DropTable(
                name: "ImageImagesCollection");

            migrationBuilder.DropColumn(
                name: "CommentsId",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "ReactionsId",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "Tips",
                table: "Images");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "ImagesCollection",
                newName: "Id");

            migrationBuilder.AddColumn<string>(
                name: "Bio",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UploadDate",
                table: "Images",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Tip",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageId = table.Column<int>(type: "int", nullable: false),
                    OperationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tip", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tip_Images_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Images",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tip_OperationsHistory_OperationId",
                        column: x => x.OperationId,
                        principalTable: "OperationsHistory",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ImagesCollection_CollectionId",
                table: "ImagesCollection",
                column: "CollectionId");

            migrationBuilder.CreateIndex(
                name: "IX_ImagesCollection_ImageId",
                table: "ImagesCollection",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_UserId",
                table: "Images",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Tip_ImageId",
                table: "Tip",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Tip_OperationId",
                table: "Tip",
                column: "OperationId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Images_User_UserId",
                table: "Images",
                column: "UserId",
                principalTable: "User",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ImagesCollection_Collection_CollectionId",
                table: "ImagesCollection",
                column: "CollectionId",
                principalTable: "Collection",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ImagesCollection_Images_ImageId",
                table: "ImagesCollection",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_User_UserId",
                table: "Images");

            migrationBuilder.DropForeignKey(
                name: "FK_ImagesCollection_Collection_CollectionId",
                table: "ImagesCollection");

            migrationBuilder.DropForeignKey(
                name: "FK_ImagesCollection_Images_ImageId",
                table: "ImagesCollection");

            migrationBuilder.DropTable(
                name: "Tip");

            migrationBuilder.DropIndex(
                name: "IX_ImagesCollection_CollectionId",
                table: "ImagesCollection");

            migrationBuilder.DropIndex(
                name: "IX_ImagesCollection_ImageId",
                table: "ImagesCollection");

            migrationBuilder.DropIndex(
                name: "IX_Images_UserId",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "Bio",
                table: "User");

            migrationBuilder.DropColumn(
                name: "UploadDate",
                table: "Images");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ImagesCollection",
                newName: "ID");

            migrationBuilder.AddColumn<int>(
                name: "CommentsId",
                table: "Images",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ReactionsId",
                table: "Images",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Tips",
                table: "Images",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CollectionImagesCollection",
                columns: table => new
                {
                    CollectionsId = table.Column<int>(type: "int", nullable: false),
                    ImagesCollectionID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CollectionImagesCollection", x => new { x.CollectionsId, x.ImagesCollectionID });
                    table.ForeignKey(
                        name: "FK_CollectionImagesCollection_Collection_CollectionsId",
                        column: x => x.CollectionsId,
                        principalTable: "Collection",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CollectionImagesCollection_ImagesCollection_ImagesCollectionID",
                        column: x => x.ImagesCollectionID,
                        principalTable: "ImagesCollection",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ImageImagesCollection",
                columns: table => new
                {
                    CollectionsID = table.Column<int>(type: "int", nullable: false),
                    ImagesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageImagesCollection", x => new { x.CollectionsID, x.ImagesId });
                    table.ForeignKey(
                        name: "FK_ImageImagesCollection_ImagesCollection_CollectionsID",
                        column: x => x.CollectionsID,
                        principalTable: "ImagesCollection",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ImageImagesCollection_Images_ImagesId",
                        column: x => x.ImagesId,
                        principalTable: "Images",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CollectionImagesCollection_ImagesCollectionID",
                table: "CollectionImagesCollection",
                column: "ImagesCollectionID");

            migrationBuilder.CreateIndex(
                name: "IX_ImageImagesCollection_ImagesId",
                table: "ImageImagesCollection",
                column: "ImagesId");
        }
    }
}
