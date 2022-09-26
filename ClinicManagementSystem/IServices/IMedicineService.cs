using ClinicManagementSystem.Model;

namespace ClinicManagementSystem.IServices
{
    public interface IMedicineService : IService<Medicine>
    {
        Medicine GetMedicineById(int Id);
        int Add(Medicine medicine);
        int Edit(Medicine medicine);
        bool Delete(int Id);
    }
}
