using System.ComponentModel.DataAnnotations;

namespace E_Learning_Management_System.Model
{
    public class Content
    {
        [Key]
        public int ContentId { get; set; }
        [Required]
        public string Contenttype { get; set; }

    }
}
