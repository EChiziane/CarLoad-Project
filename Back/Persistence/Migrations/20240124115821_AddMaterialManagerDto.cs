using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class AddMaterialManagerDto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CargoName",
                table: "CarLoads");

            migrationBuilder.DropColumn(
                name: "ClientName",
                table: "CarLoads");

            migrationBuilder.DropColumn(
                name: "DriverName",
                table: "CarLoads");

            migrationBuilder.DropColumn(
                name: "ManagerName",
                table: "CarLoads");

            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                table: "CarLoads",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DriverId",
                table: "CarLoads",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ManagerId",
                table: "CarLoads",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MaterialId",
                table: "CarLoads",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CarLoads_ClientId",
                table: "CarLoads",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_CarLoads_DriverId",
                table: "CarLoads",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "IX_CarLoads_ManagerId",
                table: "CarLoads",
                column: "ManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_CarLoads_MaterialId",
                table: "CarLoads",
                column: "MaterialId");

            migrationBuilder.AddForeignKey(
                name: "FK_CarLoads_Clients_ClientId",
                table: "CarLoads",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CarLoads_Drivers_DriverId",
                table: "CarLoads",
                column: "DriverId",
                principalTable: "Drivers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CarLoads_Managers_ManagerId",
                table: "CarLoads",
                column: "ManagerId",
                principalTable: "Managers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CarLoads_Materials_MaterialId",
                table: "CarLoads",
                column: "MaterialId",
                principalTable: "Materials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarLoads_Clients_ClientId",
                table: "CarLoads");

            migrationBuilder.DropForeignKey(
                name: "FK_CarLoads_Drivers_DriverId",
                table: "CarLoads");

            migrationBuilder.DropForeignKey(
                name: "FK_CarLoads_Managers_ManagerId",
                table: "CarLoads");

            migrationBuilder.DropForeignKey(
                name: "FK_CarLoads_Materials_MaterialId",
                table: "CarLoads");

            migrationBuilder.DropIndex(
                name: "IX_CarLoads_ClientId",
                table: "CarLoads");

            migrationBuilder.DropIndex(
                name: "IX_CarLoads_DriverId",
                table: "CarLoads");

            migrationBuilder.DropIndex(
                name: "IX_CarLoads_ManagerId",
                table: "CarLoads");

            migrationBuilder.DropIndex(
                name: "IX_CarLoads_MaterialId",
                table: "CarLoads");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "CarLoads");

            migrationBuilder.DropColumn(
                name: "DriverId",
                table: "CarLoads");

            migrationBuilder.DropColumn(
                name: "ManagerId",
                table: "CarLoads");

            migrationBuilder.DropColumn(
                name: "MaterialId",
                table: "CarLoads");

            migrationBuilder.AddColumn<string>(
                name: "CargoName",
                table: "CarLoads",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ClientName",
                table: "CarLoads",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DriverName",
                table: "CarLoads",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ManagerName",
                table: "CarLoads",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
