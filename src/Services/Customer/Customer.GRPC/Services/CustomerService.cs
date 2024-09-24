using Customer.Application.Contracts.Persistence;
using Customer.GRPC.Protos;
using Grpc.Core;

namespace Customer.GRPC.Services
{
    public class CustomerService(ICustomerRepository customerRepository, ILogger<CustomerService> logger)
        : CustomerProtoService.CustomerProtoServiceBase
        {
        public override async Task<CheckCustomerModel> CheckCustomer(CheckCustomerRequest request, ServerCallContext context)
        {
            if (!string.IsNullOrEmpty(request.Id))
                return new CheckCustomerModel
                {
                    Result = await customerRepository.AnyAsync(x => x.Id == Guid.Parse(request.Id))
                };
            logger.LogWarning("Customer id is not valid.");
            
            return new CheckCustomerModel() { Result = false };
        }
    }
}
