using System;
using System.Collections.Generic;
using Data;

namespace Core
{
    public interface IContext
    {
        bool AddDoctor(Doctor doctor);
        bool AddPatient(Patient patient);
        bool AddRecordToCard(RegistrCard regCard);
        bool DeleteDoctor(Guid ID);
        bool DeletePatient(Guid ID);
        bool DeleteRecord(Guid ID);
        IEnumerable<RegistrCard> GetAllCards();
        IEnumerable<Doctor> GetAllDoctors();
        IEnumerable<Patient> GetAllPatients();
        RegistrCard GetCardByID(Guid ID);
        Doctor GetDoctorByID(Guid ID);
        Patient GetPatientByID(Guid ID);
        IEnumerable<Report> GetReport();
        bool UpdateDoctor(Guid ID, Doctor doctor);
        bool UpdatePatient(Guid ID, Patient patient);
        bool UpdateRecord(Guid id, RegistrCard regCard);
    }
}