using ClinicManagementSystem.Model;

namespace ClinicManagementSystem.IRepositories
{
    public interface IPatientDiagnoseRepository
    {
        List<PatientDiagnose> GetAll();
        PatientDiagnose GetMedicineById(int Id);
        int Add(PatientDiagnose patientDiagnose);
        int Edit(PatientDiagnose patientDiagnose);
        bool Delete(int Id);
    }
}
