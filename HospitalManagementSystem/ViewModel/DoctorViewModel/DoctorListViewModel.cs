using HospitalManagementSystem.Models;

namespace HospitalManagementSystem.ViewModel.DoctorViewModel
{
    public class DoctorListViewModel
    {
            public IEnumerable<Doctor> Doctors { get; }

            public DoctorListViewModel(IEnumerable<Doctor> Doctor)
            {

                Doctors = Doctor;
            }
        }
  }
