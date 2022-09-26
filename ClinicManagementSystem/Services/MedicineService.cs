using ClinicManagementSystem.IRepositories;
using ClinicManagementSystem.IServices;
using ClinicManagementSystem.Model;

namespace ClinicManagementSystem.Services
{
    public class MedicineService : IMedicineService
    {
        private readonly IMedicineRepository _medicineRepository;
        private readonly ILogger<MedicineService> _logger;
        private readonly string _serviceName = "MedicineService";
        public MedicineService(IMedicineRepository medicineRepository, ILogger<MedicineService> logger)
        {
            _medicineRepository = medicineRepository;
            _logger = logger;
        }
        public int Add(Medicine medicine)
        {
            _logger.LogInformation($"{_serviceName} - Add");
            return _medicineRepository.Add(medicine);
        }

        public bool Delete(int Id)
        {
            _logger.LogInformation($"{_serviceName} - Delete");
            return _medicineRepository.Delete(Id);
        }

        public int Edit(Medicine medicine)
        {
            _logger.LogInformation($"{_serviceName} - Edit");
            return _medicineRepository.Edit(medicine);
        }

        public List<Medicine> GetAll()
        {
            _logger.LogInformation($"{_serviceName} - GetAll");
            return _medicineRepository.GetAll();
        }

        public Medicine GetMedicineById(int Id)
        {
            _logger.LogInformation($"{_serviceName} - GetMedicineById");
            return _medicineRepository.GetMedicineById(Id);
        }
    }
}
