using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PeakFit.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class TrainerTableRemoved : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_AspNetUsers_TrainerId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainingPrograms_AspNetUsers_TrainerId",
                table: "TrainingPrograms");

            migrationBuilder.DropColumn(
                name: "Ratings",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "TrainerId",
                table: "TrainingPrograms",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_TrainingPrograms_TrainerId",
                table: "TrainingPrograms",
                newName: "IX_TrainingPrograms_UserId");

            migrationBuilder.RenameColumn(
                name: "TrainerId",
                table: "Events",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Events_TrainerId",
                table: "Events",
                newName: "IX_Events_UserId");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "TrainingPrograms",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldComment: "Tells if program is deleted");

            migrationBuilder.AddColumn<string>(
                name: "Ratings",
                table: "TrainingPrograms",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "[]",
                comment: "Tells if program is deleted");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_AspNetUsers_UserId",
                table: "Events",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingPrograms_AspNetUsers_UserId",
                table: "TrainingPrograms",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_AspNetUsers_UserId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainingPrograms_AspNetUsers_UserId",
                table: "TrainingPrograms");

            migrationBuilder.DropColumn(
                name: "Ratings",
                table: "TrainingPrograms");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "TrainingPrograms",
                newName: "TrainerId");

            migrationBuilder.RenameIndex(
                name: "IX_TrainingPrograms_UserId",
                table: "TrainingPrograms",
                newName: "IX_TrainingPrograms_TrainerId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Events",
                newName: "TrainerId");

            migrationBuilder.RenameIndex(
                name: "IX_Events_UserId",
                table: "Events",
                newName: "IX_Events_TrainerId");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "TrainingPrograms",
                type: "bit",
                nullable: false,
                comment: "Tells if program is deleted",
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<string>(
                name: "Ratings",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Events_AspNetUsers_TrainerId",
                table: "Events",
                column: "TrainerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingPrograms_AspNetUsers_TrainerId",
                table: "TrainingPrograms",
                column: "TrainerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
