using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PeakFit.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class NewExerciseTableAddedAndOldOneRenamedToProgramExercise : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exercises_TrainingPrograms_ProgramId",
                table: "Exercises");

            migrationBuilder.DropIndex(
                name: "IX_Exercises_ProgramId",
                table: "Exercises");

            migrationBuilder.DropColumn(
                name: "ProgramId",
                table: "Exercises");

            migrationBuilder.DropColumn(
                name: "Reps",
                table: "Exercises");

            migrationBuilder.DropColumn(
                name: "Sets",
                table: "Exercises");

            migrationBuilder.CreateTable(
                name: "ProgramExercises",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "ProgramExercise identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Reps = table.Column<int>(type: "int", nullable: false, comment: "Repetition count of exercise"),
                    Sets = table.Column<int>(type: "int", nullable: false, comment: "Sets count of exercise"),
                    ProgramId = table.Column<int>(type: "int", nullable: false, comment: "Program identifier"),
                    ExerciseId = table.Column<int>(type: "int", nullable: false, comment: "Exercise identifier")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgramExercises", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProgramExercises_Exercises_ExerciseId",
                        column: x => x.ExerciseId,
                        principalTable: "Exercises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ProgramExercises_TrainingPrograms_ProgramId",
                        column: x => x.ProgramId,
                        principalTable: "TrainingPrograms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3ca894f3-b3ef-493f-a694-8c3ef2b2c855",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6c649a89-dbfa-41e3-8382-a3408ace8538", "AQAAAAIAAYagAAAAEJuL/aWPHYFHaI0/GYnzo7WGb4y2Y6HEMfi9d4vzI9JMlZpi0ZRqbsnV5W0t/5Ewag==", "41a5b3bd-893d-400a-9934-fe576139760b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "59c4ebcd-35ca-4c88-aa6e-7a356eddc926",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ce8da9d4-0596-41db-a49d-1877c37c0f71", "AQAAAAIAAYagAAAAEJry98oATnN7OsxbR8r8JwrfbpP/viVYPp4+epfwe+8LuFaGnP1k2mYB3CibTDbG4A==", "696460cb-145d-4073-9000-dfd6120a0af5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e4fe197a-ffd1-45ec-ac7b-a203a82aa523",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "35b0fc33-da4d-4578-8366-f25ba2229398", "AQAAAAIAAYagAAAAEGfTsCNT0dBx8/X54ZI8kBrB9q92D0XvzzcsMTf5PRt8z90SycrKGzrqzyQbYlGcBQ==", "ee9cb157-a8b0-4d77-b088-7177cf75ac41" });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1,
                column: "StartHour",
                value: new DateTime(2024, 11, 15, 10, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 2,
                column: "ExerciseName",
                value: "LegPress");

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 3,
                column: "ExerciseName",
                value: "HackSquat");

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 4,
                column: "ExerciseName",
                value: "BulgarianSplitSquat");

            migrationBuilder.InsertData(
                table: "ProgramExercises",
                columns: new[] { "Id", "ExerciseId", "ProgramId", "Reps", "Sets" },
                values: new object[,]
                {
                    { 1, 1, 1, 10, 3 },
                    { 2, 2, 1, 10, 3 },
                    { 3, 3, 1, 10, 3 },
                    { 4, 4, 1, 10, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProgramExercises_ExerciseId",
                table: "ProgramExercises",
                column: "ExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_ProgramExercises_ProgramId",
                table: "ProgramExercises",
                column: "ProgramId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProgramExercises");

            migrationBuilder.AddColumn<int>(
                name: "ProgramId",
                table: "Exercises",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "Program identifier");

            migrationBuilder.AddColumn<int>(
                name: "Reps",
                table: "Exercises",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "Repetition count of exercise");

            migrationBuilder.AddColumn<int>(
                name: "Sets",
                table: "Exercises",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "Sets count of exercise");

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

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1,
                column: "StartHour",
                value: new DateTime(2024, 11, 14, 10, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ProgramId", "Reps", "Sets" },
                values: new object[] { 1, 10, 3 });

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ExerciseName", "ProgramId", "Reps", "Sets" },
                values: new object[] { "Leg Press", 1, 10, 3 });

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ExerciseName", "ProgramId", "Reps", "Sets" },
                values: new object[] { "Hack Squat", 1, 10, 3 });

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ExerciseName", "ProgramId", "Reps", "Sets" },
                values: new object[] { "Bulgarian Split Squat", 1, 10, 3 });

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_ProgramId",
                table: "Exercises",
                column: "ProgramId");

            migrationBuilder.AddForeignKey(
                name: "FK_Exercises_TrainingPrograms_ProgramId",
                table: "Exercises",
                column: "ProgramId",
                principalTable: "TrainingPrograms",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }
    }
}
