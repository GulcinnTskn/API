using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Hafta2.Migrations
{
    /// <inheritdoc />
    public partial class SeedGame : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "ID", "Description", "Name", "Price", "Publisher", "ReleaseDate" },
                values: new object[,]
                {
                    { 1, "Whether you're playing Solo or Co-op with friends, League of Legends is a highly competitive, fast paced action-strategy game designed for those who crave a hard fought victory.", "League of Legends", 186.90000000000001, "Riot Games", new DateTime(2009, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "Blend your style and experience on a global, competitive stage. You have 13 rounds to attack and defend your side using sharp gunplay and tactical abilities. And, with one life per-round, you'll need to think faster than your opponent if you want to survive. Take on foes across Competitive and Unranked modes as well as Deathmatch and Spike Rush.", "Valorant", 574.75, "Riot Games", new DateTime(2020, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "Global Offensive (CS: GO) expands upon the team-based action gameplay that it pioneered when it was launched 19 years ago. CS: GO features new maps, characters, weapons, and game modes, and delivers updated versions of the classic CS content", "Counter Strike : Global Offensive", 487.5, "Valve", new DateTime(2012, 8, 21, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "Played by over 20 million Adventurers - Black Desert Online is an open-world, action MMORPG. Experience intense, action-packed combat, battle massive world bosses, fight alongside friends to siege and conquer castles, and train in professions such as fishing, trading, crafting, cooking, and more!", "Black Desert", 193.09, "Pearl Abyss", new DateTime(2018, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "ID",
                keyValue: 4);
        }
    }
}
