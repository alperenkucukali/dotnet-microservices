namespace Customer.Application.Features.Customers.Queries.GetCustomer
{
    public class CustomerDto
    {
        public string Email { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public DateTime Created { get; set; }
    }
}
