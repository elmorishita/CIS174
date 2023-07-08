using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OlympicGames.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    GameId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.GameId);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    CountryId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CountryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    GameId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    FlagImage = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.CountryId);
                    table.ForeignKey(
                        name: "FK_Countries_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Countries_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "GameId");
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name" },
                values: new object[,]
                {
                    { "archery", "Archery/Indoor" },
                    { "bobsleigh", "Bobsleigh/Outdoor" },
                    { "break", "Breakdancing/Indoor" },
                    { "canoe", "Canoe Sprint/Outdoor" },
                    { "curling", "Curling/Indoor" },
                    { "cycling", "Road Cycling/Outdoor" },
                    { "diving", "Diving/Indoor" },
                    { "skateboard", "Skateboarding/Outdoor" }
                });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "GameId", "Name" },
                values: new object[,]
                {
                    { "paralympics", "Paralympics" },
                    { "summer", "Summer Olympics" },
                    { "winter", "Winter Olympics" },
                    { "youth", "Youth Olympic Games" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "CountryId", "CategoryId", "CountryName", "FlagImage", "GameId" },
                values: new object[,]
                {
                    { "as", "canoe", "Austria", "tn_as-flag.gif", "paralympics" },
                    { "br", "cycling", "Brazil", "tn_br-flag.gif", "summer" },
                    { "ca", "curling", "Canada ", "tn_ca-flag.gif", "winter" },
                    { "ch", "diving", "China", "tn_ch-flag.gif", "summer" },
                    { "ci", "skateboard", "Chile", "tn_ci-flag.gif", "paralympics" },
                    { "cy", "break", "Cyprus", "tn_cy-flag.gif", "youth" },
                    { "fi", "skateboard", "Finland", "tn_fi-flag.gif", "youth" },
                    { "fr", "break", "France", "tn_fr-flag.gif", "youth" },
                    { "gm", "diving", "Germany", "tn_gm-flag.gif", "summer" },
                    { "it", "bobsleigh", "Italy", "tn_it-flag.gif", "winter" },
                    { "ja", "bobsleigh", "Japan", "tn_ja-flag.gif", "winter" },
                    { "jm", "bobsleigh", "Jamaica", "tn_jm-flag.gif", "winter" },
                    { "lo", "skateboard", "Slovakia", "tn_lo-flag.gif", "youth" },
                    { "mx", "diving", "Mexico", "tn_mx-flag.gif", "summer" },
                    { "nl", "cycling", "Netherlands", "tn_nl-flag.gif", "summer" },
                    { "pk", "canoe", "Pakistan ", "tn_pk-flag.gif", "paralympics" },
                    { "po", "skateboard", "Portugal", "tn_po-flag.gif", "youth" },
                    { "rs", "break", "Russia", "tn_rs-flag.gif", "youth" },
                    { "sw", "curling", "Sweden ", "tn_sw-flag.gif", "winter" },
                    { "th", "archery", "Thailand", "tn_th-flag.gif", "paralympics" },
                    { "uk", "curling", "United Kingdom", "tn_uk-flag.gif", "winter" },
                    { "up", "archery", "Ukraine", "tn_up-flag.gif", "paralympics" },
                    { "us", "cycling", "USA", "tn_us-flag.gif", "summer" },
                    { "uy", "archery", "Uruguay", "tn_uy-flag.gif", "paralympics" },
                    { "zi", "canoe", "Zimbabwe", "tn_zi-flag.gif", "paralympics" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Countries_CategoryId",
                table: "Countries",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_GameId",
                table: "Countries",
                column: "GameId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Games");
        }
    }
}
