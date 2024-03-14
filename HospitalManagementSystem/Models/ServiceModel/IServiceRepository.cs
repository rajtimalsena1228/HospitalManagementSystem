namespace HospitalManagementSystem.Models.ServiceModel
{
    public interface IServiceRepository
    {
        IEnumerable<Service> AllService { get; }
        void AddService(Service service);
        Service? GetServiceById(int ServiceId);
        void UpdateService(Service service);
        void DeleteService(int service);
    }
}
