using ClinicManagementSystem.IRepositories;
using ClinicManagementSystem.IServices;
using ClinicManagementSystem.Model;

namespace ClinicManagementSystem.Services
{
    public class PatientDiagnoseService : IPatientDiagnoseService
    {
        private readonly IPatientDiagnoseRepository _patientDiagnoseRepository;
        private readonly ILogger<PatientDiagnoseService> _logger;
        private readonly string _serviceName = "PatientDiagnoseRepository";
        public PatientDiagnoseService(IPatientDiagnoseRepository patientDiagnoseRepository, ILogger<PatientDiagnoseService> logger)
        {
            _patientDiagnoseRepository = patientDiagnoseRepository;
            _logger = logger;
        }

        public int Add(PatientDiagnose patientDiagnose)
        {
            _logger.LogInformation($"{_serviceName} - Add");
            return _patientDiagnoseRepository.Add(patientDiagnose);
        }

        public bool Delete(int Id)
        {
            _logger.LogInformation($"{_serviceName} - Delete");
            return _patientDiagnoseRepository.Delete(Id);
        }

        public int Edit(PatientDiagnose patientDiagnose)
        {
            _logger.LogInformation($"{_serviceName} - Edit");
            return _patientDiagnoseRepository.Edit(patientDiagnose);
        }

        public List<PatientDiagnose> GetAll()
        {
            _logger.LogInformation($"{_serviceName} - GetAll");
            return _patientDiagnoseRepository.GetAll();
        }

        public PatientDiagnose GetPatientDiagnoseById(int Id)
        {
            _logger.LogInformation($"{_serviceName} - GetMedicineById");
            return _patientDiagnoseRepository.GetMedicineById(Id);
        }
    }
}
