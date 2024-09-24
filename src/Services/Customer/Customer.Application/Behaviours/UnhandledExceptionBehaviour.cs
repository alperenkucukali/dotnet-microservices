using MediatR;
using Microsoft.Extensions.Logging;

namespace Customer.Application.Behaviours
{
    public class UnhandledExceptionBehaviour<TRequest, TResponse>(ILogger<TRequest> logger)
        : IPipelineBehavior<TRequest, TResponse>
        where TRequest : notnull
        {
        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            try
            {
                return await next();
            }
            catch (Exception ex)
            {
                var requestName = typeof(TRequest).Name;
                logger.LogError(ex, $"Application Request: Unhandled Exception for Request {requestName} {request}");
                throw;
            }
        }
    }
}
