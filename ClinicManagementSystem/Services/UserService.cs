using ClinicManagementSystem.IRepositories;
using ClinicManagementSystem.IServices;
using ClinicManagementSystem.Model;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ClinicManagementSystem.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ILogger<UserService> _logger;
        private readonly string _serviceName = "UserService";
        public UserService(IUserRepository userRepository, ILogger<UserService> logger)
        {
            _userRepository = userRepository;
            _logger = logger;
        }

        public int Add(User user)
        {
            _logger.LogInformation($"{_serviceName} - Add");
            return _userRepository.Add(user);
        }

        public bool Delete(int Id)
        {
            _logger.LogInformation($"{_serviceName} - Delete");
            return _userRepository.Delete(Id);
        }

        public int Edit(User user)
        {
            _logger.LogInformation($"{_serviceName} - Edit");
            return _userRepository.Edit(user);
        }

        public List<User> GetAll()
        {
            _logger.LogInformation($"{_serviceName} - GetAll");
            return _userRepository.GetAll();
        }

        public User GetUserById(int Id)
        {
            _logger.LogInformation($"{_serviceName} - GetUserById");
            return _userRepository.GetUserById(Id);
        }
    }
}
