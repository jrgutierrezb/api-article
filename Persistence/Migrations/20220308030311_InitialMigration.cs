using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sources",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sources", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PublishedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SourceId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_Sources_SourceId",
                        column: x => x.SourceId,
                        principalTable: "Sources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Sources",
                columns: new[] { "Id", "Name", "Url" },
                values: new object[,]
                {
                    { 1L, "The Irish Sun", "https://www.thesun.ie" },
                    { 2L, "The Boston Globe", "https://www.bostonglobe.com" },
                    { 3L, "The Indian Express", "https://indianexpress.com" },
                    { 4L, "Birmingham Live", "https://www.birminghammail.co.uk" }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Content", "Description", "Image", "PublishedAt", "SourceId", "Title", "Url" },
                values: new object[,]
                {
                    { 1L, "PIERS Morgan fought back tears over his close friend Shane Warne's death while watching an emotional TV tribute.\nRemembering Shane Warne - a repeat documentary in honour of the cricketing legend - is being aired on Sky.\n2 Shane Warne with Piers Morga... [1688 chars]", "PIERS Morgan fought back tears over his close friend Shane Warne's death while watching an emotional TV tribute.Remembering Shane Warne - a repeat doc", "https://www.thesun.ie/wp-content/uploads/sites/3/2022/03/comp-skc-shane-warne-piers.jpg?strip=all&quality=100&w=1200&h=800&crop=1", new DateTime(2022, 3, 7, 22, 3, 11, 184, DateTimeKind.Local).AddTicks(3451), 1L, "Piers Morgan fights back tears over pal Shane Warne's death as he watches emotional TV tribute", "https://www.thesun.ie/tv/8464762/piers-morgan-fights-back-tears-shane-warne-death/" },
                    { 2L, "Governments, think tanks, and analysts around the world had been asking the same questions. But Rinaldi, a teacher at Newton South High School, and his young minds, a group of seniors in his comparative politics and world government seminar, happened... [6697 chars]", "As the war in Ukraine unfolds, teachers have the unique obligation to balance giving students information and historical context about the conflict, while also quelling theirs fears and anxiety", "https://bostonglobe-prod.cdn.arcpublishing.com/resizer/Pr3Nd9bEjaAn4uiNcAsuDoH4kmI=/506x0/cloudfront-us-east-1.images.arcpublishing.com/bostonglobe/5CFA2HR2ZRB2DI6RJOILVP7ASY.jpg", new DateTime(2022, 3, 7, 22, 3, 11, 186, DateTimeKind.Local).AddTicks(5431), 2L, "As the world watches the war in Ukraine, educators are facing the challenges of teaching history in real time", "https://www.bostonglobe.com/2022/03/06/metro/world-watches-war-ukraine-educators-are-facing-challenges-teaching-history-real-time/" },
                    { 3L, "Amid dark times, we look for a reprieve in cinema or books. The last two years, however, have produced few mood lifters as both the film industry and OTT platforms seem partial towards dark thrillers, murder mysteries, social dramas or biopics. Where... [4149 chars]", "Today, when Bollywood’s idea of comedies involve a fair degree of sexism, Angoor comes across as simple, clean, and a crisp comedy-drama. Here's revisiting the Gulzar directorial as it completes 40 years of its release.", "https://images.indianexpress.com/2022/03/angoor-40-years.jpg", new DateTime(2022, 3, 7, 22, 3, 11, 186, DateTimeKind.Local).AddTicks(5632), 3L, "A millennial watches Angoor: In dark times, revisiting Gulzar’s cult classic", "https://indianexpress.com/article/entertainment/bollywood/a-millennial-watches-angoor-in-dark-times-revisiting-gulzars-cult-classic-7802072/" },
                    { 4L, "Bruno Lage has reiterated his support for Max Kilman but he doesn’t believe the Wolves defender’s recent struggles should be attributed to the war in Ukraine.\nKilman’s mother, Maria, is Ukrainian and the Wolves defender was contacted by Andriy Shevch... [2668 chars]", "Wolverhampton Wanderers head coach Bruno Lage has been discussing England hopeful Max Kilman's form", "https://i2-prod.birminghammail.co.uk/sport/football/football-news/article23308507.ece/ALTERNATES/s1200/0_JS259676123.jpg", new DateTime(2022, 3, 7, 22, 3, 11, 186, DateTimeKind.Local).AddTicks(5636), 4L, "Bruno Lage makes Max Kilman admission after Gareth Southgate watches Wolves horror show", "https://www.birminghammail.co.uk/sport/football/football-news/wolves-max-kilman-southgate-england-23308321" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Posts_SourceId",
                table: "Posts",
                column: "SourceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Sources");
        }
    }
}
