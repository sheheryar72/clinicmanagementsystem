namespace ClinicManagementSystem.IServices
{
    public interface IService<T>
    {
        List<T> GetAll();
    }
}
