using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebForum.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addedimageurl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                schema: "public",
                table: "Posts",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                schema: "public",
                table: "FollowedTopics",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                schema: "public",
                table: "Comments",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                schema: "public",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                schema: "public",
                table: "FollowedTopics");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                schema: "public",
                table: "Comments");
        }
    }
}
