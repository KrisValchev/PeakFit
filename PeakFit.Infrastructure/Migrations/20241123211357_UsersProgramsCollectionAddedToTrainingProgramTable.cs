using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PeakFit.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class UsersProgramsCollectionAddedToTrainingProgramTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3ca894f3-b3ef-493f-a694-8c3ef2b2c855",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "631a3ccc-83f5-4e25-a16a-179e32e0ddc0", "AQAAAAIAAYagAAAAEIopBju422BBJdvnqFwaA2O0lFamDqUaGPQ4KjLWwtUAy0F8Q5ttW2sB4GjAEPoAEA==", "c5491aa4-c04e-4660-b6ce-a643f806c2c6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "59c4ebcd-35ca-4c88-aa6e-7a356eddc926",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "070c72af-4a42-41f9-b6e9-c693ff510235", "AQAAAAIAAYagAAAAENVMJEHrbeKqIjq3ROJnFd8FTBwnQpnAtTmRHHu7iwL8zQwIj7RkZl4tDVxIuNVCyg==", "77599a2e-7ff4-4393-824f-91724cfbfe8d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "99b6038d-69be-4503-b7e6-baa93b476034",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "918bdf55-4e32-46d7-b40a-0ddd50a5912e", "AQAAAAIAAYagAAAAECgVGbNP2KBH6i1Sxb6xrDqnl4xEfzL6myvQiuSSfP14IUqBM8s9k2397o0AMFGalQ==", "5503fde0-cd41-46dc-ac1e-b7a4d2accc20" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e4fe197a-ffd1-45ec-ac7b-a203a82aa523",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "207331f7-d0b7-4294-966c-bb8bab28beb5", "AQAAAAIAAYagAAAAEGGKVvGR5904v2zAdOpo0zsQ9ZqXJ6PU5WSvqyHuDcx7JCWABUTgJ3KcV87zF+Lpmw==", "1bbc794b-0c2a-4348-a565-84d07b2fabb5" });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1,
                column: "StartHour",
                value: new DateTime(2024, 11, 23, 10, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3ca894f3-b3ef-493f-a694-8c3ef2b2c855",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "060dcbee-5f16-4311-9134-77ef0b7fd901", "AQAAAAIAAYagAAAAEBqBaSni2U+kFpZ91FwCB3QNxi41wjMQ5HfAjw7esLiqzKeey3KB6z5HCcq7DRLYvQ==", "1cd87dbe-2753-4536-a729-23adaa5cc785" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "59c4ebcd-35ca-4c88-aa6e-7a356eddc926",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "935ee059-d4cb-4ce3-8ada-04e2aae13f70", "AQAAAAIAAYagAAAAEJz02HCcqZiJ1XJCARpgglpo7zUgLfnLc8La5Ls9ICfGVUQ/4YtZ/UIiLFVZq5Zraw==", "78e24795-9b27-4826-ac5b-f2df15bc2bfe" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "99b6038d-69be-4503-b7e6-baa93b476034",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0b502e7e-7651-4a7a-9a09-390888e87868", "AQAAAAIAAYagAAAAEOpUb7r/roOQqcLQU3gHte2aHGV3Cj0W8iFjtHwcbbYt0On6y9MpBU10TVvC6xl4jg==", "93b62b10-774e-4e88-8642-47208ba4575c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e4fe197a-ffd1-45ec-ac7b-a203a82aa523",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c8a0277e-2226-4d75-b69f-0c8cf8814a45", "AQAAAAIAAYagAAAAEI4S746syyRDyz5LeKdZUmprSd4Ck5cv3JCFCvQ7AQxrcg2kAMyhWtw0Qj6ajtNUrQ==", "75a35a55-6f9b-454a-9c7d-f85199066b60" });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1,
                column: "StartHour",
                value: new DateTime(2024, 11, 22, 10, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
