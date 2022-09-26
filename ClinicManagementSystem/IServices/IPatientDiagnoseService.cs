using ClinicManagementSystem.Model;

namespace ClinicManagementSystem.IServices
{
    public interface IPatientDiagnoseService : IService<PatientDiagnose>
    {
        PatientDiagnose GetPatientDiagnoseById(int Id);
        int Add(PatientDiagnose patientDiagnose);
        int Edit(PatientDiagnose patientDiagnose);
        bool Delete(int Id);
    }
}
