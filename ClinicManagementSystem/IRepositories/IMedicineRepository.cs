using ClinicManagementSystem.Model;

namespace ClinicManagementSystem.IRepositories
{
    public interface IMedicineRepository
    {
        List<Medicine> GetAll();
        Medicine GetMedicineById(int Id);
        int Add(Medicine medicine);
        int Edit(Medicine medicine);
        bool Delete(int Id);
    }
}
