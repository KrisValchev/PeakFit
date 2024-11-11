using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PeakFit.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class TrainerSeedDataPhoneNumberAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3ca894f3-b3ef-493f-a694-8c3ef2b2c855",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f351086d-75c8-446f-8f3f-5f2939424905", "AQAAAAIAAYagAAAAEDk1C4JD+g6NOtDFmxYv+RQpyCqKjnuVBEoIIho6i08SwqjMtr/50TJH1Q6w0q4htw==", "1def924e-9673-4280-81b9-7463dda5574c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "59c4ebcd-35ca-4c88-aa6e-7a356eddc926",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "PhoneNumber", "SecurityStamp" },
                values: new object[] { "894419cb-ed7e-41f7-91b4-3f3c00f61374", "AQAAAAIAAYagAAAAEOsZ2B/Kjum+Iko3CNgMa+6sxiMPPF4GHCC2B5mM/dLgYCWM1He8o1D5iCN/W9j5jA==", "0878080808", "07feab7e-14f8-4b85-8006-5d38d0369927" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e4fe197a-ffd1-45ec-ac7b-a203a82aa523",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "56744b37-8042-436a-baf9-5727516a11f1", "AQAAAAIAAYagAAAAELcer8kdtbF69RP9NhTe/2bRMK1sTljm9Qr5D3N23L7hrcd61VLHmCmhNUmt+Jylaw==", "87535e52-645f-4ca9-8562-1077a6bf7773" });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1,
                column: "StartHour",
                value: new DateTime(2024, 11, 10, 10, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "PhoneNumber", "SecurityStamp" },
                values: new object[] { "74b78794-56d7-4a07-b5cc-92c76f530446", "AQAAAAIAAYagAAAAEDNZJtzveN1JJzXvNolggKPgT9zUVrwQm74RhNOy7zyRMJ4+XleRljnKuJzom8Nw3A==", null, "9b5df82d-895b-48cb-9efb-8003d77a10c7" });

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
    }
}
