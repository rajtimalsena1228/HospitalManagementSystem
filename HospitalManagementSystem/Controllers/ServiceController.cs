
using HospitalManagementSystem.Models;
using HospitalManagementSystem.ViewModel.ServiceViewModel;
using Microsoft.AspNetCore.Mvc;
using HospitalManagementSystem.Models.ServiceModel;

namespace HospitalManagementSystem.Controllers
{
    public class ServiceController : Controller
    {

        private readonly IServiceRepository _serviceRepository;




        public ServiceController(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;

        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult serviceList()
        {

            ServiceListViewModel serviceListViewModel = new ServiceListViewModel(_serviceRepository.AllService);
            return View(serviceListViewModel);
        }

        public ActionResult AddService()
        {
            var viewModel = new AddServiceViewModel();
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddService(AddServiceViewModel viewModel)
        {
            if (ModelState.IsValid)
            {

                Service newService = new Service
                {
                    ServiceId = viewModel.ServiceId,
                    ServiceName = viewModel.ServiceName,
                    Description = viewModel.Description,
                    ImageURL = viewModel.ImageURL,
                    Price   = viewModel.Price,
                };
                _serviceRepository.AddService(newService);
            }
            return RedirectToAction("ServiceList");
        }
        [HttpGet]
        public ActionResult Service(int id)
        {
            var service = _serviceRepository.GetServiceById(id);

            var editServiceViewModel = new UpdateServiceViewModel
            {
                ServiceId = service.ServiceId,
                ServiceName = service.ServiceName,
                Description = service.Description,
                ImageURL = service.ImageURL,
                Price = service.Price,

            };


            return View(editServiceViewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateService(UpdateServiceViewModel model)
        {
            var service = _serviceRepository.GetServiceById(model.ServiceId);

            service.ServiceName = model.ServiceName;
            service.Description = model.Description; 
            service.ImageURL = model.ImageURL;
            service.Price   = model.Price;

            _serviceRepository.UpdateService(service);
            return RedirectToAction("ServiceList");
        }
        [HttpGet]
        public ActionResult UpdateService(int id)
        {
            var service = _serviceRepository.GetServiceById(id);

            var editServiceViewModel = new UpdateServiceViewModel
            {
                ServiceId = service.ServiceId,
                ServiceName = service.ServiceName,
                Price = service.Price,               
                Description = service.Description,                
                ImageURL = service.ImageURL,
            };


            return View(editServiceViewModel);
        }

        public IActionResult DeleteService(int id)
        {

            _serviceRepository.DeleteService(id);

            return RedirectToAction("ServiceList");


        }


    }
}
