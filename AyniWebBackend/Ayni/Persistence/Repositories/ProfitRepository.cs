using AyniWebBackend.Ayni.Domain.Models;
using AyniWebBackend.Ayni.Domain.Repositories;
using AyniWebBackend.Shared.Persistence.Contexts;
using AyniWebBackend.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AyniWebBackend.Ayni.Persistence.Repositories;

public class ProfitRepository : BaseRepository, IProfitRepository
{
    public ProfitRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Profit>> ListAsync()
    {
        return await _context.Profits
            .Include(p => p.User)
            .ToListAsync();
    }

    public async Task AddAsync(Profit profit)
    {
        await _context.Profits.AddAsync(profit);
    }

    public async Task<Profit> FindByIdAsync(int profitId)
    {
        return await _context.Profits
            .Include(p => p.User)
            .FirstOrDefaultAsync(p => p.Id == profitId);
    }

    public async Task<Profit> FindByTitleAsync(string name)
    {
        return await _context.Profits
            .Include(p => p.User)
            .FirstOrDefaultAsync(p => p.NameP == name);
    }

    public async Task<IEnumerable<Profit>> FindByUserIdAsync(int userId)
    {
        return await _context.Profits
            .Where(p => p.UserId == userId)
            .Include(p => p.User)
            .ToListAsync();
    }

    public void Update(Profit profit)
    {
        _context.Profits.Update(profit);
    }

    public void Remove(Profit profit)
    {
        _context.Profits.Remove(profit);
    }
}