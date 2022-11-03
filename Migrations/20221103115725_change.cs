using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Authorisation.Migrations
{
    public partial class change : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PAssword",
                table: "Users",
                newName: "Password");

            migrationBuilder.AddColumn<int>(
                name: "Key",
                table: "Users",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Key",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Users",
                newName: "PAssword");
        }
    }
}
