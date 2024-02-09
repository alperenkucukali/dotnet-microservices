using Customer.GRPC.Protos;

namespace Account.API.GrpcServices
{
    public class CustomerGrpcService
    {
        private readonly CustomerProtoService.CustomerProtoServiceClient _customerProtoServiceClient;

        public CustomerGrpcService(CustomerProtoService.CustomerProtoServiceClient customerProtoServiceClient)
        {
            _customerProtoServiceClient = customerProtoServiceClient;
        }

        public async Task<bool> CheckCustomer(Guid id)
        {
            var result = await _customerProtoServiceClient.CheckCustomerAsync(new CheckCustomerRequest { Id = id.ToString() });
            return result != null && result.Result;
        }
    }
}
