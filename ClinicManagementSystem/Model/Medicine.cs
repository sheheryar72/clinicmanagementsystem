namespace ClinicManagementSystem.Model
{
    public class Medicine
    {
        public int id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public int Dogose { get; set; }
        public int UserId { get; set; }
        public bool Active { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public int? ModifiedBy { get; set; }
    }
}
