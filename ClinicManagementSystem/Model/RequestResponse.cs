namespace ClinicManagementSystem.Model
{
    public class RequestResponse
    {
        public int ResponseCode { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
}
