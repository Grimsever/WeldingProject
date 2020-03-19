using Microsoft.EntityFrameworkCore.Migrations;

namespace WeldingAnalyz.Data.Migrations
{
    public partial class ReWriteMachineModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Machines_Tasks_TaskId",
                table: "Machines");

            migrationBuilder.DropIndex(
                name: "IX_Machines_TaskId",
                table: "Machines");

            migrationBuilder.AlterColumn<int>(
                name: "TaskId",
                table: "Machines",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Machines_TaskId",
                table: "Machines",
                column: "TaskId",
                unique: true,
                filter: "[TaskId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Machines_Tasks_TaskId",
                table: "Machines",
                column: "TaskId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Machines_Tasks_TaskId",
                table: "Machines");

            migrationBuilder.DropIndex(
                name: "IX_Machines_TaskId",
                table: "Machines");

            migrationBuilder.AlterColumn<int>(
                name: "TaskId",
                table: "Machines",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Machines_TaskId",
                table: "Machines",
                column: "TaskId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Machines_Tasks_TaskId",
                table: "Machines",
                column: "TaskId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
