using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlantsForum.Models
{
    public class Discussion
    {
        // primary key
        public int DiscussionId { get; set; }

        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;

        public string ImageFileName { get; set; } = string.Empty;

        // Property for file upload, not mapped in EF
        [NotMapped]
        [Display(Name = "Photograph")]
        public IFormFile? ImageFile { get; set; } // nullable! 


        [Display(Name = "Date Created")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // Navigation property
        public List<Comment>? Comment { get; set; }

    }
}
