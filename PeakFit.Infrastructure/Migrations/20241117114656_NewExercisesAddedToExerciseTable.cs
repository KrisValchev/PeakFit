using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PeakFit.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class NewExercisesAddedToExerciseTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3ca894f3-b3ef-493f-a694-8c3ef2b2c855",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "83cb1867-a77b-474e-8335-5516f7fa8076", "AQAAAAIAAYagAAAAEG/Uc9B2FlwdpgciTWoyPV+06Fj6Ql2jZSyS/SYtaVYcN/q3t8me32fUJ2gwjd7S+w==", "48500885-d951-47b3-966a-6cf2795fb1d0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "59c4ebcd-35ca-4c88-aa6e-7a356eddc926",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "48f1c402-8450-40e0-9db5-d5f3d07fc76a", "AQAAAAIAAYagAAAAELBxjdlx77DV1Kz6HccXMn6kfCiKCD1UiPKBvAnxAHXIy9PA4qi/pbUC0YFsaJw8dg==", "1fdaa728-e3d1-4293-aef7-93d8af9ec537" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e4fe197a-ffd1-45ec-ac7b-a203a82aa523",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e998b251-c2de-4f16-bef4-a2bebe491ad4", "AQAAAAIAAYagAAAAELDJOFC/6uTT+iDVvTQI/HPUAUCecw808NFeqkRzNVB9kTRCLgfbAVLsTcdObb4alA==", "126da8f6-ec2a-409e-9c58-fdfcaa0b6503" });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1,
                column: "StartHour",
                value: new DateTime(2024, 11, 17, 10, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 4,
                column: "ExerciseName",
                value: "Bulgarian Split Squat");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 4,
                column: "ExerciseName",
                value: "BulgarianSplitSquat");
        }
    }
}
