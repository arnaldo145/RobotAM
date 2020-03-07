using Microsoft.EntityFrameworkCore.Migrations;

namespace KraftwerkAPI.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LeftArm",
                table: "Robot",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RightArm",
                table: "Robot",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LeftArm",
                table: "Robot");

            migrationBuilder.DropColumn(
                name: "RightArm",
                table: "Robot");
        }
    }
}
