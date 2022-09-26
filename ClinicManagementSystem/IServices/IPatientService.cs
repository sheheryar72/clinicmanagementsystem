using ClinicManagementSystem.Model;

namespace ClinicManagementSystem.IServices
{
    public interface IPatientService : IService<Patient>
    {
        Patient GetPatientById(int Id);
        int Add(Patient patient);
        int Edit(Patient patient);
        bool Delete(int Id);
    }
}
