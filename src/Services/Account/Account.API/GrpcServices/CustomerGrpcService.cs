using Customer.GRPC.Protos;

namespace Account.API.GrpcServices
{
    public class CustomerGrpcService(CustomerProtoService.CustomerProtoServiceClient customerProtoServiceClient)
        {
        public async Task<bool> CheckCustomer(Guid id)
        {
            var result = await customerProtoServiceClient.CheckCustomerAsync(new CheckCustomerRequest { Id = id.ToString() });
            return result is { Result: true };
        }
    }
}
