using HospitalManagementSystem.ViewModel.DoctorViewModel;
using HospitalManagementSystem.Models;
using HospitalManagementSystem.Models.DoctorModel;
using HospitalManagementSystem.ViewModel.PatientViewModel;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementSystem.Controllers

{
    public class DoctorController : Controller
    {

        private readonly IDoctorRepository _doctorRepository;




        public DoctorController(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;

        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult doctorList()
        {

            DoctorListViewModel doctorListViewModel = new DoctorListViewModel(_doctorRepository.AllDoctor);
            return View(doctorListViewModel);
        }

        public ActionResult AddDoctor()
        {
            var viewModel = new AddDoctorViewModel();
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddDoctor(AddDoctorViewModel viewModel)
        {
            if (ModelState.IsValid)
            {

                Doctor newDoctor = new Doctor
                {
                    DoctorId = viewModel.DoctorId,
                    DoctorName = viewModel.DoctorName,
                    Number = viewModel.Number,
                    Address = viewModel.Address,
                    Gender = viewModel.Gender,
                    Description = viewModel.Description,
                    ImageURL = viewModel.ImageURL,
                    Faculty = viewModel.Faculty,

                };
                _doctorRepository.AddDoctor(newDoctor);
            }
            return RedirectToAction("DoctorList");
        }
        [HttpGet] 
        public ActionResult Doctor(int id)
        {
            var doctor = _doctorRepository.GetDoctorById(id);

            var editDoctorViewModel = new UpdateDoctorViewModel
            {
                DoctorId = doctor.DoctorId,
                DoctorName = doctor.DoctorName,
                Number = doctor.Number,
                Address = doctor.Address,
                Description = doctor.Description,
                Gender = doctor.Gender,
                ImageURL = doctor.ImageURL,
                Faculty= doctor.Faculty,

            };


            return View(editDoctorViewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateDoctor(UpdateDoctorViewModel model)
        {
            var doctor = _doctorRepository.GetDoctorById(model.DoctorId);

            doctor.DoctorName = model.DoctorName;
            doctor.Number = model.Number;
            doctor.Address = model.Address;
            doctor.Gender = model.Gender;
            doctor.Description = model.Description;
            doctor.Faculty  = model.Faculty;
            doctor.ImageURL = model.ImageURL;

            _doctorRepository.UpdateDoctor(doctor);
            return RedirectToAction("DoctorList");
        }
        [HttpGet]
        public ActionResult UpdateDoctor(int id)
        {
            var doctor = _doctorRepository.GetDoctorById(id);

            var editDoctorViewModel = new UpdateDoctorViewModel
            {
                DoctorId = doctor.DoctorId,
                DoctorName = doctor.DoctorName,
                Number = doctor.Number,
                Address = doctor.Address,
                Description = doctor.Description,
                Gender = doctor.Gender,
                ImageURL = doctor.ImageURL,
                Faculty = doctor.Faculty,

            };


            return View(editDoctorViewModel);
        }

        public IActionResult DeleteDoctor(int id)
        {

            _doctorRepository.DeleteDoctor(id);

            return RedirectToAction("DoctorList");


        }


    }
}