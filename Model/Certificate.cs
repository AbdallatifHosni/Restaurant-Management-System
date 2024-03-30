using System.ComponentModel.DataAnnotations;
using System.Security.Principal;

namespace E_Learning_Management_System.Model
{
    public class Certificate
    {
        [Key]
        public int CertificateId { get; set; }
        [Required]
        public DateTime CertificateDate { get; set; }
    }
}
