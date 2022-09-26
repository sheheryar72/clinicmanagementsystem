using ClinicManagementSystem.Model;

namespace ClinicManagementSystem.IRepositories
{
    public interface IPatientRepository
    {
        List<Patient> GetAll();
        Patient GetPatientById(int Id);
        int Add(Patient patient);
        int Edit(Patient patient);
        bool Delete(int Id);
    }
}
