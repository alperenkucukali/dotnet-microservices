namespace Transaction.API.Data.DTOs.Requests
{
    public class RequestFilter
    {
        public Guid CustomerId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
