using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PeakFit.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class AdminAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3ca894f3-b3ef-493f-a694-8c3ef2b2c855",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "524519ca-50b8-4469-a912-6ac900021cec", "AQAAAAIAAYagAAAAEAVC2n4WZYRKhn6v51Q09wRxQy9hZFuyPj5yOsdwHfM5xH+DDzmi3KTU/nTpQI4XjA==", "dd5f545f-ba7f-4bfe-bdd1-cda833b4f7f5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "59c4ebcd-35ca-4c88-aa6e-7a356eddc926",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2dc88107-7529-4514-ae3b-40a8e90a7668", "AQAAAAIAAYagAAAAEPk+gFVsHE0v10RyzKwAguTkdoYcq/NiaT0iDPODeWNG15ZstZWyjf58gS+8B76KRg==", "8719a74f-3b8a-4d91-8bd7-773acfe6a308" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e4fe197a-ffd1-45ec-ac7b-a203a82aa523",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8c38d50e-d007-47dc-9f0e-4690c514b7af", "AQAAAAIAAYagAAAAEFk+CfhSuhFvnSV0w4FzOj9oEF3q87a8Edj7Zafu9eo4UsaIcKTcfbo6908ZcvGaJw==", "220bd0b3-0af7-4a98-b7c7-ed8ff56d6aba" });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1,
                column: "StartHour",
                value: new DateTime(2024, 11, 11, 10, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
