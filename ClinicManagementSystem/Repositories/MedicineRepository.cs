using ClinicManagementSystem.HelperLibraries.Database;
using ClinicManagementSystem.IRepositories;
using ClinicManagementSystem.Model;
using Dapper;
using System.Data;

namespace ClinicManagementSystem.Repositories
{
    public class MedicineRepository : IMedicineRepository
    {
        private readonly IDbDapper _helper;
        private readonly ILogger<MedicineRepository> _logger;
        private readonly string _repositoryName = "MedicineRepository";
        public MedicineRepository(IDbDapper dbDapper, ILogger<MedicineRepository> logger)
        {
            _helper = dbDapper;
            _logger = logger;
        }
        public int Add(Medicine medicine)
        {
            //Serilog.Log.Information("Index Controller Called");
            _logger.LogInformation($"{_repositoryName} - Add");
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Name", medicine.Name, DbType.String, ParameterDirection.Input);
            parameters.Add("@Quantity", medicine.Quantity, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Dogose", medicine.Dogose, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Active", medicine.Active, DbType.Boolean, ParameterDirection.Input);
            parameters.Add("@UserId", medicine.UserId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@CreatedAt", medicine.CreatedAt, DbType.DateTime, ParameterDirection.Input);
            parameters.Add("@CreatedBy", medicine.CreatedAt, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@ModifiedAt", medicine.ModifiedAt, DbType.DateTime, ParameterDirection.Input);
            parameters.Add("@ModifiedBy", medicine.ModifiedBy, DbType.Int32, ParameterDirection.Input);
            return _helper.ExecuteSP<int>("[InsertMedicine]", parameters).FirstOrDefault();
        }

        public bool Delete(int Id)
        {
            _logger.LogInformation($"{_repositoryName} - Delete");
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Id", Id, DbType.Int32, ParameterDirection.Input);
            return _helper.ExecuteSP<int>("[DeleteMedicine]", parameters).FirstOrDefault() > 0;
        }

        public int Edit(Medicine medicine)
        {
            _logger.LogInformation($"{_repositoryName} - Edit");
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Id", medicine.id, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Name", medicine.Name, DbType.String, ParameterDirection.Input);
            parameters.Add("@Quantity", medicine.Quantity, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Dogose", medicine.Dogose, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Active", medicine.Active, DbType.Boolean, ParameterDirection.Input);
            parameters.Add("@UserId", medicine.UserId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@CreatedAt", medicine.CreatedAt, DbType.DateTime, ParameterDirection.Input);
            parameters.Add("@CreatedBy", medicine.CreatedBy, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@ModifiedAt", medicine.ModifiedAt, DbType.DateTime, ParameterDirection.Input);
            parameters.Add("@ModifiedBy", medicine.ModifiedBy, DbType.Int32, ParameterDirection.Input);
            return _helper.ExecuteSP<int>("[UpdateMedicine]", parameters).FirstOrDefault();
        }

        public List<Medicine> GetAll()
        {
            _logger.LogInformation($"{_repositoryName} - GetAll");
            return _helper.ExecuteSP<Medicine>("[GetAllMedicine]").ToList();
        }

        public Medicine GetMedicineById(int Id)
        {
            _logger.LogInformation($"{_repositoryName} - GetMedicineById");
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Id", Id, DbType.Int32, ParameterDirection.Input);
            return _helper.ExecuteSP<Medicine>("[GetMedicineById]", parameters).FirstOrDefault();
        }
    }
}
