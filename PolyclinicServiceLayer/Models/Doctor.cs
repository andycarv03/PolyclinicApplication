using System.ComponentModel.DataAnnotations;

namespace PolyclinicServiceLayer.Models
{
    public class Doctor
    {
        [Required]
        public string DoctorId { get; set; }
        [Required]
        public string DoctorName { get; set; }
        [Required]
        [Range(minimum:100, maximum:int.MaxValue)]
        public decimal Fees { get; set; }
        [Required]
        public string Specialization { get; set; }
    }
}
