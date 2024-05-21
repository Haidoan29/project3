using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project3.Migrations
{
    /// <inheritdoc />
    public partial class db10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Transactions_FromStationID",
                table: "Transactions",
                column: "FromStationID");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_ToStationID",
                table: "Transactions",
                column: "ToStationID");

            migrationBuilder.CreateIndex(
                name: "IX_TrainSchedules_EndStationID",
                table: "TrainSchedules",
                column: "EndStationID");

            migrationBuilder.CreateIndex(
                name: "IX_TrainSchedules_StartStationID",
                table: "TrainSchedules",
                column: "StartStationID");

            migrationBuilder.CreateIndex(
                name: "IX_Routers_EndStation",
                table: "Routers",
                column: "EndStation");

            migrationBuilder.CreateIndex(
                name: "IX_Routers_StartStationID",
                table: "Routers",
                column: "StartStationID");

            migrationBuilder.AddForeignKey(
                name: "FK_Routers_Stations_EndStation",
                table: "Routers",
                column: "EndStation",
                principalTable: "Stations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Routers_Stations_StartStationID",
                table: "Routers",
                column: "StartStationID",
                principalTable: "Stations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TrainSchedules_Stations_EndStationID",
                table: "TrainSchedules",
                column: "EndStationID",
                principalTable: "Stations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TrainSchedules_Stations_StartStationID",
                table: "TrainSchedules",
                column: "StartStationID",
                principalTable: "Stations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Stations_FromStationID",
                table: "Transactions",
                column: "FromStationID",
                principalTable: "Stations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Stations_ToStationID",
                table: "Transactions",
                column: "ToStationID",
                principalTable: "Stations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Routers_Stations_EndStation",
                table: "Routers");

            migrationBuilder.DropForeignKey(
                name: "FK_Routers_Stations_StartStationID",
                table: "Routers");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainSchedules_Stations_EndStationID",
                table: "TrainSchedules");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainSchedules_Stations_StartStationID",
                table: "TrainSchedules");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Stations_FromStationID",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Stations_ToStationID",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_FromStationID",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_ToStationID",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_TrainSchedules_EndStationID",
                table: "TrainSchedules");

            migrationBuilder.DropIndex(
                name: "IX_TrainSchedules_StartStationID",
                table: "TrainSchedules");

            migrationBuilder.DropIndex(
                name: "IX_Routers_EndStation",
                table: "Routers");

            migrationBuilder.DropIndex(
                name: "IX_Routers_StartStationID",
                table: "Routers");
        }
    }
}
