using HospitalManagementSystem.Models;

namespace HospitalManagementSystem.ViewModel.ServiceViewModel
{
    public class ServiceListViewModel
    {
        public IEnumerable<Service> Services { get; }

        public ServiceListViewModel(IEnumerable<Service> Service)
        {

            Services = Service;
        }
    }
}
