using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PeakFit.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class EventImageUrlNotNull : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Events",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                comment: "Event's banner",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldComment: "Event's banner");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3ca894f3-b3ef-493f-a694-8c3ef2b2c855",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f593ec14-0ccc-4a5d-a1d9-1abb2ec6cb0d", "AQAAAAIAAYagAAAAEBCAUOD4OIgUYT+5EZUbAafyf4yk2//1zoK+FVDBbEFzBc1Sgk+g03IJmFwO1ff1Sw==", "cc5109af-defb-41ae-a9c1-4935d27da0fb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "59c4ebcd-35ca-4c88-aa6e-7a356eddc926",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "74b78794-56d7-4a07-b5cc-92c76f530446", "AQAAAAIAAYagAAAAEDNZJtzveN1JJzXvNolggKPgT9zUVrwQm74RhNOy7zyRMJ4+XleRljnKuJzom8Nw3A==", "9b5df82d-895b-48cb-9efb-8003d77a10c7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e4fe197a-ffd1-45ec-ac7b-a203a82aa523",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0e61876d-b273-43c9-8044-e7ba8420b719", "AQAAAAIAAYagAAAAEFayYpBfcl2IicX2M5/o265D2y51ZZfnfQ+xpanODAbnGBng9LuKHL8FIsb97G809Q==", "62680fcc-3bb6-4809-b53e-9a03b168db08" });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1,
                column: "StartHour",
                value: new DateTime(2024, 11, 4, 10, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Events",
                type: "nvarchar(max)",
                nullable: true,
                comment: "Event's banner",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldComment: "Event's banner");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3ca894f3-b3ef-493f-a694-8c3ef2b2c855",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0ae23e7b-0f98-4167-a69b-701075128060", "AQAAAAIAAYagAAAAEL1GzB0C4tBqd3GcteYnalSM2PDF5mAtRaR1klJabYXxPFgdO8SwTDeIak+FBBTbkg==", "3e4412ec-6c64-4252-be56-3e11d935ab00" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "59c4ebcd-35ca-4c88-aa6e-7a356eddc926",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "357ba73f-87a3-49f2-953d-026651613a6f", "AQAAAAIAAYagAAAAEOYBcciK7awS8IrbOF0gB5zZVs6cPhpThU/40N9emO1j5wDJ0r07WSGbkTnyahg1UA==", "7afb4c1e-41ee-4705-b0cb-4589f9cffe51" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e4fe197a-ffd1-45ec-ac7b-a203a82aa523",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "68f3a365-88d0-40a9-a6ac-2580e659cfbd", "AQAAAAIAAYagAAAAELxfM3EYaO6ZbU17TyHQrYpIXpIUgvlLAT1hzXk3GDdeXOCOY70mf2z7fb2qJszdfg==", "59bd9e71-8b79-461e-8b68-1b5ee97103f4" });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1,
                column: "StartHour",
                value: new DateTime(2024, 11, 2, 10, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
