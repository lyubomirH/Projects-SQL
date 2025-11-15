using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Chat.Data.Entites
{
    public class Achievement
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        [StringLength(300)]
        public string Description { get; set; }

        public DateTime EarnedOnDate { get; set; } = new DateTime(2024, 1, 1);

        public bool IsDeleted { get; set; } = false;

        [Required]
        public int UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public User User { get; set; }
    }
}