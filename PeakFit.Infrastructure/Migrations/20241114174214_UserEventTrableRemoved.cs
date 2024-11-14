using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PeakFit.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class UserEventTrableRemoved : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsersEvents");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3ca894f3-b3ef-493f-a694-8c3ef2b2c855",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ce739765-f0f8-4d75-8d80-8c22462a41ad", "AQAAAAIAAYagAAAAED9H66jdWHeFNZJLQVVwQ6S3ODqXvE6Zv0N/KdiTV/5H7OG0Ct5OPfilM1F66Z6Pzw==", "deeaf171-ccc8-42d0-81a0-89ef539afc29" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "59c4ebcd-35ca-4c88-aa6e-7a356eddc926",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a7f42dc1-8fcd-4b00-a6db-ba6467b6c8fb", "AQAAAAIAAYagAAAAEOzWJ5Fla/HbaJebMFyYY/Dy2HuHO0ZDm+QpMoulQg2E1pt3SZVZTU59b5iZPNG/7g==", "9caf91ed-c155-41d7-8078-d8d2c124b301" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e4fe197a-ffd1-45ec-ac7b-a203a82aa523",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "788cc415-ee9e-496e-a95d-4266663e265b", "AQAAAAIAAYagAAAAEIJsioHVbWFw8OWhuUwVOyO/LhIEIKPMQFuQ++Yfdd6Y3W7GOhpMuEDpTsQ7XKvmXg==", "00211b29-f8ff-4a10-a97b-a2c539504c81" });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1,
                column: "StartHour",
                value: new DateTime(2024, 11, 14, 10, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UsersEvents",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "User identifier"),
                    EventId = table.Column<int>(type: "int", nullable: false, comment: "Which event the user is subscriber to")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersEvents", x => new { x.UserId, x.EventId });
                    table.ForeignKey(
                        name: "FK_UsersEvents_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsersEvents_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3ca894f3-b3ef-493f-a694-8c3ef2b2c855",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4c0557bc-fb14-4531-851a-6a10181dcae2", "AQAAAAIAAYagAAAAELWCx7V7Jvx81U8L5VkqDGMVmHOQoNHdzNH0jxrDAQnSF41nVaCiE87XJttMrIaHTQ==", "7df3b73b-2b1b-4b63-a970-20a7157ca761" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "59c4ebcd-35ca-4c88-aa6e-7a356eddc926",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "23d8677d-a34c-4efb-9a92-60172df53b35", "AQAAAAIAAYagAAAAEIevJft2O5HUuNYWKXo87wO57j3RL/502mpt9XEBzVEq0zs7ISOYN95Xtk4BmQ4Vog==", "603274b0-739f-4ea3-94a0-588fb800c612" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e4fe197a-ffd1-45ec-ac7b-a203a82aa523",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "aace7156-7fab-4f45-9c38-346bba6c4487", "AQAAAAIAAYagAAAAEORd9E/J2oLvG3WrU01GYzOhP+0nHyeKPcqMh/9SxiTRJa7o+FNIvNfps8TBBzvyLA==", "383f0e5f-ee8a-4712-b1de-cdf2814bdc9a" });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1,
                column: "StartHour",
                value: new DateTime(2024, 11, 13, 10, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_UsersEvents_EventId",
                table: "UsersEvents",
                column: "EventId");
        }
    }
}
