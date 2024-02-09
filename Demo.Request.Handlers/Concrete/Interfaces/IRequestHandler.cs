using Demo.Request.Handlers.Contracts;

namespace Demo.Request.Handlers.Concrete.Interfaces;

public interface IRequestHandler
{
    Task<TResponse> ExecuteAsync<TRequest, TResponse>(TRequest request, CancellationToken token)
        where TRequest : IRequest<TResponse>;

    Task ExecuteAsync<TRequest>(TRequest request, CancellationToken token)
        where TRequest : IRequest;
}
