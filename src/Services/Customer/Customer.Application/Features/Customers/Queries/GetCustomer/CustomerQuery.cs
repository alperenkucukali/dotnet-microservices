using MediatR;

namespace Customer.Application.Features.Customers.Queries.GetCustomer
{
    public class CustomerQuery : IRequest<CustomerDto>
    {
        public Guid Id { get; set; }
        public CustomerQuery(Guid id)
        {
            Id = id;
        }
    }
}
