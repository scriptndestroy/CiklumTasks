using Microsoft.EntityFrameworkCore.Migrations;

namespace CiklumTasks.Model.Migrations
{
    public partial class add_task_props : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                schema: "dbo",
                table: "Task",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                schema: "dbo",
                table: "Task",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                schema: "dbo",
                table: "Task",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                schema: "dbo",
                table: "Task");

            migrationBuilder.DropColumn(
                name: "Status",
                schema: "dbo",
                table: "Task");

            migrationBuilder.DropColumn(
                name: "Title",
                schema: "dbo",
                table: "Task");
        }
    }
}
