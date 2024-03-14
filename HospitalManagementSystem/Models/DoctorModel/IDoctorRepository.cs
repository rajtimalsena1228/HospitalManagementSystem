namespace HospitalManagementSystem.Models.DoctorModel
{
    public interface IDoctorRepository
    {
        IEnumerable<Doctor> AllDoctor { get; }
        void AddDoctor(Doctor doctor);
        Doctor? GetDoctorById(int doctorId);
        void UpdateDoctor(Doctor doctor);
        void DeleteDoctor(int doctor);
    }
}
