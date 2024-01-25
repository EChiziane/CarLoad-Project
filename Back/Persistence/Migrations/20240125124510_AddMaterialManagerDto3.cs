using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class AddMaterialManagerDto3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "PurchaseMoney",
                table: "CarLoads",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<decimal>(
                name: "DriverExpenses",
                table: "CarLoads",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Expenses",
                table: "CarLoads",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ManagerExpenses",
                table: "CarLoads",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DriverExpenses",
                table: "CarLoads");

            migrationBuilder.DropColumn(
                name: "Expenses",
                table: "CarLoads");

            migrationBuilder.DropColumn(
                name: "ManagerExpenses",
                table: "CarLoads");

            migrationBuilder.AlterColumn<int>(
                name: "PurchaseMoney",
                table: "CarLoads",
                type: "integer",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");
        }
    }
}
