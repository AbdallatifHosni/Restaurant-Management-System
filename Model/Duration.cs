using System.ComponentModel.DataAnnotations;

namespace E_Learning_Management_System.Model
{
    public class Duration
    {
        [Key]
        public int Id { get; set; }

        public DateOnly DurationDate { get; set; }
        public string Description { get; set; }
        public int DurationType { get; set; }
        public int CourseId { get; set; }
    }
}
