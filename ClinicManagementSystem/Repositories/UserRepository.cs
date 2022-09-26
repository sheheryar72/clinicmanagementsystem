using ClinicManagementSystem.HelperLibraries.Database;
using ClinicManagementSystem.IRepositories;
using ClinicManagementSystem.Model;
using Dapper;
using System.Data;

namespace ClinicManagementSystem.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IDbDapper _helper;
        private readonly string _repositoryName = "UserRepository";
        private readonly ILogger<UserRepository> _logger;
        public UserRepository(IDbDapper dbDapper, ILogger<UserRepository> logger)
        {
            _helper = dbDapper;
            _logger = logger;
        }
        public User AuthenticateUser(UserDTO userDTO)
        {
            _logger.LogInformation($"{_repositoryName} - AuthenticateUser");
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Email", userDTO.Email);
            return _helper.ExecuteSP<User>("[GetUserByEmail]", parameters).FirstOrDefault();
        }
        public int Add(User user)
        {
            _logger.LogInformation($"{_repositoryName} - Add");
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Name", user.Name, DbType.String, ParameterDirection.Input);
            parameters.Add("@Email", user.Email, DbType.String, ParameterDirection.Input);
            parameters.Add("@Password", user.Password, DbType.String, ParameterDirection.Input);
            parameters.Add("@AdminId",user.AdminId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Active", user.Active, DbType.Boolean, ParameterDirection.Input);
            parameters.Add("@CreatedAt", user.CreatedAt, DbType.DateTime, ParameterDirection.Input);
            parameters.Add("@CreatedBy", user.CreatedBy, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@ModifiedAt", user.ModifiedAt, DbType.DateTime, ParameterDirection.Input);
            parameters.Add("@ModifiedBy", user.ModifiedBy, DbType.Int32, ParameterDirection.Input);
            return _helper.ExecuteSP<int>("[InsertUser]", parameters).FirstOrDefault();
        }

        public bool Delete(int Id)
        {
            _logger.LogInformation($"{_repositoryName} - Delete");
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Id", Id, DbType.Int32, ParameterDirection.Input);
            return _helper.ExecuteSP<int>("[DeleteUser]", parameters).FirstOrDefault() > 0;
        }

        public int Edit(User user)
        {
            _logger.LogInformation($"{_repositoryName} - Edit");
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Id", user.Id, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Name", user.Name, DbType.String, ParameterDirection.Input);
            parameters.Add("@Email", user.Email, DbType.String, ParameterDirection.Input);
            parameters.Add("@Password", user.Password, DbType.String, ParameterDirection.Input);
            parameters.Add("@AdminId", user.AdminId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Active", user.Active, DbType.Boolean, ParameterDirection.Input);
            parameters.Add("@CreatedAt", user.CreatedAt, DbType.DateTime, ParameterDirection.Input);
            parameters.Add("@CreatedBy", user.CreatedBy, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@ModifiedAt", user.ModifiedAt, DbType.DateTime, ParameterDirection.Input);
            parameters.Add("@ModifiedBy", user.ModifiedBy, DbType.Int32, ParameterDirection.Input);
            return _helper.ExecuteSP<int>("[UpdateUser]", parameters).FirstOrDefault();
        }

        public User GetUserById(int Id)
        {
            _logger.LogInformation($"{_repositoryName} - GetUserById");
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Id", Id, DbType.Int64, ParameterDirection.Input);
            return _helper.ExecuteSP<User>("GetUserById", parameters).FirstOrDefault();
        }
        public List<User> GetAll()
        {
            _logger.LogInformation($"{_repositoryName} - GetAll");
            return _helper.ExecuteSP<User>("[GetAllUser]").ToList();
        }

       
    }
}
