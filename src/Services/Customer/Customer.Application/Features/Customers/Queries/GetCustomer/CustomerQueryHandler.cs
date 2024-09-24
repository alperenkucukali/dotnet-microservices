using AutoMapper;
using Customer.Application.Contracts.Persistence;
using MediatR;

namespace Customer.Application.Features.Customers.Queries.GetCustomer
{
    public class CustomerQueryHandler : IRequestHandler<CustomerQuery, CustomerDto>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public CustomerQueryHandler(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<CustomerDto> Handle(CustomerQuery request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.GetByIdAsync(request.Id);
            return _mapper.Map<CustomerDto>(customer)!;
        }
    }
}
