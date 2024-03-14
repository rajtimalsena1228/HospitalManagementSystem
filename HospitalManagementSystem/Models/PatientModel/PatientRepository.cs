using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using HospitalManagementSystem.Models.PatientModel;



namespace HospitalManagementSystem.Models.PatientModel
{
    public class PatientRepository : IPatientRepository

    {



        private readonly HospitalDbContext _hospitalDbContext;

        public PatientRepository(HospitalDbContext hospitalDbContext)
        {

            _hospitalDbContext = hospitalDbContext;
        }

        public IEnumerable<Patient> AllPatient
        {
            get
            {
                return _hospitalDbContext.Patients;
            }
        }


        public void AddPatient(Patient patient)
        {

            _hospitalDbContext.Patients.Add(patient);
            _hospitalDbContext.SaveChanges();
        }


        public Patient? GetPatientById(int patientId)
        {

            return _hospitalDbContext.Patients.FirstOrDefault(p => p.PatientId == patientId);
        }

        public void UpdatePatient(Patient patient)
        {

            var existingPatient = _hospitalDbContext.Patients.FirstOrDefault(p => p.PatientId == patient.PatientId);
            if (existingPatient == null)
            {
                throw new ArgumentException("Patient not found");
            }


            existingPatient.PatientName = patient.PatientName;
            existingPatient.Number = patient.Number;
            existingPatient.Address = patient.Address;
            existingPatient.Gender= patient.Gender;
            existingPatient.Age = patient.Age;
            existingPatient.Description= patient.Description;

            _hospitalDbContext.Entry(existingPatient).State = EntityState.Modified;
            _hospitalDbContext.SaveChanges();
        }

        public void DeletePatient(int id)
        {

            var patient = _hospitalDbContext.Patients.Find(id);

            if (patient == null)
            {
                throw new ArgumentException("patient not found");
            }


            _hospitalDbContext.Patients.Remove(patient);
            _hospitalDbContext.SaveChanges();

        }
    }
}
