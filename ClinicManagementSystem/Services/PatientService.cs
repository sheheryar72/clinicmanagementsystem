using ClinicManagementSystem.IRepositories;
using ClinicManagementSystem.IServices;
using ClinicManagementSystem.Model;

namespace ClinicManagementSystem.Services
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;
        private readonly ILogger<PatientService> _logger;
        private readonly string _serviceName = "PatientService";
        public PatientService(IPatientRepository patientRepository, ILogger<PatientService> logger)
        {
            _patientRepository = patientRepository;
            _logger = logger;
        }

        public int Add(Patient patient)
        {
            _logger.LogInformation($"{_serviceName} - Add");
            return _patientRepository.Add(patient);
        }

        public bool Delete(int Id)
        {
            _logger.LogInformation($"{_serviceName} - Add");
            return _patientRepository.Delete(Id);
        }

        public int Edit(Patient patient)
        {
            _logger.LogInformation($"{_serviceName} - Add");
            return _patientRepository.Edit(patient);
        }

        public List<Patient> GetAll()
        {
            _logger.LogInformation($"{_serviceName} - Add");
            return _patientRepository.GetAll();
        }

        public Patient GetPatientById(int Id)
        {
            _logger.LogInformation($"{_serviceName} - Add");
            return _patientRepository.GetPatientById(Id);
        }
    }
}
