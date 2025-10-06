using AyniWebBackend.Ayni.Domain.Repositories;
using AyniWebBackend.Shared.Persistence.Contexts;

namespace AyniWebBackend.Shared.Persistence.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;
    
    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }

    public async Task CompleteAsync()
    {
        await _context.SaveChangesAsync();

    }
}