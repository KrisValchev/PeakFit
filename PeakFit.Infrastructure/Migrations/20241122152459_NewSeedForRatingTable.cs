using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PeakFit.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class NewSeedForRatingTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 1,
                column: "UserId",
                value: "99b6038d-69be-4503-b7e6-baa93b476034");

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 2,
                column: "UserId",
                value: "3ca894f3-b3ef-493f-a694-8c3ef2b2c855");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3ca894f3-b3ef-493f-a694-8c3ef2b2c855",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "93a28d2d-aaa1-4444-ba1d-60212dfc2de4", "AQAAAAIAAYagAAAAEF8bZxwp7DVvLUbrhkrX4jQmlRva4Vd/b203o0eqKy/aQoey0ku/xJu9/AfrD5A5Ag==", "30f53640-7abd-45c6-815d-d136f9cf46d2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "59c4ebcd-35ca-4c88-aa6e-7a356eddc926",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c57d98c6-572e-4645-84f7-829a32bb1c32", "AQAAAAIAAYagAAAAEJug9PTD0GGBXLoDqJ3JJx9xB03FuTFVsn23m8yaDzuoae0u4sRe/nPCaCukQnb9ZQ==", "0028a496-2ada-46e1-b5ec-628a811232df" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "99b6038d-69be-4503-b7e6-baa93b476034",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5734578f-5cb5-4d9e-ba82-34adfa9ad80b", "AQAAAAIAAYagAAAAEMM0vqc24AE6SHjICutktxFnhBv9Z41m/lC3Q7pmx2OKoKTmqc0NnrBy8q3bj0CMJA==", "4054ed30-05c3-45e6-ac98-7731a440c88c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e4fe197a-ffd1-45ec-ac7b-a203a82aa523",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9201fd51-cc66-433c-bf00-ca7c3b1a52df", "AQAAAAIAAYagAAAAEF9WpE898KHPDIlREeDPCVg4caRzyHemTfuvnk528UxkNGFfoY0miL97mfBskgPS9A==", "ea217580-795a-42b9-ba41-b4bde5bba86c" });

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 1,
                column: "UserId",
                value: "3ca894f3-b3ef-493f-a694-8c3ef2b2c855");

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 2,
                column: "UserId",
                value: "99b6038d-69be-4503-b7e6-baa93b476034");
        }
    }
}
