using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace E_Learning_Management_System.Model
{
    public class Instructor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int InstructorID { get; set; }
        [Required]
        public string  Name { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [StringLength(80)]
        public string Email { get; set; }

        public virtual Account? Account { get; set; }

        public virtual ICollection<Course> Courses { get; set; }=new HashSet<Course>();
    }
}
