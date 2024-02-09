using Customer.Application.Features.Customers.Queries.GetCustomer;
using MediatR;

namespace Customer.Application.Features.Customers.Commands.CreateCustomer
{
    public class CreateCustomerCommand : IRequest<CustomerDto>
    {
        public string Email { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
    }
}
