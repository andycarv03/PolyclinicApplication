using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PolyclinicDataAccessLayer.Models;

public partial class Patient
{
    public string PatientId { get; set; }

    public string PatientName { get; set; }

    public byte Age { get; set; }

    public string Gender { get; set; }

    public string ContactNumber { get; set; }

    [JsonIgnore]
    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
}
