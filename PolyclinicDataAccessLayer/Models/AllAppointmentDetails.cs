using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolyclinicDataAccessLayer.Models
{
    public class AllAppointmentDetails
    {
        public string DoctorName { get; set; }
        public string Specialization { get; set; }
        public string PatientId { get; set; }
        public string PatientName { get; set;}
        
        [Key]
        public int AppointmentNo { get; set;}
    }
}
