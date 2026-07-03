using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebForum.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addeddelete_fieldinposts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Post",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Post");
        }
    }
}
