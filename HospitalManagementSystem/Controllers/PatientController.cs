
using HospitalManagementSystem.Models;
using HospitalManagementSystem.Models.PatientModel;
using HospitalManagementSystem.ViewModel.DoctorViewModel;
using HospitalManagementSystem.ViewModel.PatientViewModel;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementSystem.Controllers

{
    public class PatientController : Controller
    {

        private readonly IPatientRepository _patientRepository;




        public PatientController(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;

        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult PatientList()
        {

            PatientListViewModel patientListViewModel = new PatientListViewModel(_patientRepository.AllPatient);
            return View(patientListViewModel);
        }

        public ActionResult AddPatient()
        {
            var viewModel = new AddPatientViewModel();
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddPatient(AddPatientViewModel viewModel)
        {
            if (ModelState.IsValid)
            {

                Patient newPatient = new Patient
                {
                    PatientId= viewModel.PatientId,
                    PatientName = viewModel.PatientName,
                    Number = viewModel.Number,
                    Address = viewModel.Address,
                    Gender  = viewModel.Gender,
                    Description =  viewModel.Description,
                    Age =   viewModel.Age,
                    
                };
                _patientRepository.AddPatient(newPatient);
            }
            return RedirectToAction("PatientList");
        }
        [HttpGet]
        public ActionResult Patient(int id)
        {
            var patient = _patientRepository.GetPatientById(id);

            var editPatientViewModel = new UpdatePatientViewModel
            {
                PatientId = patient.PatientId,
                PatientName = patient.PatientName,
                Number = patient.Number,
                Address = patient.Address,
                Description =  patient.Description,
                Gender = patient.Gender, 
                Age = patient.Age
       
            };


            return View(editPatientViewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdatePatient(UpdatePatientViewModel model)
        {
            var patient = _patientRepository.GetPatientById(model.PatientId);
            patient.PatientName = model.PatientName;
            patient.Number = model.Number;
            patient.Address = model.Address;
            patient.Gender =   model.Gender;
            patient.Description = model.Description;
            patient.Age = model.Age;
        
            _patientRepository.UpdatePatient(patient);
            return RedirectToAction("PatientList");
        }
        [HttpGet]
        public ActionResult UpdatePatient(int id)
        {
            var patient = _patientRepository.GetPatientById(id);

            var editPatientViewModel = new UpdatePatientViewModel
            {
                PatientId = patient.PatientId,
                PatientName = patient.PatientName,
                Number = patient.Number,
                Address = patient.Address,
                Description = patient.Description,
                Gender = patient.Gender,
                Age = patient.Age,

            };


            return View(editPatientViewModel);
        }



        public IActionResult DeletePatient(int id)
        {

            _patientRepository.DeletePatient(id);

            return RedirectToAction("PatientList");


        }


    }
}