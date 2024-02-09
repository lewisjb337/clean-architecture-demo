using Demo.Request.Handlers.Concrete.Interfaces;
using Demo.Request.Handlers.Contracts;
using Demo.Request.Handlers.Exceptions;
using Microsoft.Extensions.DependencyInjection;

namespace Demo.Request.Handlers.Concrete;

internal class RequestHandlers : IRequestHandlers
{
    private readonly Dictionary<Type, Type?> _handlers;
    private readonly IServiceProvider _serviceProvider;

    public RequestHandlers(Dictionary<Type, Type?> handlers,
        IServiceProvider serviceProvider)
    {
        _handlers = handlers;
        _serviceProvider = serviceProvider;
    }

    public IHandler<TRequest, TResponse> GetHandler<TRequest, TResponse>()
        where TRequest : IRequest<TResponse>
    {
        return _handlers.TryGetValue(typeof(TRequest), out var type)
            ? _serviceProvider.GetRequiredService(type) as IHandler<TRequest, TResponse>
            : throw new HandlerNotRegisteredException();
    }

    public IHandler<TRequest> GetHandler<TRequest>() where TRequest : IRequest
    {
        return _handlers.TryGetValue(typeof(TRequest), out var type)
            ? _serviceProvider.GetRequiredService(type) as IHandler<TRequest>
            : throw new HandlerNotRegisteredException();
    }
}