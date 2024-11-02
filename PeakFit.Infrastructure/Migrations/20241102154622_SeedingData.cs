using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PeakFit.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedingData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Events",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                comment: "Event's description",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldComment: "Event's description");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AboutDescription", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "FirstName", "Gender", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePicture", "Role", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "3ca894f3-b3ef-493f-a694-8c3ef2b2c855", null, 0, "0ae23e7b-0f98-4167-a69b-701075128060", "ApplicationUser", "user@gmail.com", false, "User", "Male", "User", false, null, "user@gmail.com", "user@gmail.com", "AQAAAAIAAYagAAAAEL1GzB0C4tBqd3GcteYnalSM2PDF5mAtRaR1klJabYXxPFgdO8SwTDeIak+FBBTbkg==", null, false, "https://p7.hiclipart.com/preview/355/848/997/computer-icons-user-profile-google-account-photos-icon-account.jpg", "User", "3e4412ec-6c64-4252-be56-3e11d935ab00", false, "user@gmail.com" },
                    { "59c4ebcd-35ca-4c88-aa6e-7a356eddc926", null, 0, "357ba73f-87a3-49f2-953d-026651613a6f", "ApplicationUser", "trainer@gmail.com", false, "Trainer", "Female", "Trainer", false, null, "trainer@gmail.com", "trainer@gmail.com", "AQAAAAIAAYagAAAAEOYBcciK7awS8IrbOF0gB5zZVs6cPhpThU/40N9emO1j5wDJ0r07WSGbkTnyahg1UA==", null, false, "https://www.pngitem.com/pimgs/m/146-1468479_my-profile-icon-blank-profile-picture-circle-hd.png", "Trainer", "7afb4c1e-41ee-4705-b0cb-4589f9cffe51", false, "trainer@gmail.com" },
                    { "e4fe197a-ffd1-45ec-ac7b-a203a82aa523", null, 0, "68f3a365-88d0-40a9-a6ac-2580e659cfbd", "ApplicationUser", "admin@gmail.com", false, "Admin", "Male", "Admin", false, null, "admin@gmail.com", "admin@gmail.com", "AQAAAAIAAYagAAAAELxfM3EYaO6ZbU17TyHQrYpIXpIUgvlLAT1hzXk3GDdeXOCOY70mf2z7fb2qJszdfg==", null, false, "https://www.pngmart.com/files/21/Admin-Profile-Vector-PNG-Clipart.png", "Administrator", "59bd9e71-8b79-461e-8b68-1b5ee97103f4", false, "admin@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CategoryName" },
                values: new object[,]
                {
                    { 1, "Core" },
                    { 2, "Arms" },
                    { 3, "Back" },
                    { 4, "Chest" },
                    { 5, "Legs" },
                    { 6, "Shoulders" }
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "Description", "ImageUrl", "IsDeleted", "StartDate", "StartHour", "Title", "UserId" },
                values: new object[] { 1, "The Marathon is an exhilarating long-distance running event, bringing together athletes, enthusiasts, and supporters for a memorable day of endurance and community spirit. Held in Plovdiv, this marathon offers participants a chance to challenge themselves across a scenic and well-marked route, catering to runners of all experience levels, from seasoned marathoners to those aiming to complete their first 42.195 kilometers.", "https://raceid.com/organizer/wp-content/uploads/2022/08/cost-marathon-featured-image-blog-10.png", false, new DateTime(2024, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 2, 10, 0, 0, 0, DateTimeKind.Unspecified), "Marathon", "59c4ebcd-35ca-4c88-aa6e-7a356eddc926" });

            migrationBuilder.InsertData(
                table: "TrainingPrograms",
                columns: new[] { "Id", "CategoryId", "ImageUrl", "IsDeleted", "Ratings", "UserId" },
                values: new object[] { 1, 5, "https://athleanx.com/wp-content/uploads/2022/09/LEG-WORKOUTS.png", false, "[3,3.5,5]", "59c4ebcd-35ca-4c88-aa6e-7a356eddc926" });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Description", "EventId", "IsDeleted", "PostedOn", "Title", "UserId" },
                values: new object[] { 1, "I can't wait untill the beginning of the event. It's going to be awesome!", 1, false, new DateTime(2024, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Big excitement", "3ca894f3-b3ef-493f-a694-8c3ef2b2c855" });

            migrationBuilder.InsertData(
                table: "Exercises",
                columns: new[] { "Id", "CategoryId", "ExerciseName", "ProgramId", "Reps", "Sets" },
                values: new object[,]
                {
                    { 1, 5, "Deadlift", 1, 10, 3 },
                    { 2, 5, "Leg Press", 1, 10, 3 },
                    { 3, 5, "Hack Squat", 1, 10, 3 },
                    { 4, 5, "Bulgarian Split Squat", 1, 10, 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e4fe197a-ffd1-45ec-ac7b-a203a82aa523");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3ca894f3-b3ef-493f-a694-8c3ef2b2c855");

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TrainingPrograms",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "59c4ebcd-35ca-4c88-aa6e-7a356eddc926");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Events",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                comment: "Event's description",
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000,
                oldComment: "Event's description");
        }
    }
}
