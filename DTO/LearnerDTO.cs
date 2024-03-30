

namespace E_Learning_Management_System.DTO
{
    public class LearnerDTO
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public List<CourseDTO> courses= new List<CourseDTO>();


    }
}
