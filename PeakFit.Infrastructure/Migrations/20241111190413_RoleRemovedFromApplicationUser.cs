using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PeakFit.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class RoleRemovedFromApplicationUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                table: "AspNetUsers");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                comment: "User's role");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3ca894f3-b3ef-493f-a694-8c3ef2b2c855",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "Role", "SecurityStamp" },
                values: new object[] { "f351086d-75c8-446f-8f3f-5f2939424905", "AQAAAAIAAYagAAAAEDk1C4JD+g6NOtDFmxYv+RQpyCqKjnuVBEoIIho6i08SwqjMtr/50TJH1Q6w0q4htw==", "User", "1def924e-9673-4280-81b9-7463dda5574c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "59c4ebcd-35ca-4c88-aa6e-7a356eddc926",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "Role", "SecurityStamp" },
                values: new object[] { "894419cb-ed7e-41f7-91b4-3f3c00f61374", "AQAAAAIAAYagAAAAEOsZ2B/Kjum+Iko3CNgMa+6sxiMPPF4GHCC2B5mM/dLgYCWM1He8o1D5iCN/W9j5jA==", "Trainer", "07feab7e-14f8-4b85-8006-5d38d0369927" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e4fe197a-ffd1-45ec-ac7b-a203a82aa523",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "Role", "SecurityStamp" },
                values: new object[] { "56744b37-8042-436a-baf9-5727516a11f1", "AQAAAAIAAYagAAAAELcer8kdtbF69RP9NhTe/2bRMK1sTljm9Qr5D3N23L7hrcd61VLHmCmhNUmt+Jylaw==", "Administrator", "87535e52-645f-4ca9-8562-1077a6bf7773" });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1,
                column: "StartHour",
                value: new DateTime(2024, 11, 10, 10, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
