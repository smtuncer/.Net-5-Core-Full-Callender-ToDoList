using Microsoft.EntityFrameworkCore.Migrations;

namespace ToDoList.Migrations
{
    public partial class mig2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Nots",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Nots_UserId",
                table: "Nots",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Nots_Users_UserId",
                table: "Nots",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Nots_Users_UserId",
                table: "Nots");

            migrationBuilder.DropIndex(
                name: "IX_Nots_UserId",
                table: "Nots");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Nots");
        }
    }
}
