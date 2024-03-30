using System.ComponentModel.DataAnnotations;

namespace E_Learning_Management_System.DTO
{
    public class DurationDTO
    {
     
        public int Id { get; set; }

        public DateOnly DurationDate { get; set; }
        public string Description { get; set; }
        public int DurationType { get; set; }
        public int CourseId { get; set; }
    }
}
