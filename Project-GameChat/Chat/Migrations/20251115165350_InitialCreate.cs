using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Chat.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Achievements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    EarnedOnDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Achievements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Achievements_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameTitle = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Content = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommentTitle = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Content = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    PostId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "IsDeleted", "UserName" },
                values: new object[,]
                {
                    { 1, "pro@abv.bg", false, "ProGamer2000" },
                    { 2, "cyber@abv.bg", false, "CyberWarrior" },
                    { 3, "strategy@abv.bg", false, "StrategyQueen" },
                    { 4, "LetsGameItOut@gmail.com", false, "LetsGameItOut" },
                    { 5, "MaxLevelIdot@gmail.com", false, "MaxLevelIdot" }
                });

            migrationBuilder.InsertData(
                table: "Achievements",
                columns: new[] { "Id", "Description", "EarnedOnDate", "IsDeleted", "Title", "UserId" },
                values: new object[,]
                {
                    { 1, "Published your first game review", new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "First Post", 1 },
                    { 2, "Left 5+ comments", new DateTime(2024, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Comment Master", 2 },
                    { 3, "Specialized in Strategy games", new DateTime(2024, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Strategy Expert", 3 },
                    { 4, "Reviewed 3+ indie games", new DateTime(2024, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Indie Explorer", 4 },
                    { 5, "Created a post about automation or factory-building games", new DateTime(2024, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Factory Overlord", 4 },
                    { 6, "Posted multiple FPS-related reviews", new DateTime(2024, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "FPS Veteran", 1 },
                    { 7, "Shared expert tips about tower defense games", new DateTime(2024, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Tower Defense Guru", 5 },
                    { 8, "Left helpful comments on 5 different posts", new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Community Helper", 2 }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Content", "GameTitle", "IsDeleted", "UserId" },
                values: new object[,]
                {
                    { 1, "Just finished The Witcher 3! Amazing storyline!", "The Witcher 3", false, 1 },
                    { 2, "played the new Cyberpunk 2077 and the storyline and the game play is amazing!", "Cyberpunk 2077", false, 2 },
                    { 3, "Civilization VI is consuming my life. One more turn!", "Civilization VI", false, 3 },
                    { 4, "Huge congrats to Satisfactory for finally going global! I cannot wait to sink an irresponsible amount of time into this game and absolutely ruin my sleep schedule all over again. Here's to building factories so needlessly complicated that even future me will question my life choices. Let the chaos begin!", "Satisfactory", false, 4 },
                    { 5, "New COD game is bad compared to what they did with Battlefield 6!", "Call of Duty", false, 1 },
                    { 6, "Bro, let's be real — the best hero in Bloons TD 6 is whoever lets me AFK the longest without the whole map exploding. Absolutely best strategy.", "Bloons TD 6", false, 5 }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "CommentTitle", "Content", "IsDeleted", "PostId", "UserId" },
                values: new object[,]
                {
                    { 1, "Congrats!", "Congrats on finishing The Witcher! That ending hits hard!", false, 1, 2 },
                    { 2, "Welcome!", "Welcome to the Cyberpunk fandom! The updates made the game so much better.", false, 2, 1 },
                    { 3, "I know!", "Civ VI is dangerously addictive. One more turn? More like 200.", false, 3, 4 },
                    { 4, "Factory black hole", "Satisfactory is basically a productivity black hole, but in a good way.", false, 4, 3 },
                    { 5, "Multiplayer", "COD multiplayer still slaps, even if the campaign is questionable.", false, 5, 2 },
                    { 6, "AFK Gang", "AFK meta in Bloons? Best gameplay.", false, 6, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Achievements_UserId",
                table: "Achievements",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PostId",
                table: "Comments",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_UserId",
                table: "Posts",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Achievements");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
