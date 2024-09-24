using AutoMapper;
using Customer.Application.Contracts.Persistence;
using Customer.Application.Features.Customers.Queries.GetCustomer;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Customer.Application.Features.Customers.Commands.CreateCustomer
{
    public class CreateCustomerHandler : IRequestHandler<CreateCustomerCommand, CustomerDto>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateCustomerHandler> _logger;

        public CreateCustomerHandler(ICustomerRepository customerRepository, IMapper mapper, ILogger<CreateCustomerHandler> logger)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<CustomerDto> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customerEntity = _mapper.Map<Domain.Entities.Customer>(request);
            var newCustomer = await _customerRepository.AddAsync(customerEntity!);
            return _mapper.Map<CustomerDto>(newCustomer)!;
        }
    }
}
