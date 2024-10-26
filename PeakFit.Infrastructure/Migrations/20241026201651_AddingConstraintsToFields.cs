using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PeakFit.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddingConstraintsToFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Events",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                comment: "Event's title",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldComment: "Event's title");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Events",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                comment: "Event's description",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldComment: "Event's description");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Comments",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                comment: "Comment's title",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldComment: "Comment's title");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Comments",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                comment: "Comment's description",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldComment: "Comment's description");

            migrationBuilder.AlterColumn<string>(
                name: "CategoryName",
                table: "Categories",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                comment: "Name of category",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldComment: "Name of category");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true,
                comment: "Last name of a user",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldComment: "Last name of a user");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true,
                comment: "First name of a user",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldComment: "First name of a user");

            migrationBuilder.AlterColumn<string>(
                name: "AboutDescription",
                table: "AspNetUsers",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                comment: "Inspirational description about the user",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldComment: "Inspirational description about the user");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Events",
                type: "nvarchar(max)",
                nullable: false,
                comment: "Event's title",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldComment: "Event's title");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Events",
                type: "nvarchar(max)",
                nullable: false,
                comment: "Event's description",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldComment: "Event's description");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Comments",
                type: "nvarchar(max)",
                nullable: false,
                comment: "Comment's title",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldComment: "Comment's title");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Comments",
                type: "nvarchar(max)",
                nullable: false,
                comment: "Comment's description",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldComment: "Comment's description");

            migrationBuilder.AlterColumn<string>(
                name: "CategoryName",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                comment: "Name of category",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldComment: "Name of category");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                comment: "Last name of a user",
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30,
                oldNullable: true,
                oldComment: "Last name of a user");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                comment: "First name of a user",
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30,
                oldNullable: true,
                oldComment: "First name of a user");

            migrationBuilder.AlterColumn<string>(
                name: "AboutDescription",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                comment: "Inspirational description about the user",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true,
                oldComment: "Inspirational description about the user");
        }
    }
}
