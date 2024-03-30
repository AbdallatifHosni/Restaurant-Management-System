using System.ComponentModel.DataAnnotations;

namespace E_Learning_Management_System.Model
{
    public class Feedback
    {
        [Key]
        public int FeedbackId { get; set; }
        [Required]
        public int QuizID { get; set; }

    }
}
