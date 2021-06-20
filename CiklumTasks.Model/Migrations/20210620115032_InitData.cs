using Microsoft.EntityFrameworkCore.Migrations;

namespace CiklumTasks.Model.Migrations
{
    public partial class InitData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "TaskStatus",
                columns: new[] { "Id", "Description", "Value" },
                values: new object[] { 1, "To Do", "TD" }
                );
            migrationBuilder.InsertData(
                table: "TaskStatus",
                columns: new[] { "Id", "Description", "Value" },
                values: new object[] { 2, "Done", "D" }
                );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            
        }
    }
}
