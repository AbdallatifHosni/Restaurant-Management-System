using System.ComponentModel.DataAnnotations;

namespace E_Learning_Management_System.Model
{
    public class Quiz
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public double Mark { get; set; }
    }
}
