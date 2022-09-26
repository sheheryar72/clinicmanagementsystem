using ClinicManagementSystem.HelperLibraries.Database;
using ClinicManagementSystem.IRepositories;
using ClinicManagementSystem.Model;
using Dapper;
using System.Data;

namespace ClinicManagementSystem.Repositories
{
    public class PatientDiagnoseRepository : IPatientDiagnoseRepository
    {
        private readonly IDbDapper _helper;
        private readonly ILogger<PatientDiagnoseRepository> _logger;
        private readonly string _repositoryName = "PatientDiagnoseRepository";
        public PatientDiagnoseRepository(IDbDapper dbDapper, ILogger<PatientDiagnoseRepository> logger)
        {
            _helper = dbDapper;
            _logger = logger;
        }
        public int Add(PatientDiagnose patientDiagnose)
        {
            _logger.LogInformation($"{_repositoryName} - Add");
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Diagnose", patientDiagnose.Diagnose, DbType.String, ParameterDirection.Input);
            parameters.Add("@Discription", patientDiagnose.Discription, DbType.String, ParameterDirection.Input);
            parameters.Add("@Visit", patientDiagnose.Visit, DbType.DateTime, ParameterDirection.Input);
            parameters.Add("@NextVisit", patientDiagnose.NextVisit, DbType.DateTime, ParameterDirection.Input);
            parameters.Add("@BP", patientDiagnose.BP, DbType.String, ParameterDirection.Input);
            parameters.Add("@Weight", patientDiagnose.Weight, DbType.String, ParameterDirection.Input);
            parameters.Add("@PatientId", patientDiagnose.PatientId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@UserId", patientDiagnose.UserId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@MedicineId", patientDiagnose.MedicineId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Active", patientDiagnose.Active, DbType.Boolean, ParameterDirection.Input);
            parameters.Add("@CreatedAt", patientDiagnose.CreatedAt, DbType.DateTime, ParameterDirection.Input);
            parameters.Add("@CreatedBy", patientDiagnose.CreatedBy, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@ModifiedAt", patientDiagnose.ModifiedAt, DbType.DateTime, ParameterDirection.Input);
            parameters.Add("@ModifiedBy", patientDiagnose.ModifiedBy, DbType.Int32, ParameterDirection.Input);
            return _helper.ExecuteSP<int>("[InsertPatientDiagnose]", parameters).FirstOrDefault();
        }

        public bool Delete(int Id)
        {
            _logger.LogInformation($"{_repositoryName} - Delete");
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Id", Id, DbType.Int32, ParameterDirection.Input);
            return _helper.ExecuteSP<int>("[DeletePatientDiagnose]", parameters).FirstOrDefault() > 0;
        }

        public int Edit(PatientDiagnose patientDiagnose)
        {
            _logger.LogInformation($"{_repositoryName} - Edit");
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Id", patientDiagnose.Id, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Diagnose", patientDiagnose.Diagnose, DbType.String, ParameterDirection.Input);
            parameters.Add("@Discription", patientDiagnose.Discription, DbType.String, ParameterDirection.Input);
            parameters.Add("@Visit", patientDiagnose.Visit, DbType.DateTime, ParameterDirection.Input);
            parameters.Add("@NextVisit", patientDiagnose.NextVisit, DbType.DateTime, ParameterDirection.Input);
            parameters.Add("@BP", patientDiagnose.BP, DbType.String, ParameterDirection.Input);
            parameters.Add("@Weight", patientDiagnose.Weight, DbType.String, ParameterDirection.Input);
            parameters.Add("@PatientId", patientDiagnose.PatientId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@UserId", patientDiagnose.UserId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@MedicineId", patientDiagnose.MedicineId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Active", patientDiagnose.Active, DbType.Boolean, ParameterDirection.Input);
            parameters.Add("@CreatedAt", patientDiagnose.CreatedAt, DbType.DateTime, ParameterDirection.Input);
            parameters.Add("@CreatedBy", patientDiagnose.CreatedBy, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@ModifiedAt", patientDiagnose.ModifiedAt, DbType.DateTime, ParameterDirection.Input);
            parameters.Add("@ModifiedBy", patientDiagnose.ModifiedBy, DbType.Int32, ParameterDirection.Input);
            return _helper.ExecuteSP<int>("[UpdatePatientDiagnose]", parameters).FirstOrDefault();
        }

        public PatientDiagnose GetMedicineById(int Id)
        {
            _logger.LogInformation($"{_repositoryName} - GetMedicineById");
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Id", Id, DbType.Int64, ParameterDirection.Input);
            return _helper.ExecuteSP<PatientDiagnose>("GetPatientDiagnoseById", parameters).FirstOrDefault();
        }

        public List<PatientDiagnose> GetAll()
        {
            _logger.LogInformation($"{_repositoryName} - GetAll");
            return _helper.ExecuteSP<PatientDiagnose>("[GetAllPatientDiagnose]").ToList();
        }
    }
}
