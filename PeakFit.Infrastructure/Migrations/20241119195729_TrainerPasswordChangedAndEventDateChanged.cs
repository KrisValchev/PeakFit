using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PeakFit.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class TrainerPasswordChangedAndEventDateChanged : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3ca894f3-b3ef-493f-a694-8c3ef2b2c855",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a9bc18ca-c799-4ff2-b29f-8bf2e08fee65", "AQAAAAIAAYagAAAAEOFja2nN02X4lAIxR69lsykvQAgpH+AiMCvv2WPwQl5mBUvhEzzNNr0WR+fOE3dddg==", "e7dd51d1-5cbc-4870-b3ae-0515fd6807a5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "59c4ebcd-35ca-4c88-aa6e-7a356eddc926",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "25f7fedf-6d38-4055-af41-3613382cf64c", "AQAAAAIAAYagAAAAELc6Ubjznxe6HBVqkxYtLwWJKoLKKDtwCtcd+6IKag9j84pogfN9/0/037A8M/o3HQ==", "04eac7fd-08d5-4d8a-afb1-51dda2765e70" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e4fe197a-ffd1-45ec-ac7b-a203a82aa523",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a96186d5-f7c6-4356-bf2c-a97516d0803f", "AQAAAAIAAYagAAAAEJadG8RpLrwbsffrbTGNQGjwqyHBvq9KhYzMdY8UpTYvMnxjAzXraJnpprHOeU9Fuw==", "9d217301-83ab-461f-8cfa-0f2893c2506a" });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "StartDate", "StartHour" },
                values: new object[] { new DateTime(2024, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 19, 10, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3ca894f3-b3ef-493f-a694-8c3ef2b2c855",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "64fa5aa2-eb28-4f66-bd96-3edb3d3808c7", "AQAAAAIAAYagAAAAEPXATHzPkHJHT0yR/8CHKJ0bCq4FL6An8WQlHwdFyjfUdZtzV+VpRfX88KwOGxLGuQ==", "33a3c59c-4fc5-4fb1-8d83-5bf970ddda94" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "59c4ebcd-35ca-4c88-aa6e-7a356eddc926",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a1482116-4fd0-4b9b-a965-21855486942d", "AQAAAAIAAYagAAAAEP2VKGC1ZLtHfVjAw5JFWB4Z8ekRXp4yC+H80m9wMlkPDmizCdR9t5BhzyVbgQGXlw==", "f9382552-c6df-45f1-b3ab-df7103751f58" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e4fe197a-ffd1-45ec-ac7b-a203a82aa523",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "54502832-b7e3-46e3-bf76-53057895ea81", "AQAAAAIAAYagAAAAEMWniYQMDJwI9W55y6Fb2hFHpG9kD06PRtpVEnWJBekJ4hSCA+/2lvS+ot+lYSgbOg==", "ad894282-6940-4bed-b7d5-fa85fb078811" });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "StartDate", "StartHour" },
                values: new object[] { new DateTime(2024, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 17, 10, 0, 0, 0, DateTimeKind.Unspecified) });
        }
    }
}
