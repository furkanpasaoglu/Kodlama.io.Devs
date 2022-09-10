using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kodlama.io.Devs.Persistence.Migrations
{
    public partial class AddedUserSocialMediaAddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserSocialMediaAddresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    GithubUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSocialMediaAddresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserSocialMediaAddresses_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "UserSocialMediaAddresses",
                columns: new[] { "Id", "GithubUrl", "UserId" },
                values: new object[] { 1, "https://github.com/furkanpasaoglu", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_UserSocialMediaAddresses_UserId",
                table: "UserSocialMediaAddresses",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserSocialMediaAddresses");
        }
    }
}
