
using Microsoft.EntityFrameworkCore;
using HospitalManagementSystem.Models.DoctorModel;


namespace HospitalManagementSystem.Models.DoctorModel
{
    public class DoctorRepository : IDoctorRepository

    {


        private readonly HospitalDbContext _hospitalDbContext;

        public DoctorRepository(HospitalDbContext hospitalDbContext)
        {

            _hospitalDbContext = hospitalDbContext;
        }

        public IEnumerable<Doctor> AllDoctor
        {
            get
            {
                return _hospitalDbContext.Doctors;
            }
        }


        public void AddDoctor(Doctor doctor)
        {

            _hospitalDbContext.Doctors.Add(doctor);
            _hospitalDbContext.SaveChanges();
        }


        public Doctor? GetDoctorById(int doctorId)
        {

            return _hospitalDbContext.Doctors.FirstOrDefault(p => p.DoctorId == doctorId);
        }

        public void UpdateDoctor(Doctor doctor)
        {

            var existingDoctor = _hospitalDbContext.Doctors.FirstOrDefault(p => p.DoctorId == doctor.DoctorId);
            if (existingDoctor == null)
            {
                throw new ArgumentException("Doctor not found");
            }


            existingDoctor.DoctorName = doctor.DoctorName;
            existingDoctor.Number = doctor.Number;
            existingDoctor.Address = doctor.Address;
            existingDoctor.Gender = doctor.Gender;
            existingDoctor.Description = doctor.Description;
            existingDoctor.Faculty= doctor.Faculty;

            _hospitalDbContext.Entry(existingDoctor).State = EntityState.Modified;
            _hospitalDbContext.SaveChanges();
        }

        public void DeleteDoctor(int id)
        {

            var docter = _hospitalDbContext.Doctors.Find(id);

            if (docter == null)
            {
                throw new ArgumentException("Docter not found");
            }


            _hospitalDbContext.Doctors.Remove(docter);
            _hospitalDbContext.SaveChanges();

        }
    }

}
        