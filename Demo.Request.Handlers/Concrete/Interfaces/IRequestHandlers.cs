using Demo.Request.Handlers.Contracts;

namespace Demo.Request.Handlers.Concrete.Interfaces;

public interface IRequestHandlers
{
    IHandler<TRequest, TResponse> GetHandler<TRequest, TResponse>()
        where TRequest : IRequest<TResponse>;

    IHandler<TRequest> GetHandler<TRequest>()
        where TRequest : IRequest;
}
