using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PeakFit.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class RatingTableCreatedAndSeeded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ratings",
                table: "TrainingPrograms");

            migrationBuilder.CreateTable(
                name: "Ratings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "The user who rated the training program"),
                    TrainingProgramId = table.Column<int>(type: "int", nullable: false, comment: "The training program that is rated")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ratings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ratings_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ratings_TrainingPrograms_TrainingProgramId",
                        column: x => x.TrainingProgramId,
                        principalTable: "TrainingPrograms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                keyValue: "e4fe197a-ffd1-45ec-ac7b-a203a82aa523",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0d536e7d-0318-432a-acc6-d362acea818f", "AQAAAAIAAYagAAAAECHrJn/dr3TD6Mu9WsrkbGtwYvGFNiT9XaifJfxIVUSs6u9LaOMY/CY3mtgibuHQqA==", "6f8a5c9f-c9af-4224-8539-0feef729eb3c" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AboutDescription", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "FirstName", "Gender", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePicture", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "99b6038d-69be-4503-b7e6-baa93b476034", null, 0, "11b21f40-6693-43b8-99b4-291158e25760", "ApplicationUser", "user1@gmail.com", false, "Pesho", "Male", "Peshov", false, null, "user1@gmail.com", "user1@gmail.com", "AQAAAAIAAYagAAAAEKzevaSgJghmqAvq4JfuyDQyzJTMqTN4sd+5yB7W+5eDD+tKcsIqzTdEueH4YQDBgA==", null, false, "https://p7.hiclipart.com/preview/355/848/997/computer-icons-user-profile-google-account-photos-icon-account.jpg", "a690a4a3-cfc7-444d-b9f6-7c5add33ce2c", false, "user1@gmail.com" });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1,
                column: "StartHour",
                value: new DateTime(2024, 11, 22, 10, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "TrainingProgramId", "UserId", "Value" },
                values: new object[,]
                {
                    { 1, 1, "3ca894f3-b3ef-493f-a694-8c3ef2b2c855", 5 },
                    { 2, 1, "99b6038d-69be-4503-b7e6-baa93b476034", 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_TrainingProgramId",
                table: "Ratings",
                column: "TrainingProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_UserId",
                table: "Ratings",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ratings");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "99b6038d-69be-4503-b7e6-baa93b476034");

            migrationBuilder.AddColumn<string>(
                name: "Ratings",
                table: "TrainingPrograms",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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
                column: "StartHour",
                value: new DateTime(2024, 11, 19, 10, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "TrainingPrograms",
                keyColumn: "Id",
                keyValue: 1,
                column: "Ratings",
                value: "[3,3.5,5]");
        }
    }
}
