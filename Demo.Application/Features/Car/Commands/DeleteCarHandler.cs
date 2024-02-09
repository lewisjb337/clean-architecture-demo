using Demo.Application.Entities.Car.Requests;
using Demo.Persistence;
using Demo.Request.Handlers.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Demo.Application.Features.Car.Commands;

public class DeleteCarHandler : IHandler<DeleteCarRequest>
{
    private readonly ApplicationDbContext _context;

    public DeleteCarHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task HandleAsync(DeleteCarRequest request, CancellationToken cancellationToken)
    {
        await _context.Car
            .Where(x => x.Id.Equals(request.id))
            .ExecuteDeleteAsync(cancellationToken);
    }
}