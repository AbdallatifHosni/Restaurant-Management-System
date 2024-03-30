using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Learning_Management_System.Model
{
    public class Learner
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [Required]
        [StringLength(100)]
        public string Address { get; set; }
        [ForeignKey(nameof(account))]
        public string AccountID { get; set; }
        public virtual Account account { get; set; }
        public virtual ICollection<Course> courses { get; set; }


    }
}
