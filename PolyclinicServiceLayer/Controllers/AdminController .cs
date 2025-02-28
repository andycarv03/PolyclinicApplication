using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PolyclinicDataAccessLayer.Models;
using PolyclinicDataAccessLayer;

namespace PolyclinicServiceLayer.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AdminController : Controller
    {
        PolyclinicRepository repository;
        public AdminController(PolyclinicRepository repository) 
        {
            this.repository = repository;
        }

        [HttpGet]
        public JsonResult GetAllPatientDetails()
        {
            List<Patient> patients;
            try
            {
                patients = repository.GetAllPatientDetails();
            }
            catch(Exception ex) 
            {
                patients = null;
            }

            return Json(patients);
        }

        [HttpGet]
        public JsonResult GetPatientDetails(string id)
        {
            Patient patient;
            try
            {
                patient = repository.GetPatientDetails(id);
            }
            catch(Exception ex) 
            {
                patient = null;
            }

            return Json(patient);
        }

        //string patientId, string patientName, byte age, string gender, string contactNumber
        [HttpPost]
        public JsonResult AddNewPatientDetails(Models.Patient patient)
        {
            bool result;
            Patient newPatient = new Patient();
            newPatient.PatientId = patient.PatientId;
            newPatient.PatientName = patient.PatientName;
            newPatient.Age = patient.Age;
            newPatient.Gender = patient.Gender;
            newPatient.ContactNumber = patient.ContactNumber;
            try
            {
                result = repository.AddNewPatientDetails(newPatient.PatientId, newPatient.PatientName, newPatient.Age, newPatient.Gender, newPatient.ContactNumber);
            }
            catch (Exception ex) 
            {
                result=false;
            }
            return Json(result);
        }
        [HttpPut]
        public JsonResult UpdatePatientAge(string patientId, byte age)
        {
            bool result;
            try
            {
                result = repository.UpdatePatientAge(patientId, age);
            }
            catch (Exception ex) 
            {
                result = false;
            }
            return Json(result);
        }
        [HttpDelete]
        public JsonResult CancelAppointment(int AppointmentNo)
        {
            int result;
            try
            {
                result = repository.CancelAppointment(AppointmentNo);
            }
            catch (Exception ex) 
            {
                result = 0;
            }
            return Json(result);
        }
    }
}
