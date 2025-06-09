using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace APBDTEST2.Migrations
{
    /// <inheritdoc />
    public partial class AddData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Concert",
                columns: new[] { "ConcertId", "AvailableTickets", "Date", "Name" },
                values: new object[,]
                {
                    { 1, 20, new DateTime(2025, 6, 9, 16, 15, 3, 833, DateTimeKind.Local).AddTicks(3978), "Concert 1" },
                    { 2, 30, new DateTime(2025, 6, 9, 16, 15, 3, 833, DateTimeKind.Local).AddTicks(4033), "Concert 2" }
                });

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "CustomerId", "FirstName", "LastName", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "John", "Doe", "0123123123123" },
                    { 2, "Jane", "Doe", null }
                });

            migrationBuilder.InsertData(
                table: "Ticket",
                columns: new[] { "TicketId", "SeatNumber", "SerialNumber" },
                values: new object[,]
                {
                    { 1, 20, "asdf/134/asdf" },
                    { 2, 5, "asdf/134/1234f" }
                });

            migrationBuilder.InsertData(
                table: "Ticket_Concert",
                columns: new[] { "TicketConcertId", "ConcertId", "Price", "TicketId" },
                values: new object[,]
                {
                    { 1, 1, 25.699999999999999, 1 },
                    { 2, 2, 30.0, 2 }
                });

            migrationBuilder.InsertData(
                table: "Purchased_Ticket",
                columns: new[] { "CustomerId", "TicketConcertId", "PurchaseDate" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 6, 9, 16, 15, 3, 833, DateTimeKind.Local).AddTicks(4258) },
                    { 2, 2, new DateTime(2025, 6, 9, 16, 15, 3, 833, DateTimeKind.Local).AddTicks(4265) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Purchased_Ticket",
                keyColumns: new[] { "CustomerId", "TicketConcertId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "Purchased_Ticket",
                keyColumns: new[] { "CustomerId", "TicketConcertId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "CustomerId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "CustomerId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Ticket_Concert",
                keyColumn: "TicketConcertId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Ticket_Concert",
                keyColumn: "TicketConcertId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Concert",
                keyColumn: "ConcertId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Concert",
                keyColumn: "ConcertId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Ticket",
                keyColumn: "TicketId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Ticket",
                keyColumn: "TicketId",
                keyValue: 2);
        }
    }
}
