namespace ClinicManagementSystem.Model
{
    public class Patient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public long CNIC { get; set; }
        public DateTime DOB { get; set; }
        public long Contact { get; set; }
        public string Gender { get; set; }
        public int UserId { get; set; }
        public bool Active { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public int? ModifiedBy { get; set; }
    }
}
