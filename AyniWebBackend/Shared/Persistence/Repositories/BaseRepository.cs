using AyniWebBackend.Shared.Persistence.Contexts;

namespace AyniWebBackend.Shared.Persistence.Repositories;

public class BaseRepository
{
    protected readonly AppDbContext _context;

    public BaseRepository(AppDbContext context)
    {
        _context = context;
    }
}