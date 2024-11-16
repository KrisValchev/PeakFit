using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PeakFit.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class TrainingProgramDefaultValueAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                oldComment: "Program's banner");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3ca894f3-b3ef-493f-a694-8c3ef2b2c855",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "75b66673-41c3-4972-9e91-894e13d5e67d", "AQAAAAIAAYagAAAAEGHgxOTbnRai9lzkxKSlYZDK/bGWfut7t6cUmD3GDX2iHYdki8ZwlI6o8quW6XS5qg==", "e7f49f0f-a126-44eb-b403-55aa97fe0691" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "59c4ebcd-35ca-4c88-aa6e-7a356eddc926",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4dbfba17-782d-40e1-a6f4-e0967fd440ef", "AQAAAAIAAYagAAAAEI5AGD2QHm+khaKULRPUHkSWOSK6c3W/xs5pByEm253DoZAXdGp7efCxgtEbr3VcGw==", "5608b458-d919-4a3b-a27f-5ace693e6f1c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e4fe197a-ffd1-45ec-ac7b-a203a82aa523",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e7a03933-9c18-4455-90a4-3c3b198662dd", "AQAAAAIAAYagAAAAENE11OYx3EqsG49I5P2YcHQlYefZPKKsb2YzxPLvxvfBoF1AH0mhNVxuxATaNO8VDQ==", "a30b682a-dfd2-484e-8c8e-38f6d57da18c" });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1,
                column: "StartHour",
                value: new DateTime(2024, 11, 16, 10, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "TrainingPrograms",
                type: "nvarchar(max)",
                nullable: true,
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
                values: new object[] { "6c649a89-dbfa-41e3-8382-a3408ace8538", "AQAAAAIAAYagAAAAEJuL/aWPHYFHaI0/GYnzo7WGb4y2Y6HEMfi9d4vzI9JMlZpi0ZRqbsnV5W0t/5Ewag==", "41a5b3bd-893d-400a-9934-fe576139760b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "59c4ebcd-35ca-4c88-aa6e-7a356eddc926",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ce8da9d4-0596-41db-a49d-1877c37c0f71", "AQAAAAIAAYagAAAAEJry98oATnN7OsxbR8r8JwrfbpP/viVYPp4+epfwe+8LuFaGnP1k2mYB3CibTDbG4A==", "696460cb-145d-4073-9000-dfd6120a0af5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e4fe197a-ffd1-45ec-ac7b-a203a82aa523",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "35b0fc33-da4d-4578-8366-f25ba2229398", "AQAAAAIAAYagAAAAEGfTsCNT0dBx8/X54ZI8kBrB9q92D0XvzzcsMTf5PRt8z90SycrKGzrqzyQbYlGcBQ==", "ee9cb157-a8b0-4d77-b088-7177cf75ac41" });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1,
                column: "StartHour",
                value: new DateTime(2024, 11, 15, 10, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
