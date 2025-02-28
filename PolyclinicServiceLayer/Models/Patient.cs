using System.ComponentModel.DataAnnotations;

namespace PolyclinicServiceLayer.Models
{
    public class Patient
    {
        [Required]
        public string PatientId { get; set; }
        [Required]
        public string PatientName { get; set; }
        [Required]
        public byte Age { get; set;}
        [Required]
        public string Gender { get; set; }
        [Required]
        [StringLength(10, MinimumLength=10)]
        public string ContactNumber { get; set; }
    }
}
