using Customer.Application.Contracts.Persistence;
using Customer.GRPC.Protos;
using Grpc.Core;

namespace Customer.GRPC.Services
{
    public class CustomerService : CustomerProtoService.CustomerProtoServiceBase
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ILogger<CustomerService> _logger;

        public CustomerService(ICustomerRepository customerRepository, ILogger<CustomerService> logger)
        {
            _customerRepository = customerRepository;
            _logger = logger;
        }

        public override async Task<CheckCustomerModel> CheckCustomer(CheckCustomerRequest request, ServerCallContext context)
        {
            if (string.IsNullOrEmpty(request.Id))
            {
                _logger.LogWarning("Customer id is not valid.");
                return new CheckCustomerModel() { Result = false };
            }


            return new CheckCustomerModel
            {
                Result = await _customerRepository.AnyAsync(x => x.Id == Guid.Parse(request.Id))
            };
        }
    }
}
