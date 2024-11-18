using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PeakFit.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class NewExercisesAddedToExerciseConfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "Exercises",
                columns: new[] { "Id", "CategoryId", "ExerciseName" },
                values: new object[,]
                {
                    { 5, 5, "Squat" },
                    { 6, 5, "Lunge" },
                    { 7, 5, "Calf Raise" },
                    { 8, 2, "Bicep Curl" },
                    { 9, 2, "Tricep Dip" },
                    { 10, 2, "Hammer Curl" },
                    { 11, 2, "Overhead Tricep Extension" },
                    { 12, 2, "Concentration Curl" },
                    { 13, 2, "Close Grip Bench Press" },
                    { 14, 1, "Plank" },
                    { 15, 1, "Crunch" },
                    { 16, 1, "Russian Twist" },
                    { 17, 1, "Mountain Climbers" },
                    { 18, 1, "Leg Raises" },
                    { 19, 1, "Side Plank" },
                    { 20, 3, "Pull Up" },
                    { 21, 3, "Lat Pulldown" },
                    { 22, 3, "Barbell Row" },
                    { 23, 3, "T-Bar Row" },
                    { 24, 3, "Seated Cable Row" },
                    { 25, 4, "Bench Press" },
                    { 26, 4, "Incline Bench Press" },
                    { 27, 4, "Chest Fly" },
                    { 28, 4, "Push Up" },
                    { 29, 4, "Dumbbell Pullover" },
                    { 30, 4, "Cable Crossover" },
                    { 31, 6, "Overhead Press" },
                    { 32, 6, "Arnold Press" },
                    { 33, 6, "Lateral Raise" },
                    { 34, 6, "Front Raise" },
                    { 35, 6, "Face Pull" },
                    { 36, 6, "Upright Row" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3ca894f3-b3ef-493f-a694-8c3ef2b2c855",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "83cb1867-a77b-474e-8335-5516f7fa8076", "AQAAAAIAAYagAAAAEG/Uc9B2FlwdpgciTWoyPV+06Fj6Ql2jZSyS/SYtaVYcN/q3t8me32fUJ2gwjd7S+w==", "48500885-d951-47b3-966a-6cf2795fb1d0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "59c4ebcd-35ca-4c88-aa6e-7a356eddc926",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "48f1c402-8450-40e0-9db5-d5f3d07fc76a", "AQAAAAIAAYagAAAAELBxjdlx77DV1Kz6HccXMn6kfCiKCD1UiPKBvAnxAHXIy9PA4qi/pbUC0YFsaJw8dg==", "1fdaa728-e3d1-4293-aef7-93d8af9ec537" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e4fe197a-ffd1-45ec-ac7b-a203a82aa523",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e998b251-c2de-4f16-bef4-a2bebe491ad4", "AQAAAAIAAYagAAAAELDJOFC/6uTT+iDVvTQI/HPUAUCecw808NFeqkRzNVB9kTRCLgfbAVLsTcdObb4alA==", "126da8f6-ec2a-409e-9c58-fdfcaa0b6503" });
        }
    }
}
