using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PeakFit.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedPhoneNumberToAdminEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3ca894f3-b3ef-493f-a694-8c3ef2b2c855",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "01880611-793f-42eb-95a7-2ec27b705e78", "AQAAAAIAAYagAAAAEJ7F3talcMCA9vVpb4no0FLAEWN6dZZ91+cqYq3fc5dPeQDRNt/7q/Ugr24m4xJ47g==", "a641684d-1b80-4a8d-b15e-a0cc26610f30" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "59c4ebcd-35ca-4c88-aa6e-7a356eddc926",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6742f395-5dc0-40af-973e-72adffb002fe", "AQAAAAIAAYagAAAAEDGTx3lHs75IDFuB8gqVwsqmkhhGfXFAILAjj6ThFoRsrJLBYj/uFX2GHOhJJybOBQ==", "cc5dcb1d-993e-401c-bb41-e29e97ec3231" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "99b6038d-69be-4503-b7e6-baa93b476034",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b5be463d-2b2f-4045-9a7c-b35dec6eceff", "AQAAAAIAAYagAAAAEC+CIGy2W3CMUKJjpoFxj4TgCjatPTPOhC9tsw0V2YeS8o+vMgyeyv+SYMzIQxhj3w==", "8d99c93d-0ed1-42bd-bed4-372b2cce748e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e4fe197a-ffd1-45ec-ac7b-a203a82aa523",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "PhoneNumber", "SecurityStamp" },
                values: new object[] { "2665bf64-ee47-48e3-a995-c3525cc23d68", "AQAAAAIAAYagAAAAEJEvvu4jkKsAVCq/HDY6O7MwzzXNLGiuIGvf5ChpBPzH3OH+JfZmzOyAUoS+FEtSFg==", "089999999", "551f4cda-a8df-4f4a-9791-db61385530a6" });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1,
                column: "StartHour",
                value: new DateTime(2024, 11, 30, 10, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "PhoneNumber", "SecurityStamp" },
                values: new object[] { "207331f7-d0b7-4294-966c-bb8bab28beb5", "AQAAAAIAAYagAAAAEGGKVvGR5904v2zAdOpo0zsQ9ZqXJ6PU5WSvqyHuDcx7JCWABUTgJ3KcV87zF+Lpmw==", null, "1bbc794b-0c2a-4348-a565-84d07b2fabb5" });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1,
                column: "StartHour",
                value: new DateTime(2024, 11, 23, 10, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
