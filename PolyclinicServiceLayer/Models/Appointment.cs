using System.ComponentModel.DataAnnotations;

namespace PolyclinicServiceLayer.Models
{
    public class Appointment
    {
        [Required]
        public int AppointmentNo { get; set; }
        [Required]
        public DateTime DateOfAppointment { get; set; }
        [Required]
        public string DoctorId { get; set; }
        [Required]
        public string PatientId { get; set; }
    }
}
