using Hafta_2.Models;
using Microsoft.EntityFrameworkCore;

namespace Hafta_2.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Game> Games { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>().HasData(
                new Game
                {
                    ID = 1,
                    Name = "League of Legends",
                    Description = "Whether you're playing Solo or Co-op with friends, " +
                    "League of Legends is a highly competitive, fast paced action-strategy " +
                    "game designed for those who crave a hard fought victory.",
                    Price = 186.90,
                    Publisher = "Riot Games",
                    ReleaseDate = new DateTime(2009, 10, 27)

                },
                new Game
                {
                    ID = 2,
                    Name = "Valorant",
                    Description = "Blend your style and experience on a global, " +
                    "competitive stage. You have 13 rounds to attack and defend your side " +
                    "using sharp gunplay and tactical abilities. And, with one life per-round, " +
                    "you'll need to think faster than your opponent if you want to survive." +
                    " Take on foes across Competitive and Unranked modes as well as Deathmatch and Spike Rush.",
                    Price = 574.75,
                    Publisher = "Riot Games",
                    ReleaseDate = new DateTime(2020, 06, 02)

                },
                new Game
                {
                    ID = 3,
                    Name = "Counter Strike : Global Offensive",
                    Description = "Global Offensive (CS: GO) expands " +
                    "upon the team-based action gameplay that it pioneered when it was launched 19 years ago. " +
                    "CS: GO features new maps, characters, weapons, and game modes, and delivers " +
                    "updated versions of the classic CS content",
                    Price = 487.50,
                    Publisher = "Valve",
                    ReleaseDate = new DateTime(2012, 08, 21)

                },
                new Game
                {
                    ID = 4,
                    Name = "Black Desert",
                    Description = "Played by over 20 million Adventurers - Black Desert Online is an open-world, " +
                    "action MMORPG. Experience intense, action-packed combat, battle massive world bosses, " +
                    "fight alongside friends to siege and conquer castles, and train in professions such as fishing, " +
                    "trading, crafting, cooking, and more!",
                    Price = 193.09,
                    Publisher = "Pearl Abyss",
                    ReleaseDate = new DateTime(2018, 05, 17)


                });
        }
    }
}
