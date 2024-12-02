using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PeakFit.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class NewDefaultImageValueForTrainingProgram : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "TrainingPrograms",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "https://media.self.com/photos/6398b36c72eb56f726777d06/master/pass/weekly-workout-schedule.jpeg",
                comment: "Program's banner",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldDefaultValue: "https://w7.pngwing.com/pngs/83/516/png-transparent-workout-dumbbells-weightlifting-dumbell-gym-thumbnail.png",
                oldComment: "Program's banner");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3ca894f3-b3ef-493f-a694-8c3ef2b2c855",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "24cece18-24fd-499a-a378-c0ba4e0474d2", "AQAAAAIAAYagAAAAELzr/xfrUPPnj/BHwdqpfKs9prNwQYHwOa1ZPQLzJsAroGD7uubBPmDAaO+c0LlJYg==", "b93493ea-bfd7-4ca9-a3cf-2334587a9545" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "59c4ebcd-35ca-4c88-aa6e-7a356eddc926",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "48bd6729-bd77-435d-ab5c-123062fc16a3", "AQAAAAIAAYagAAAAENzxH6bpFU43oWG8p7igCEqzQ3r7e5NfS1Ej/fo8EdGjnA0SQQWyUDne9+0R4VcvOw==", "e34d03cc-8a0a-452b-80c0-91072d009f01" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "99b6038d-69be-4503-b7e6-baa93b476034",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c05ed514-d429-4f70-8ab7-093787998a78", "AQAAAAIAAYagAAAAEJvV7NtiMRDFaGLburkmjfOOnu0qiJlvYeHqKt9iIU8rqRO0IeWeWCXkHlkYIHaH7A==", "c07a88df-e9d5-4870-91dd-0946a34f9f47" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e4fe197a-ffd1-45ec-ac7b-a203a82aa523",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "de909a31-88c1-4728-96d3-a665c0bf5d17", "AQAAAAIAAYagAAAAEPk8Aeb4sbgYNZNDxDRtvfXSNlcGTqA+b8h8UWf5rv49Tw3kZHXa28of1F1h4oQ8iQ==", "a34b747b-b9b3-490f-b575-3d83da566782" });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1,
                column: "StartHour",
                value: new DateTime(2024, 12, 2, 10, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "TrainingPrograms",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "https://w7.pngwing.com/pngs/83/516/png-transparent-workout-dumbbells-weightlifting-dumbell-gym-thumbnail.png",
                comment: "Program's banner",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldDefaultValue: "https://media.self.com/photos/6398b36c72eb56f726777d06/master/pass/weekly-workout-schedule.jpeg",
                oldComment: "Program's banner");

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
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2665bf64-ee47-48e3-a995-c3525cc23d68", "AQAAAAIAAYagAAAAEJEvvu4jkKsAVCq/HDY6O7MwzzXNLGiuIGvf5ChpBPzH3OH+JfZmzOyAUoS+FEtSFg==", "551f4cda-a8df-4f4a-9791-db61385530a6" });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1,
                column: "StartHour",
                value: new DateTime(2024, 11, 30, 10, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
