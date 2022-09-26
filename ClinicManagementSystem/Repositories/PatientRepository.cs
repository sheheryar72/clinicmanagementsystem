using ClinicManagementSystem.HelperLibraries.Database;
using ClinicManagementSystem.IRepositories;
using ClinicManagementSystem.Model;
using Dapper;
using System.Data;

namespace ClinicManagementSystem.Repositories
{
    public class PatientRepository : IPatientRepository
    { 
        private readonly IDbDapper _helper;
        private readonly ILogger<PatientRepository> _logger;
        private readonly string _repositoryName = "PatientRepository";
        public PatientRepository(IDbDapper dbDapper, ILogger<PatientRepository> logger)
        {
            _helper = dbDapper;
            _logger = logger;
        }
        public int Add(Patient patient)
        {
            _logger.LogInformation($"{_repositoryName} - Add");
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Name", patient.Name, DbType.String, ParameterDirection.Input);
            parameters.Add("@Address", patient.Address, DbType.String, ParameterDirection.Input);
            parameters.Add("@CNIC", patient.CNIC, DbType.Int64, ParameterDirection.Input);
            parameters.Add("@DOB", patient.DOB, DbType.Date, ParameterDirection.Input);
            parameters.Add("@Contact", patient.Contact, DbType.Int64, ParameterDirection.Input);
            parameters.Add("@Gender", patient.Gender, DbType.String, ParameterDirection.Input);
            parameters.Add("@UserId", patient.UserId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Active", patient.Active, DbType.Boolean, ParameterDirection.Input);
            parameters.Add("@CreatedAt", patient.CreatedAt, DbType.DateTime, ParameterDirection.Input);
            parameters.Add("@CreatedBy", patient.CreatedBy, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@ModifiedAt", patient.ModifiedAt, DbType.DateTime, ParameterDirection.Input);
            parameters.Add("@ModifiedBy", patient.ModifiedBy, DbType.Int32, ParameterDirection.Input);
            return _helper.ExecuteSP<int>("[InsertPatient]", parameters).FirstOrDefault();
        }

        public bool Delete(int Id)
        {
            _logger.LogInformation($"{_repositoryName} - Delete");
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Id", Id, DbType.Int32, ParameterDirection.Input);
            return _helper.ExecuteSP<int>("[DeletePatient]", parameters).FirstOrDefault() > 0;
        }

        public int Edit(Patient patient)
        {
            _logger.LogInformation($"{_repositoryName} - Edit");
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Id", patient.Id, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Name", patient.Name, DbType.String, ParameterDirection.Input);
            parameters.Add("@Address", patient.Address, DbType.String, ParameterDirection.Input);
            parameters.Add("@CNIC", patient.CNIC, DbType.Int64, ParameterDirection.Input);
            parameters.Add("@DOB", patient.DOB, DbType.Date, ParameterDirection.Input);
            parameters.Add("@Contact", patient.Contact, DbType.Int64, ParameterDirection.Input);
            parameters.Add("@Gender", patient.Gender, DbType.String, ParameterDirection.Input);
            parameters.Add("@UserId", patient.UserId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Active", patient.Active, DbType.Boolean, ParameterDirection.Input);
            parameters.Add("@CreatedAt", patient.CreatedAt, DbType.DateTime, ParameterDirection.Input);
            parameters.Add("@CreatedBy", patient.CreatedBy, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@ModifiedAt", patient.ModifiedAt, DbType.DateTime, ParameterDirection.Input);
            parameters.Add("@ModifiedBy", patient.ModifiedBy, DbType.Int32, ParameterDirection.Input);
            return _helper.ExecuteSP<int>("[UpdatePatient]", parameters).FirstOrDefault();
        }

        public Patient GetPatientById(int Id)
        {
            _logger.LogInformation($"{_repositoryName} - GetMedicineById");
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Id", Id, DbType.Int64, ParameterDirection.Input);
            return _helper.ExecuteSP<Patient>("GetPatientById", parameters).FirstOrDefault();
        }

        public List<Patient> GetAll()
        {
            _logger.LogInformation($"{_repositoryName} - GetAll");
            return _helper.ExecuteSP<Patient>("[GetAllPatient]").ToList();
        }
    }
}
