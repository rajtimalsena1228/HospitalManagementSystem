namespace HospitalManagementSystem.Models.PatientModel
{
    public interface IPatientRepository
    {
        IEnumerable<Patient> AllPatient { get; }
        void AddPatient(Patient patient);
        Patient? GetPatientById(int patientId);
        void UpdatePatient(Patient patient);
        void DeletePatient(int patient);


    }

}
