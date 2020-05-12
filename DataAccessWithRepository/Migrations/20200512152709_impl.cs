using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessWithRepository.Migrations
{
    public partial class impl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "comment_reaction",
                columns: table => new
                {
                    react_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    commernt_id = table.Column<int>(nullable: false),
                    user_id = table.Column<string>(nullable: true),
                    like = table.Column<bool>(nullable: false),
                    dislike = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_comment_reaction", x => x.react_id);
                });

            migrationBuilder.CreateTable(
                name: "comments",
                columns: table => new
                {
                    comment_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    post_id = table.Column<int>(nullable: false),
                    comment = table.Column<string>(nullable: true),
                    user_id = table.Column<string>(nullable: true),
                    date = table.Column<string>(nullable: true),
                    time = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_comments", x => x.comment_id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "comment_reaction");

            migrationBuilder.DropTable(
                name: "comments");
        }
    }
}
