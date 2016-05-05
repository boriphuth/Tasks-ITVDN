using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Data
{
    public class DataBase : IRepository
    {
        public DataBase(string connectionString)
        {
            this.connectionString = connectionString;
        }

        string connectionString;

        #region CRUD Patients

     

        public bool Insert(Patient patient)
        {
            string sqlQuery = "INSERT INTO [dbo].[patients]([id],[name],[age],[currentdoctorid]) VALUES (@ID, @Name, @Age, @CurrentDoctorID)";
            var result = false;
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();

                conn.Execute(sqlQuery,
                new
                {
                    patient.ID,
                    patient.Name,
                    patient.Age,
                    patient.CurrentDoctorID
                });
                result = true;
            }
            return result;
        }

        public bool Update(Patient patient)
        {
            string sqlQuery = "Update [dbo].[patients] set [name] = @Name,[age] = @Age,[currentdoctorid] = @CurrentDoctorID where [id] = @ID";
            var result = false;
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();

                conn.Execute(sqlQuery,
                new
                {
                    patient.ID,
                    patient.Name,
                    patient.Age,
                    patient.CurrentDoctorID
                });
                result = true;
            }
            return result;
        }

        public bool Delete(Patient patient)
        {
            string sqlQuery = "Delete from [dbo].[patients] where [id] = @ID";
            var result = false;
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();

                conn.Execute(sqlQuery,
                new
                {
                    patient.ID,

                });
                result = true;
            }
            return result;
        }

        public IEnumerable<Patient> GetAllPatients()
        {
            string sqlQuery = "select * from patients";
            IEnumerable<Patient> patients;
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();

                patients = conn.Query<Patient>(sqlQuery);
            }

            return patients;
        }

        public Patient GetPatientById(Guid ID)
        {
            Patient patient;
            patient = GetAllPatients().FirstOrDefault(x => x.ID == ID);

            return patient;
        }

        #endregion

        #region CRUD Doctors

    
        public bool Insert(Doctor doctor)
        {
            string sqlQuery = "INSERT INTO [dbo].[doctors]([id],[name]) VALUES (@ID,@Name)";
            var result = false;
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();

                conn.Execute(sqlQuery,
                new
                {
                    doctor.ID,
                    doctor.Name
                });
                result = true;
            }
            return result;
        }

        public bool Update(Doctor doctor)
        {
            string sqlQuery = "Update [dbo].[doctors] set [name] = @Name where [id] = @ID";
            var result = false;
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();

                conn.Execute(sqlQuery,
                new
                {
                    doctor.ID,
                    doctor.Name
                });
                result = true;
            }
            return result;
        }

        public bool Delete(Doctor doctor)
        {
            string sqlQuery = "Delete from [dbo].[doctors] where [id] = @ID";
            var result = false;
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();

                conn.Execute(sqlQuery,
                new
                {
                    doctor.ID,

                });
                result = true;
            }
            return result;
        }

        public Doctor GetDoctorById(Guid ID)
        {
            Doctor doctor;
            doctor = GetAllDoctors().FirstOrDefault(x => x.ID == ID);

            return doctor;
        }
        public IEnumerable<Doctor> GetAllDoctors()
        {
            string sqlQuery = "select * from doctors";
            IEnumerable<Doctor> doctors;
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();

                doctors = conn.Query<Doctor>(sqlQuery);
            }

            return doctors;
        }

        #endregion

        #region CRUD RegistrCards

    
        public bool Insert(RegistrCard registrCard)
        {
            string sqlQuery = "INSERT INTO [dbo].[registrcards]([id],[patientid],[doctorid],[diagnosise],[visitdate]) VALUES (@ID,@PatientID,@DoctorID, @Diagnosise,@VisitDate)";
            var result = false;
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();

                conn.Execute(sqlQuery,
                new
                {
                    registrCard.ID,
                    registrCard.PatientID,
                    registrCard.DoctorID,
                    registrCard.Diagnosise,
                    registrCard.VisitDate
                });
                result = true;
            }
            return result;
        }

        public bool Update(RegistrCard registrCard)
        {
            string sqlQuery = "Update [dbo].[registrcards] set [patientid] = @PatientID,[doctorid] = @DoctorID,[diagnosise] = @Diagnosise, [visitdate] = @VisitDate  where [id] = @ID";
            var result = false;
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();

                conn.Execute(sqlQuery,
                new
                {
                    registrCard.ID,
                    registrCard.PatientID,
                    registrCard.DoctorID,
                    registrCard.Diagnosise,
                    registrCard.VisitDate
                });
                result = true;
            }
            return result;
        }

        public bool Delete(RegistrCard registrCard)
        {
            string sqlQuery = "Delete from [dbo].[registrcards] where [id] = @ID";
            var result = false;
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();

                conn.Execute(sqlQuery,
                new
                {
                    registrCard.ID,

                });
                result = true;
            }
            return result;
        }

        public IEnumerable<RegistrCard> GetAllRegistrCards()
        {
            string sqlQuery = "select * from registrcards";
            IEnumerable<RegistrCard> registrCards;
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();

                registrCards = conn.Query<RegistrCard>(sqlQuery);
            }

            return registrCards;
        }

        public RegistrCard GetRegistrCardById(Guid ID)
        {
            RegistrCard registrCard;
            registrCard = GetAllRegistrCards().FirstOrDefault(x => x.ID == ID);

            return registrCard;
        }
        #endregion

    }
}
