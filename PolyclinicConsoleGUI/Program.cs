using Azure;
using PolyclinicDataAccessLayer;
using PolyclinicDataAccessLayer.Models;
namespace PolyclinicConsoleGUI
{
    internal class Program
    {
        static PolyclinicDbContext context;
        static PolyclinicRepository repository;

        static Program()
        {
            context = new PolyclinicDbContext();
            repository = new PolyclinicRepository(context);
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!\n\n");

            //GetPatientDetails
            //Patient patient = repository.GetPatientDetails("P101");
            //if (patient != null) 
            //{
            //    Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}", patient.PatientId, patient.PatientName, patient.Gender, patient.Age, patient.ContactNumber);
            //}
            //else
            //{
            //    Console.WriteLine("No patient record found! Kindly enter correct Patient Id");
            //}

            //AddNewPatientDetails
            //bool result = repository.AddNewPatientDetails("P111", "Alison Ferns", 54, "F", "9876543210");
            //if (result)
            //{
            //    Console.WriteLine("Patient record added!");
            //}
            //else
            //{
            //    Console.WriteLine("Something went wrong. kindly check with admin");
            //}

            //UpdatePatientAge
            //bool result = repository.UpdatePatientAge("P102", 63);
            //if (result)
            //{
            //    Console.WriteLine("Patient record updated!");
            //}
            //else
            //{
            //    Console.WriteLine("Something went wrong. kindly check with admin");
            //}

            //CancelAppointment
            //int r = repository.CancelAppointment(18);
            //if (r > 0)
            //{
            //    Console.WriteLine("Appointment deleted from records!");
            //}
            //else if (r == -1) 
            //{
            //    Console.WriteLine("No patient with appoitment number found!");
            //}
            //else
            //{
            //    Console.WriteLine("Something went wrong. kindly check with admin");
            //}

            //FetchAllAppointments
            //var apps = repository.FetchAllAppointments("D4", "2025-02-27");
            //var apps = repository.FetchAllAppointments("D4", new DateOnly(2025, 2, 27));  //use DateTime/DateOnly
            //if (apps != null)
            //{
            //    Console.WriteLine("Appointments scehduled --");
            //    foreach (var appointment in apps)
            //    {
            //        Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}", appointment.DoctorName, appointment.Specialization, appointment.PatientId, appointment.PatientName, appointment.AppointmentNo);
            //    }
            //}
            //else
            //{
            //    Console.WriteLine("No appointments scheduled for the given doctor id ");
            //}

            //CalculateDoctorFees
            //var fees = repository.CalculateDoctorFees("D4", new DateTime(2025, 2, 27)); //new DateOnly(2025, 2, 27)
            //if (fees != 0)
            //{
            //    Console.WriteLine("Fees for Doctor - {0}", fees);
            //}
            //else
            //{
            //    Console.WriteLine("No appointments scheduled for the given doctor id");
            //}

            //GetDoctorAppointment
            //int appointment;
            //int result = repository.GetDoctorAppointment("P101", "D1", new DateTime(2025, 3, 27), out appointment);
            //if (result > 0)
            //{
            //    Console.WriteLine("New appointment generated " + appointment);
            //}
            //else
            //{
            //    Console.WriteLine("Something went wrong!");
            //}
        }
    }
}
