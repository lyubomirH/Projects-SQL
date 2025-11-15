using Chat.Data;

namespace Chat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using var context = new GameNetworkDbContext();

            Console.WriteLine($"=== GAMER HUB SOCIAL NETWORK ==={Environment.NewLine}");

            Console.WriteLine("1. Users and their posts:");
            var usersWithPosts = context.Users
                .Where(u => !u.IsDeleted)
                .Select(u => new
                {
                    u.UserName,
                    PostCount = u.UserPosts.Count(p => !p.IsDeleted),
                    Posts = u.UserPosts
                        .Where(p => !p.IsDeleted)
                        .Select(p => p.GameTitle)
                        .ToList()
                })
                .ToList();

            foreach (var user in usersWithPosts)
            {
                Console.WriteLine($"User: {user.UserName} - {user.PostCount} posts");
                foreach (var post in user.Posts)
                {
                    Console.WriteLine($"   Game: {post}");
                }
            }

            Console.WriteLine(Environment.NewLine + new string('=', 50) + Environment.NewLine);

            Console.WriteLine("2. Posts with comments:");
            var postsWithComments = context.Posts
                .Where(p => !p.IsDeleted)
                .GroupJoin(
                    context.Comments.Where(c => !c.IsDeleted),
                    post => post.Id,
                    comment => comment.PostId,
                    (post, comments) => new
                    {
                        Author = post.User.UserName,
                        Game = post.GameTitle,
                        Content = post.Content,
                        Comments = comments.Select(c => new
                        {
                            Commenter = c.User.UserName,
                            c.CommentTitle,
                            c.Content
                        }).ToList()
                    })
                .ToList();

            foreach (var post in postsWithComments)
            {
                Console.WriteLine($"{Environment.NewLine} Author: {post.Author} posted about {post.Game}:");
                Console.WriteLine($"   Content: {post.Content}");
                Console.WriteLine($"   Comments ({post.Comments.Count}):");
                foreach (var comment in post.Comments)
                {
                    Console.WriteLine($"    Comment by {comment.Commenter}: {comment.CommentTitle} - {comment.Content}");
                }
            }

            Console.WriteLine(Environment.NewLine + new string('=', 50) + Environment.NewLine);


            Console.WriteLine("3. Users and their achievements:");
            var usersWithAchievements = context.Users
                .Where(u => !u.IsDeleted)
                .Select(u => new
                {
                    u.UserName,
                    Achievements = u.AchievementsAndRoles
                        .Where(a => !a.IsDeleted)
                        .Select(a => new { a.Title, a.Description })
                        .ToList()
                })
                .Where(u => u.Achievements.Any())
                .ToList();

            foreach (var user in usersWithAchievements)
            {
                Console.WriteLine($"{Environment.NewLine}User: \"{user.UserName}\"'s achievements:");
                foreach (var achievement in user.Achievements)
                {
                    Console.WriteLine($"   Achievement: {achievement.Title}: {achievement.Description}");
                }
            }
        }
    }
}
