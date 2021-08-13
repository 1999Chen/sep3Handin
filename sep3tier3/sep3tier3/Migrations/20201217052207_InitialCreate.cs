using Microsoft.EntityFrameworkCore.Migrations;

namespace sep3tier3.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChatMessages",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nameSend = table.Column<string>(type: "TEXT", nullable: true),
                    nameReceived = table.Column<string>(type: "TEXT", nullable: true),
                    message = table.Column<string>(type: "TEXT", nullable: true),
                    date = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatMessages", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Friends",
                columns: table => new
                {
                    username1 = table.Column<string>(type: "TEXT", nullable: false),
                    username2 = table.Column<string>(type: "TEXT", nullable: false),
                    accept = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Friends", x => new { x.username1, x.username2 });
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    username = table.Column<string>(type: "TEXT", nullable: false),
                    password = table.Column<string>(type: "TEXT", nullable: true),
                    firstname = table.Column<string>(type: "TEXT", nullable: true),
                    lastname = table.Column<string>(type: "TEXT", nullable: true),
                    birthday = table.Column<string>(type: "TEXT", nullable: true),
                    sex = table.Column<string>(type: "TEXT", nullable: true),
                    major = table.Column<string>(type: "TEXT", nullable: true),
                    hometown = table.Column<string>(type: "TEXT", nullable: true),
                    description = table.Column<string>(type: "TEXT", nullable: true),
                    age = table.Column<int>(type: "INTEGER", nullable: false),
                    hobbies = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.username);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChatMessages");

            migrationBuilder.DropTable(
                name: "Friends");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
