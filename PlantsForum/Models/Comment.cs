using System.ComponentModel.DataAnnotations;


namespace PlantsForum.Models
{
    public class Comment
    {
        public int CommentId { get; set; }

        public string Content { get; set; } = string.Empty;

        public int DiscussionId { get; set; }

        [Display(Name = "Date Created")]
        public DateTime CreateDate { get; set; } = DateTime.Now;



        // Navigation property
        public Discussion? Discussion { get; set; }
    }
}
