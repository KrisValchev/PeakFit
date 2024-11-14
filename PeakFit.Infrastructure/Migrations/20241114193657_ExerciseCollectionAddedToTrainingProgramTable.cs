using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PeakFit.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class ExerciseCollectionAddedToTrainingProgramTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Ratings",
                table: "TrainingPrograms",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldComment: "Tells if program is deleted");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "TrainingPrograms",
                type: "bit",
                nullable: false,
                comment: "Tells if program is deleted",
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3ca894f3-b3ef-493f-a694-8c3ef2b2c855",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4b4cdf74-ccc5-405b-95e9-98ce9acbccaf", "AQAAAAIAAYagAAAAEASm0tTw9AO1m+5NNAAYUvHDGTp6OTdsA7T7kbUS+GFv/iRKg0UjBr4/8IY9xQ5UPA==", "9a74e0df-ea55-4b79-a248-a5a6a4a495d0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "59c4ebcd-35ca-4c88-aa6e-7a356eddc926",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a4a6b663-892a-468e-bfa5-267392528a4e", "AQAAAAIAAYagAAAAEO72H1Y7kmD6oulhLH0dkP4ENuEyH3CbNGXhps3xVlD9LyP3dbHtp0LC5pLdCS/Dfg==", "2c7378e9-b4a6-4c5c-8fbc-872a11177a3c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e4fe197a-ffd1-45ec-ac7b-a203a82aa523",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "748c801d-1609-4811-8ee2-31c6fdec2d72", "AQAAAAIAAYagAAAAEIrXXNRzZ2/HH9qezCtByhG2EaYGRRiCbWUi0kP5FwLodikm0BHC7rSo901KqRoE/g==", "ec861c35-ad9e-400e-a633-43e728db15dd" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Ratings",
                table: "TrainingPrograms",
                type: "nvarchar(max)",
                nullable: false,
                comment: "Tells if program is deleted",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "TrainingPrograms",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldComment: "Tells if program is deleted");

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
        }
    }
}
