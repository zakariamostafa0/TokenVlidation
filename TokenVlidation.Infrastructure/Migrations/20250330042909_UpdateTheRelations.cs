using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TokenVlidation.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTheRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Tokens",
                newName: "TokenID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Banks",
                newName: "BankID");

            migrationBuilder.AlterColumn<string>(
                name: "SejourOrderID",
                table: "Tokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "SejourOrder",
                columns: table => new
                {
                    SejourOrderID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BankID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SejourOrder", x => x.SejourOrderID);
                    table.ForeignKey(
                        name: "FK_SejourOrder_Banks_BankID",
                        column: x => x.BankID,
                        principalTable: "Banks",
                        principalColumn: "BankID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tokens_SejourOrderID",
                table: "Tokens",
                column: "SejourOrderID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SejourOrder_BankID",
                table: "SejourOrder",
                column: "BankID");

            migrationBuilder.AddForeignKey(
                name: "FK_Tokens_SejourOrder_SejourOrderID",
                table: "Tokens",
                column: "SejourOrderID",
                principalTable: "SejourOrder",
                principalColumn: "SejourOrderID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tokens_SejourOrder_SejourOrderID",
                table: "Tokens");

            migrationBuilder.DropTable(
                name: "SejourOrder");

            migrationBuilder.DropIndex(
                name: "IX_Tokens_SejourOrderID",
                table: "Tokens");

            migrationBuilder.RenameColumn(
                name: "TokenID",
                table: "Tokens",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "BankID",
                table: "Banks",
                newName: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "SejourOrderID",
                table: "Tokens",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
