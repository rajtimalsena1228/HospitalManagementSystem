using HospitalManagementSystem.Models;

namespace HospitalManagementSystem.ViewModel.PatientViewModel
{
    public class PatientListViewModel
    {
        public IEnumerable<Patient> Patients { get; }

        public PatientListViewModel(IEnumerable<Patient> Patient)
        {

            Patients = Patient;
        }
    }
}
