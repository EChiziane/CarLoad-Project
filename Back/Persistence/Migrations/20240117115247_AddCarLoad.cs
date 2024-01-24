using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Persistence.Migrations
{
    public partial class AddCarLoad : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CarLoads",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Destination = table.Column<string>(type: "text", nullable: false),
                    Earnings = table.Column<decimal>(type: "numeric", nullable: false),
                    FuelExpense = table.Column<decimal>(type: "numeric", nullable: false),
                    PoliceExpense = table.Column<decimal>(type: "numeric", nullable: false),
                    DriverName = table.Column<string>(type: "text", nullable: false),
                    ManagerName = table.Column<string>(type: "text", nullable: false),
                    ClientName = table.Column<string>(type: "text", nullable: false),
                    CargoName = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastUpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId = table.Column<string>(type: "text", nullable: true),
                    LastUpdatedByUserId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarLoads", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarLoads_AspNetUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CarLoads_AspNetUsers_LastUpdatedByUserId",
                        column: x => x.LastUpdatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarLoads_CreatedByUserId",
                table: "CarLoads",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CarLoads_LastUpdatedByUserId",
                table: "CarLoads",
                column: "LastUpdatedByUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarLoads");
        }
    }
}
