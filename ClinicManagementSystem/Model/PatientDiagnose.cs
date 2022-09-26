namespace ClinicManagementSystem.Model
{
    public class PatientDiagnose
    {
        public int Id { get; set; }
        public string Diagnose { get; set; }
        public string Discription { get; set; }
        public DateTime Visit { get; set; }
        public DateTime NextVisit { get; set; }
        public string BP { get; set; }
        public string Weight { get; set; }
        public int PatientId { get; set; }
        public int UserId { get; set; }
        public int MedicineId { get; set; }
        public bool Active { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? ModifiedAt { get; set; }
        public DateTime? ModifiedBy { get; set; }
    }
}
