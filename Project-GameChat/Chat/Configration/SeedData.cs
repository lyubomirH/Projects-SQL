using Chat.Data.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Chat.Configration
{
    public static class SeedData
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            var users = new List<User>
            {
                new User { Id = 1, UserName = "ProGamer2000", Email = "pro@abv.bg", IsDeleted = false },
                new User { Id = 2, UserName = "CyberWarrior", Email = "cyber@abv.bg", IsDeleted = false },
                new User { Id = 3, UserName = "StrategyQueen", Email = "strategy@abv.bg", IsDeleted = false },
                new User { Id = 4, UserName = "LetsGameItOut", Email = "LetsGameItOut@gmail.com", IsDeleted = false }, // Fixed: removed apostrophe
                new User { Id = 5, UserName = "MaxLevelIdot", Email = "MaxLevelIdot@gmail.com", IsDeleted = false }
            };

            var posts = new List<Post>
            {
                new Post { Id = 1, GameTitle = "The Witcher 3", Content = "Just finished The Witcher 3! Amazing storyline!",
                    UserId = 1, IsDeleted = false },
                new Post { Id = 2, GameTitle = "Cyberpunk 2077", Content = "played the new Cyberpunk 2077 and the storyline and the game play is amazing!",
                    UserId = 2, IsDeleted = false },
                new Post { Id = 3, GameTitle = "Civilization VI", Content = "Civilization VI is consuming my life. One more turn!",
                    UserId = 3, IsDeleted = false },
                new Post { Id = 4, GameTitle = "Satisfactory", Content = "Huge congrats to Satisfactory for finally going global! I cannot wait to sink an irresponsible amount of time into this game and absolutely ruin my sleep schedule all over again. Here's to building factories so needlessly complicated that even future me will question my life choices. Let the chaos begin!",
                    UserId = 4, IsDeleted = false },
                new Post { Id = 5, GameTitle = "Call of Duty", Content = "New COD game is bad compared to what they did with Battlefield 6!",
                    UserId = 1, IsDeleted = false },
                new Post { Id = 6, GameTitle = "Bloons TD 6", Content = "Bro, let's be real — the best hero in Bloons TD 6 is whoever lets me AFK the longest without the whole map exploding. Absolutely best strategy.",
                    UserId = 5, IsDeleted = false }
            };

            var comments = new List<Comment>
            {
                new Comment { Id = 1, CommentTitle = "Congrats!", Content = "Congrats on finishing The Witcher! That ending hits hard!",
                    UserId = 2, PostId = 1, IsDeleted = false },
                new Comment { Id = 2, CommentTitle = "Welcome!", Content = "Welcome to the Cyberpunk fandom! The updates made the game so much better.",
                    UserId = 1, PostId = 2, IsDeleted = false },
                new Comment { Id = 3, CommentTitle = "I know!", Content = "Civ VI is dangerously addictive. One more turn? More like 200.",
                    UserId = 4, PostId = 3, IsDeleted = false },
                new Comment { Id = 4, CommentTitle = "Factory black hole", Content = "Satisfactory is basically a productivity black hole, but in a good way.",
                    UserId = 3, PostId = 4, IsDeleted = false },
                new Comment { Id = 5, CommentTitle = "Multiplayer", Content = "COD multiplayer still slaps, even if the campaign is questionable.",
                    UserId = 2, PostId = 5, IsDeleted = false },
                new Comment { Id = 6, CommentTitle = "AFK Gang", Content = "AFK meta in Bloons? Best gameplay.",
                    UserId = 2, PostId = 6, IsDeleted = false }
            };

            var achievements = new List<Achievement>
            {
                new Achievement { Id = 1, Title = "First Post",
                    Description = "Published your first game review",
                    UserId = 1, EarnedOnDate = new DateTime(2024, 1, 15), IsDeleted = false },

                new Achievement { Id = 2, Title = "Comment Master",
                    Description = "Left 5+ comments",
                    UserId = 2, EarnedOnDate = new DateTime(2024, 1, 10), IsDeleted = false },

                new Achievement { Id = 3, Title = "Strategy Expert",
                    Description = "Specialized in Strategy games",
                    UserId = 3, EarnedOnDate = new DateTime(2024, 1, 5), IsDeleted = false },

                new Achievement { Id = 4, Title = "Indie Explorer",
                    Description = "Reviewed 3+ indie games",
                    UserId = 4, EarnedOnDate = new DateTime(2024, 1, 20), IsDeleted = false },

                new Achievement { Id = 5, Title = "Factory Overlord",
                    Description = "Created a post about automation or factory-building games",
                    UserId = 4, EarnedOnDate = new DateTime(2024, 1, 25), IsDeleted = false },

                new Achievement { Id = 6, Title = "FPS Veteran",
                    Description = "Posted multiple FPS-related reviews",
                    UserId = 1, EarnedOnDate = new DateTime(2024, 1, 8), IsDeleted = false },

                new Achievement { Id = 7, Title = "Tower Defense Guru",
                    Description = "Shared expert tips about tower defense games",
                    UserId = 5, EarnedOnDate = new DateTime(2024, 1, 30), IsDeleted = false },

                new Achievement { Id = 8, Title = "Community Helper",
                    Description = "Left helpful comments on 5 different posts",
                    UserId = 2, EarnedOnDate = new DateTime(2024, 2, 1), IsDeleted = false }
            };

            modelBuilder.Entity<User>().HasData(users);
            modelBuilder.Entity<Post>().HasData(posts);
            modelBuilder.Entity<Comment>().HasData(comments);
            modelBuilder.Entity<Achievement>().HasData(achievements);
        }
    }
}