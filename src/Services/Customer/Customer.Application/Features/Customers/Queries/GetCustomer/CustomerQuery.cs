using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
