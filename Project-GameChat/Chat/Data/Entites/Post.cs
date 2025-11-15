using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Chat.Data.Entites
{
    public class Post
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        public string GameTitle { get; set; }

        [Required]
        [StringLength(500)]
        public string Content { get; set; }

        public bool IsDeleted { get; set; }

        public int UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public User User { get; set; }

        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
    }
}