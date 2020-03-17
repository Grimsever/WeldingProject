using Microsoft.EntityFrameworkCore.Migrations;

namespace WeldingAnalyz.Data.Migrations
{
    public partial class ReWriteEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Amperages_MachineDatas_MachineDataId",
                table: "Amperages");

            migrationBuilder.DropForeignKey(
                name: "FK_Machines_MachineDatas_MachineDataId",
                table: "Machines");

            migrationBuilder.DropForeignKey(
                name: "FK_Machines_Tasks_TaskId",
                table: "Machines");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Workers_WorkerId",
                table: "Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_TechnologicalMaps_Tasks_TaskId",
                table: "TechnologicalMaps");

            migrationBuilder.DropForeignKey(
                name: "FK_Voltages_MachineDatas_MachineDataId",
                table: "Voltages");

            migrationBuilder.DropForeignKey(
                name: "FK_Workers_Foremans_ForemanId",
                table: "Workers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Workers",
                table: "Workers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TechnologicalMaps",
                table: "TechnologicalMaps");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tasks",
                table: "Tasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Machines",
                table: "Machines");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MachineDatas",
                table: "MachineDatas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Foremans",
                table: "Foremans");

            migrationBuilder.DropColumn(
                name: "WorkerID",
                table: "Workers");

            migrationBuilder.DropColumn(
                name: "TechnologicalMapId",
                table: "TechnologicalMaps");

            migrationBuilder.DropColumn(
                name: "TaskId",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "MachineId",
                table: "Machines");

            migrationBuilder.DropColumn(
                name: "MachineDataId",
                table: "MachineDatas");

            migrationBuilder.DropColumn(
                name: "ForemanId",
                table: "Foremans");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Workers",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "TechnologicalMaps",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "TechnologicalMaps",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Tasks",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Tasks",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Machines",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Machines",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "MachineDatas",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "MachineDatas",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Foremans",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Workers",
                table: "Workers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TechnologicalMaps",
                table: "TechnologicalMaps",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tasks",
                table: "Tasks",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Machines",
                table: "Machines",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MachineDatas",
                table: "MachineDatas",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Foremans",
                table: "Foremans",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Amperages_MachineDatas_MachineDataId",
                table: "Amperages",
                column: "MachineDataId",
                principalTable: "MachineDatas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Machines_MachineDatas_MachineDataId",
                table: "Machines",
                column: "MachineDataId",
                principalTable: "MachineDatas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Machines_Tasks_TaskId",
                table: "Machines",
                column: "TaskId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Workers_WorkerId",
                table: "Tasks",
                column: "WorkerId",
                principalTable: "Workers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TechnologicalMaps_Tasks_TaskId",
                table: "TechnologicalMaps",
                column: "TaskId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Voltages_MachineDatas_MachineDataId",
                table: "Voltages",
                column: "MachineDataId",
                principalTable: "MachineDatas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Workers_Foremans_ForemanId",
                table: "Workers",
                column: "ForemanId",
                principalTable: "Foremans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Amperages_MachineDatas_MachineDataId",
                table: "Amperages");

            migrationBuilder.DropForeignKey(
                name: "FK_Machines_MachineDatas_MachineDataId",
                table: "Machines");

            migrationBuilder.DropForeignKey(
                name: "FK_Machines_Tasks_TaskId",
                table: "Machines");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Workers_WorkerId",
                table: "Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_TechnologicalMaps_Tasks_TaskId",
                table: "TechnologicalMaps");

            migrationBuilder.DropForeignKey(
                name: "FK_Voltages_MachineDatas_MachineDataId",
                table: "Voltages");

            migrationBuilder.DropForeignKey(
                name: "FK_Workers_Foremans_ForemanId",
                table: "Workers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Workers",
                table: "Workers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TechnologicalMaps",
                table: "TechnologicalMaps");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tasks",
                table: "Tasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Machines",
                table: "Machines");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MachineDatas",
                table: "MachineDatas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Foremans",
                table: "Foremans");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Workers");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "TechnologicalMaps");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "TechnologicalMaps");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Machines");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Machines");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "MachineDatas");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "MachineDatas");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Foremans");

            migrationBuilder.AddColumn<int>(
                name: "WorkerID",
                table: "Workers",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "TechnologicalMapId",
                table: "TechnologicalMaps",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "TaskId",
                table: "Tasks",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "MachineId",
                table: "Machines",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "MachineDataId",
                table: "MachineDatas",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "ForemanId",
                table: "Foremans",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Workers",
                table: "Workers",
                column: "WorkerID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TechnologicalMaps",
                table: "TechnologicalMaps",
                column: "TechnologicalMapId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tasks",
                table: "Tasks",
                column: "TaskId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Machines",
                table: "Machines",
                column: "MachineId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MachineDatas",
                table: "MachineDatas",
                column: "MachineDataId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Foremans",
                table: "Foremans",
                column: "ForemanId");

            migrationBuilder.AddForeignKey(
                name: "FK_Amperages_MachineDatas_MachineDataId",
                table: "Amperages",
                column: "MachineDataId",
                principalTable: "MachineDatas",
                principalColumn: "MachineDataId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Machines_MachineDatas_MachineDataId",
                table: "Machines",
                column: "MachineDataId",
                principalTable: "MachineDatas",
                principalColumn: "MachineDataId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Machines_Tasks_TaskId",
                table: "Machines",
                column: "TaskId",
                principalTable: "Tasks",
                principalColumn: "TaskId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Workers_WorkerId",
                table: "Tasks",
                column: "WorkerId",
                principalTable: "Workers",
                principalColumn: "WorkerID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TechnologicalMaps_Tasks_TaskId",
                table: "TechnologicalMaps",
                column: "TaskId",
                principalTable: "Tasks",
                principalColumn: "TaskId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Voltages_MachineDatas_MachineDataId",
                table: "Voltages",
                column: "MachineDataId",
                principalTable: "MachineDatas",
                principalColumn: "MachineDataId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Workers_Foremans_ForemanId",
                table: "Workers",
                column: "ForemanId",
                principalTable: "Foremans",
                principalColumn: "ForemanId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
