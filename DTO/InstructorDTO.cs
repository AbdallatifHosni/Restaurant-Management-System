using E_Learning_Management_System.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace E_Learning_Management_System.DTO
{
    public class InstructorDTO
    {
        public int InstructorID { get; set; }
        public string  Name { get; set; }
        public string Email { get; set; }
        public string AccountId { get; set; }
    }
}
