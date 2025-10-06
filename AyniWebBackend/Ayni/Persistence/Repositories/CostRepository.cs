using AyniWebBackend.Ayni.Domain.Models;
using AyniWebBackend.Ayni.Domain.Repositories;
using AyniWebBackend.Shared.Persistence.Contexts;
using AyniWebBackend.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AyniWebBackend.Ayni.Persistence.Repositories;

public class CostRepository : BaseRepository, ICostRepository
{
    public CostRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Cost>> ListAsync()
    {
        return await _context.Costs
            .Include(p => p.User)
            .ToListAsync();

    }

    public async Task AddAsync(Cost cost)
    {
        await _context.Costs.AddAsync(cost);
    }

    public async Task<Cost> FindByIdAsync(int costId)
    {
        return await _context.Costs
            .Include(p => p.User)
            .FirstOrDefaultAsync(p => p.Id == costId);
    }

    public async Task<Cost> FindByTitleAsync(string name)
    {
        return await _context.Costs
            .Include(p => p.User)
            .FirstOrDefaultAsync(p => p.Name == name);
    }

    public async Task<IEnumerable<Cost>> FindByUserIdAsync(int userId)
    {
        return await _context.Costs
            .Where(p => p.UserId == userId)
            .Include(p => p.User)
            .ToListAsync();
    }

    public void Update(Cost cost)
    {
        _context.Costs.Update(cost);
    }

    public void Remove(Cost cost)
    {
        _context.Costs.Remove(cost);
    }
}