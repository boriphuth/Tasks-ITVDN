using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;

namespace Core
{
    public class NinjaContext : IRepository
    {
        public NinjaContext()
        {
            InitNinjaDoctors();
        }

        void InitNinjaDoctors()
        {
            this.ninjaDoctors = new List<Doctor>();
            ninjaDoctors.Add(new Doctor() { ID = Guid.NewGuid(), Name = "Ninja" });
        }

        public IEnumerable<Doctor> GetAllDoctors()
        {
            return ninjaDoctors;
        }




        public bool Insert(Patient patient)
        {
            throw new NotImplementedException();
        }

        public bool Update(Patient patient)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Patient patient)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Patient> GetAllPatients()
        {
            throw new NotImplementedException();
        }

        public Patient GetPatientById(Guid ID)
        {
            throw new NotImplementedException();
        }

        public bool Insert(Doctor doctor)
        {
            throw new NotImplementedException();
        }

        public bool Update(Doctor doctor)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Doctor doctor)
        {
            throw new NotImplementedException();
        }

       

        public Doctor GetDoctorById(Guid ID)
        {
            throw new NotImplementedException();
        }

        public bool Insert(RegistrCard registrCard)
        {
            throw new NotImplementedException();
        }

        public bool Update(RegistrCard registrCard)
        {
            throw new NotImplementedException();
        }

        public bool Delete(RegistrCard registrCard)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<RegistrCard> GetAllRegistrCards()
        {
            throw new NotImplementedException();
        }

        public RegistrCard GetRegistrCardById(Guid ID)
        {
            throw new NotImplementedException();
        }

        List<Doctor> ninjaDoctors;
       
    }
}
