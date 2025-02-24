using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class CheckpointModelRefactor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "PublishedDate",
                table: "Model",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PublisherId",
                table: "Model",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Trigger",
                table: "Model",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Model_PublisherId",
                table: "Model",
                column: "PublisherId");

            migrationBuilder.AddForeignKey(
                name: "FK_Model_User_PublisherId",
                table: "Model",
                column: "PublisherId",
                principalTable: "User",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Model_User_PublisherId",
                table: "Model");

            migrationBuilder.DropIndex(
                name: "IX_Model_PublisherId",
                table: "Model");

            migrationBuilder.DropColumn(
                name: "PublishedDate",
                table: "Model");

            migrationBuilder.DropColumn(
                name: "PublisherId",
                table: "Model");

            migrationBuilder.DropColumn(
                name: "Trigger",
                table: "Model");
        }
    }
}
