using Microsoft.EntityFrameworkCore;

namespace HospitalManagementSystem.Models.ServiceModel
{
    public class ServiceRepository : IServiceRepository
    {

        private readonly HospitalDbContext _hospitalDbContext;

        public ServiceRepository(HospitalDbContext hospitalDbContext)
        {

            _hospitalDbContext = hospitalDbContext;
        }

        public IEnumerable<Service> AllService
        {
            get
            {
                return _hospitalDbContext.Services;
            }
        }


        public void AddService(Service service)
        {

            _hospitalDbContext.Services.Add(service);
            _hospitalDbContext.SaveChanges();
        }


        public Service? GetServiceById(int serviceId)
        {

            return _hospitalDbContext.Services.FirstOrDefault(p => p.ServiceId == serviceId);
        }

        public void UpdateService(Service service)
        {

            var existingService = _hospitalDbContext.Services.FirstOrDefault(p => p.ServiceId == service.ServiceId);
            if (existingService == null)
            {
                throw new ArgumentException("Service not found");
            }


            existingService.ServiceName = service.ServiceName;
            existingService.Price = service.Price;
            existingService.Description = service.Description;
            existingService.ImageURL= service.ImageURL;

            _hospitalDbContext.Entry(existingService).State = EntityState.Modified;
            _hospitalDbContext.SaveChanges();
        }

        public void DeleteService(int id)
        {

            var service= _hospitalDbContext.Services.Find(id);

            if (service == null)
            {
                throw new ArgumentException("Service not found");
            }


            _hospitalDbContext.Services.Remove(service);
            _hospitalDbContext.SaveChanges();

        }
    }
}
