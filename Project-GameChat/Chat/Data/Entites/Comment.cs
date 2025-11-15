using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Chat.Data.Entites
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        public string CommentTitle { get; set; }

        [Required]
        [StringLength(300)]
        public string Content { get; set; }

        public bool IsDeleted { get; set; }

        [Required]
        public int PostId { get; set; }

        [Required]
        public int UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public User User { get; set; }

        [ForeignKey(nameof(PostId))]
        public Post Post { get; set; }
    }
}