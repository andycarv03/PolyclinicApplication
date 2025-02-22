using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolyclinicDataAccessLayer.Models
{
    public class PolyclinicRepository
    {
        private PolyclinicDbContext context;
        public PolyclinicRepository(PolyclinicDbContext context)
        {
            this.context = context;
        }

        //Fetch the Patient’s details for a given PatientID from the Patients table using LINQ query.
        public Patient GetPatientDetails(string patientId)
        {
            Patient patient;

            patient = context.Patients.Find(patientId);

            return patient;
        }

        //Insert new patient details into the Patients table. 
        public bool AddNewPatientDetails(string patientId, string patientName, byte age, string gender, string contactNumber)
        {
            Patient patient = new Patient();
            patient.PatientId = patientId;
            patient.PatientName = patientName;
            patient.Age = age;
            patient.Gender = gender;
            patient.ContactNumber = contactNumber;

            bool result;
            try
            {
                context.Patients.Add(patient);
                context.SaveChanges();
                result = true;
            }
            catch(Exception ex) 
            {
                result = false;
            }
            return result;
        }

        //Updates the patients age in the Patients table for a given PatientID.
        public bool UpdatePatientAge(string patientId, byte age)
        {
            bool result = false;
            try
            {
                Patient patient = context.Patients.Find(patientId);
                patient.Age = age;
                if (patient != null) 
                {
                    using (var newContext = new PolyclinicDbContext())
                    {
                        newContext.Patients.Update(patient);
                        newContext.SaveChanges();
                        result = true;
                    }
                }
                else
                {
                    result = false;
                }
            }
            catch (Exception ex) 
            {
                result = false;
            }
            return result;
        }

        //Remove the appointment details from the Appointments table for the given AppointmentNo passed as parameter
        public int CancelAppointment(int AppointmentNo)
        {
            int result = 0;
            try
            {
                Appointment app = context.Appointments.Find(AppointmentNo);
                if (app != null) 
                {
                    using(var newContext = new PolyclinicDbContext())
                    {
                        newContext.Appointments.Remove(app);
                        newContext.SaveChanges();
                        result = 1;
                    }
                }
                else
                {
                    result = -1;
                }

            }
            catch( Exception ex ) 
            {
                result=-99;
            }
            return result;
        }

        //Fetch all the appointment details using the table valued function ufn_FetchAllAppointments.
        public List<AllAppointmentDetails> FetchAllAppointments(string doctorId, DateOnly dateOfApp) //string dateOfApp
        {
            List<AllAppointmentDetails> resultList;
            try
            {
                SqlParameter prmDoctorId = new SqlParameter("@DoctorId", doctorId);
                SqlParameter prmDateOfApp = new SqlParameter("@DateofAppointment", dateOfApp);
                //prmDateOfApp.SqlDbType = System.Data.SqlDbType.Date;
                

                //resultList = context.AllAppointmentDetails.FromSqlRaw("SELECT * FROM ufn_FetchAllAppointments(@DoctorId, CAST(@DateofAppointment AS DATE))", prmDoctorId, prmDateOfApp).ToList();

                //resultList = context.AllAppointmentDetails.FromSqlInterpolated($"SELECT * FROM ufn_FetchAllAppointments({doctorId}, CAST({dateOfApp} AS DATE))").ToList();
                resultList = context.AllAppointmentDetails
                    .FromSqlRaw("SELECT * FROM ufn_FetchAllAppointments(@DoctorId, @DateofAppointment)", prmDoctorId, prmDateOfApp).ToList();

            }
            catch (Exception ex)
            {
                resultList = null;
            }

            return resultList;
        }

        public decimal CalculateDoctorFees(string doctorId, DateTime dateOfApp) 
        {
            decimal result;
            result = (from s in context.Appointments
                      select PolyclinicDbContext.ufn_CalculateDoctorFees(doctorId, dateOfApp)).FirstOrDefault();
            //var result = context.Database
            //    .SqlQueryRaw<decimal>("SELECT dbo.ufn_CalculateDoctorFees(@param1, @param2)", new SqlParameter("@param1", doctorId), new SqlParameter("@param2", dateOfApp))
            //    .AsEnumerable().FirstOrDefault();

            return result;
        }

        public int GetDoctorAppointment(string patientId, string doctorId, DateTime dateOfAp, out int App)
        {
            int noOfRowAffected;
            int result = 0 ;
            SqlParameter prmPatientId = new SqlParameter("@PatientId", patientId);
            SqlParameter prmDoctorId = new SqlParameter("@DoctorId", doctorId);
            SqlParameter prmDateOfApp = new SqlParameter("@DateOfAppointment", dateOfAp);
            //prmDateOfApp.SqlDbType = System.Data.SqlDbType.Date;

            SqlParameter resultReturned = new SqlParameter("@Result", System.Data.SqlDbType.Int);
            resultReturned.Direction = System.Data.ParameterDirection.Output;

            SqlParameter prmAppointmentNumber = new SqlParameter("@AppointmentNumber", System.Data.SqlDbType.Int);
            prmAppointmentNumber.Direction = System.Data.ParameterDirection.Output;

            try
            {
                noOfRowAffected = context.Database.ExecuteSqlRaw("EXEC {0} = usp_GetDoctorAppointment {1}, {2}, {3}, {4} OUT", resultReturned, prmPatientId, prmDoctorId, prmDateOfApp, prmAppointmentNumber);
                App = Convert.ToInt32(prmAppointmentNumber.Value);
                result = Convert.ToInt32(resultReturned.Value);
            }
            catch(Exception ex) 
            {
                App = 0;
            }
            return result;
        }
    }
}
