using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TDS_CarPark.API.Migrations
{
    /// <inheritdoc />
    public partial class MigrationAndSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VehicleType",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cost = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Space",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SpaceNumber = table.Column<int>(type: "int", nullable: false),
                    IsOccupied = table.Column<bool>(type: "bit", nullable: false),
                    VehicleReg = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VehicleTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TimeIn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Space", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Space_VehicleType_VehicleTypeId",
                        column: x => x.VehicleTypeId,
                        principalTable: "VehicleType",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Space",
                columns: new[] { "Id", "IsOccupied", "SpaceNumber", "TimeIn", "VehicleReg", "VehicleTypeId" },
                values: new object[,]
                {
                    { new Guid("a1d4f2e8-1001-4b8a-9b12-444444444441"), false, 1, null, null, null },
                    { new Guid("a1d4f2e8-1002-4b8a-9b12-444444444442"), false, 2, null, null, null },
                    { new Guid("a1d4f2e8-1003-4b8a-9b12-444444444443"), false, 3, null, null, null },
                    { new Guid("a1d4f2e8-1004-4b8a-9b12-444444444444"), false, 4, null, null, null },
                    { new Guid("a1d4f2e8-1005-4b8a-9b12-444444444445"), false, 5, null, null, null },
                    { new Guid("a1d4f2e8-1006-4b8a-9b12-444444444446"), false, 6, null, null, null },
                    { new Guid("a1d4f2e8-1007-4b8a-9b12-444444444447"), false, 7, null, null, null },
                    { new Guid("a1d4f2e8-1008-4b8a-9b12-444444444448"), false, 8, null, null, null },
                    { new Guid("a1d4f2e8-1009-4b8a-9b12-444444444449"), false, 9, null, null, null }
                });

            migrationBuilder.InsertData(
                table: "VehicleType",
                columns: new[] { "Id", "Cost", "Name", "Number" },
                values: new object[,]
                {
                    { new Guid("a1d4f2e8-0001-4b8a-9b12-111111111111"), 0.10000000000000001, "Small Car", 1 },
                    { new Guid("a1d4f2e8-0002-4b8a-9b12-222222222222"), 0.20000000000000001, "Medium Car", 2 },
                    { new Guid("a1d4f2e8-0003-4b8a-9b12-333333333333"), 0.40000000000000002, "Large Car", 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Space_VehicleTypeId",
                table: "Space",
                column: "VehicleTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Space");

            migrationBuilder.DropTable(
                name: "VehicleType");
        }
    }
}
