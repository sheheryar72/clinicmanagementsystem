using ClinicManagementSystem.Model;

namespace ClinicManagementSystem.IRepositories
{
    public interface IUserRepository
    {
        List<User> GetAll();
        User GetUserById(int Id);
        int Add(User user);
        int Edit(User user);
        bool Delete(int Id);
        User AuthenticateUser(UserDTO userDTO);
    }
}
