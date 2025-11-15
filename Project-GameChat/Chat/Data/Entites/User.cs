using System.ComponentModel.DataAnnotations;

namespace Chat.Data.Entites
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        public bool IsDeleted { get; set; } = false;

        [Required]
        [StringLength(30)]
        public string UserName { get; set; }

        [Required]
        [StringLength(100)]
        public string Email { get; set; }

        public ICollection<Post> UserPosts { get; set; } = new List<Post>();
        public ICollection<Comment> UserComments { get; set; } = new List<Comment>();
        public ICollection<Achievement> AchievementsAndRoles { get; set; } = new List<Achievement>();
    }
}