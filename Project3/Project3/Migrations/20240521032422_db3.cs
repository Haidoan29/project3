using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project3.Migrations
{
    /// <inheritdoc />
    public partial class db3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Customers_FromStationID",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_FromStationID",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "TrainSchedules");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "TrainSchedules");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "TrainSchedules");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "TrainSchedules");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Trains");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Trains");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Trains");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Trains");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Stations");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Stations");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Stations");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Stations");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Routers");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Routers");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Routers");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Routers");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "ReservationSuperFastFees");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "ReservationSuperFastFees");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "ReservationSuperFastFees");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "ReservationSuperFastFees");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "FareRules");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "FareRules");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "FareRules");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "FareRules");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "DayMasters");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "DayMasters");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "DayMasters");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "DayMasters");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "DailyCashTransactions");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "DailyCashTransactions");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "DailyCashTransactions");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "DailyCashTransactions");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Cancellations");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Cancellations");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Cancellations");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Cancellations");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "CancellationFeeRules");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "CancellationFeeRules");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "CancellationFeeRules");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "CancellationFeeRules");

            migrationBuilder.AddColumn<int>(
                name: "EndStation",
                table: "Routers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_CustomerID",
                table: "Transactions",
                column: "CustomerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Customers_CustomerID",
                table: "Transactions",
                column: "CustomerID",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Customers_CustomerID",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_CustomerID",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "EndStation",
                table: "Routers");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Transactions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Transactions",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "Transactions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Transactions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "TrainSchedules",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "TrainSchedules",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "TrainSchedules",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "TrainSchedules",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Trains",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Trains",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "Trains",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Trains",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Stations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Stations",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "Stations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Stations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Routers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Routers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "Routers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Routers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "ReservationSuperFastFees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "ReservationSuperFastFees",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "ReservationSuperFastFees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "ReservationSuperFastFees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "FareRules",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "FareRules",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "FareRules",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "FareRules",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "DayMasters",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "DayMasters",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "DayMasters",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "DayMasters",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "DailyCashTransactions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "DailyCashTransactions",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "DailyCashTransactions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "DailyCashTransactions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Customers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Cancellations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Cancellations",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "Cancellations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Cancellations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "CancellationFeeRules",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "CancellationFeeRules",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "CancellationFeeRules",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "CancellationFeeRules",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_FromStationID",
                table: "Transactions",
                column: "FromStationID");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Customers_FromStationID",
                table: "Transactions",
                column: "FromStationID",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
