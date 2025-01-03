using System.ComponentModel.DataAnnotations;

namespace demoIVS.Models
{
    public class RedmineNews
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        [Display(Name = "Subject")]
        [DataType(DataType.Text)]
        public string Subject { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Title")]
        [DataType(DataType.Text)]
        public string Title { get; set; }

        [Required]
        [MaxLength(200)]
        [Display(Name = "Summary")]
        [DataType(DataType.Text)]
        public string Summary { get; set; }

        [Required]
        [Display(Name = "Description")]
        [DataType(DataType.Text)]
        public string Description { get; set; }

    }
}
