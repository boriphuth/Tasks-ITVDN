using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public interface IPatientDetails
    {
        bool Insert(Patient patient);
        bool Update(Patient patient);
        bool Delete(Patient patient);
        IEnumerable<Patient> GetAllPatients();
        Patient GetPatientById(Guid ID);
    }

    public interface IDoctorDetails
    {
        bool Insert(Doctor doctor);
        bool Update(Doctor doctor);
        bool Delete(Doctor doctor);
        IEnumerable<Doctor> GetAllDoctors();
        Doctor GetDoctorById(Guid ID);
    }

    public interface IRegistrCardDetails
    {
        bool Insert(RegistrCard registrCard);
        bool Update(RegistrCard registrCard);
        bool Delete(RegistrCard registrCard);
        IEnumerable<RegistrCard> GetAllRegistrCards();
        RegistrCard GetRegistrCardById(Guid ID);
    }
}
