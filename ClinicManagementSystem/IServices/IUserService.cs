using ClinicManagementSystem.Model;

namespace ClinicManagementSystem.IServices
{
    public interface IUserService : IService<User>
    {
        User GetUserById(int Id);
        int Add(User user);
        int Edit(User user);
        bool Delete(int Id);
    }
}
