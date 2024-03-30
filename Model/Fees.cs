using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Principal;

namespace E_Learning_Management_System.Model
{
    public class Fees
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Amount { get; set; }
        [Required]
        
        public decimal Total { get; set; }
        [Required]
        public string Payment { get; set; }
        [Required]
        [StringLength(100)]
        public string  Description { get; set; }


    }
}
