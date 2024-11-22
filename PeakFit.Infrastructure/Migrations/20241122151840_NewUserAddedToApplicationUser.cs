using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PeakFit.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class NewUserAddedToApplicationUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3ca894f3-b3ef-493f-a694-8c3ef2b2c855",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b908a139-8978-4f8a-b4eb-8232289a915d", "AQAAAAIAAYagAAAAEJ39U3R8C5dSmTat2IQWf5byckZd1MWRfnJA2yJzqPkYFw1J+DgfO7Uh9Q57mUBtog==", "def3af11-3ed5-4a0b-87ef-756e5bdf58fe" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "59c4ebcd-35ca-4c88-aa6e-7a356eddc926",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b95990c1-c765-4bb6-a9cd-f0daedc88f9f", "AQAAAAIAAYagAAAAEOmIZSMquiNVO72NkfxOeQ0dA4NkY5ZF/BHdV5hiH5YeaJ3yFGVi09ffbSwKqDSlWw==", "81b5f4ce-e721-488c-8bcf-11ac5851404d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "99b6038d-69be-4503-b7e6-baa93b476034",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "11b21f40-6693-43b8-99b4-291158e25760", "AQAAAAIAAYagAAAAEKzevaSgJghmqAvq4JfuyDQyzJTMqTN4sd+5yB7W+5eDD+tKcsIqzTdEueH4YQDBgA==", "a690a4a3-cfc7-444d-b9f6-7c5add33ce2c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e4fe197a-ffd1-45ec-ac7b-a203a82aa523",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0d536e7d-0318-432a-acc6-d362acea818f", "AQAAAAIAAYagAAAAECHrJn/dr3TD6Mu9WsrkbGtwYvGFNiT9XaifJfxIVUSs6u9LaOMY/CY3mtgibuHQqA==", "6f8a5c9f-c9af-4224-8539-0feef729eb3c" });
        }
    }
}
