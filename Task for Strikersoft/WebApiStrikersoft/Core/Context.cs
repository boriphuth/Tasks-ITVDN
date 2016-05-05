using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;

namespace Core
{
    public class Context : IContext
    {
        public Context(string connectionString)
            :this(new DataBase(connectionString))
        {
            //for initialise database uncoment
            //Initialize();
        }

        public Context(IRepository dataBase)
        {
            db = dataBase;
        }

        IRepository db;

        private void Initialize()
        {
            db.Insert(new Doctor() { ID = Guid.NewGuid(), Name = "Lui" });
            db.Insert(new Doctor() { ID = Guid.NewGuid(), Name = "Luk" });


            db.Insert(new Patient()
            {
                ID = Guid.NewGuid(),
                Age = 21,
                Name = "Rex",
                CurrentDoctorID = db.GetAllDoctors().FirstOrDefault().ID
            });
            db.Insert(new Patient()
            {
                ID = Guid.NewGuid(),
                Age = 27,
                Name = "Nick",
                CurrentDoctorID = db.GetAllDoctors().FirstOrDefault().ID
            });


            db.Insert(new RegistrCard()
            {
                ID = Guid.NewGuid(),
                PatientID = db.GetAllPatients().FirstOrDefault().ID,
                DoctorID = db.GetAllDoctors().FirstOrDefault().ID,
                Diagnosise = "Psyho",
                VisitDate = DateTime.UtcNow

            });
            
        }

        public IEnumerable<Report> GetReport()
        {
            var result = from rc in db.GetAllRegistrCards()
                         join p in db.GetAllPatients() on rc.PatientID equals p.ID
                         join d in db.GetAllDoctors() on rc.DoctorID equals d.ID
                         
                         select new Report
                         {
                             PatientID = p.ID,
                             PatientAge = p.Age,
                             PatientName = p.Name,
                             Diagnosise = rc.Diagnosise,
                             VisitDate = rc.VisitDate,
                             VisitDoctorName = d.Name

                         };
            return result.ToList();
        }


        #region Patient
        public bool AddPatient(Patient patient)
        {
            try
            {
                patient.ID = Guid.NewGuid();
                db.Insert(patient);

            }
            catch (Exception)
            {

                return false;
            }
            return true;
        }
        public bool UpdatePatient(Guid ID, Patient patient)
        {
            try
            {
       
                db.Update(patient);

            }
            catch (Exception)
            {

                return false;
            }
            return true;

        }
        public bool DeletePatient(Guid ID)
        {
            try
            {
                var patient = db.GetPatientById(ID);
                db.Delete(patient);
            }
            catch (Exception)
            {

                return false;
            }
            return true;
        }
        public IEnumerable<Patient> GetAllPatients()
        {
            return db.GetAllPatients().OrderBy(x => x.Name);
        }

        public Patient GetPatientByID(Guid ID)
        {
            return db.GetPatientById(ID);
        }
        #endregion

        #region Doctor
        public bool AddDoctor(Doctor doctor)
        {
            try
            {
                doctor.ID = Guid.NewGuid();
                db.Insert(doctor);

            }
            catch (Exception)
            {

                return false;
            }
            return true;
        }
        public bool UpdateDoctor(Guid ID, Doctor doctor)
        {
            try
            {               
                db.Update(doctor);

            }
            catch (Exception)
            {

                return false;
            }
            return true;

        }
        public bool DeleteDoctor(Guid ID)
        {
            try
            {
                var doctor = db.GetDoctorById(ID);
                db.Delete(doctor);
            }
            catch (Exception)
            {

                return false;
            }
            return true;
        }

        public Doctor GetDoctorByID(Guid ID)
        {
            return db.GetDoctorById(ID);
        }


        public IEnumerable<Doctor> GetAllDoctors()
        {
            return db.GetAllDoctors().OrderBy(x => x.Name);
        }
        #endregion

        #region Record
        public bool AddRecordToCard(RegistrCard regCard)
        {
            try
            {
                regCard.ID = Guid.NewGuid();
                regCard.VisitDate = DateTime.UtcNow;
                db.Insert(regCard);

            }
            catch (Exception)
            {

                return false;
            }
            return true;
        }
        public bool UpdateRecord(Guid id,RegistrCard regCard)
        {
            try
            {
                db.Update(regCard);

            }
            catch (Exception)
            {

                return false;
            }
            return true;

        }
        public bool DeleteRecord(Guid ID)
        {
            try
            {
                var rc = db.GetRegistrCardById(ID);
                db.Delete(rc);
            }
            catch (Exception)
            {

                return false;
            }
            return true;
        }

        public IEnumerable<RegistrCard> GetAllCards()
        {
            return db.GetAllRegistrCards();
        }
        public RegistrCard GetCardByID(Guid ID)
        {
            return db.GetRegistrCardById(ID);
        }
        #endregion

    }

}
