using E_Learning_Management_System.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Learning_Management_System.DTO
{
    public class CourseDTO
    {

        public int CourseId { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        public   List<Learner> learners =new List<Learner>();

        public List<Instructor> Instructors = new List<Instructor>();

    }
}
