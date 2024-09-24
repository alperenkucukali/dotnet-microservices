// using AutoMapper;
// using Customer.Application.Contracts.Persistence;
// using Customer.Application.Features.Customers.Queries.GetCustomer;
// using MediatR;
// using Microsoft.Extensions.Logging;
//
// namespace Customer.Application.Features.Customers.Commands.CreateCustomer
// {
//     public class CreateCustomerHandler(
//         ICustomerRepository customerRepository,
//         IMapper mapper,
//         ILogger<CreateCustomerHandler> logger)
//         : IRequestHandler<CreateCustomerCommand, CustomerDto>
//         {
//         private readonly ILogger<CreateCustomerHandler> _logger = logger;
//
//         public async Task<CustomerDto> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
//         {
//             var customerEntity = mapper.Map<Domain.Entities.Customer>(request);
//             var newCustomer = await customerRepository.AddAsync(customerEntity!);
//             return mapper.Map<CustomerDto>(newCustomer)!;
//         }
//     }
// }
