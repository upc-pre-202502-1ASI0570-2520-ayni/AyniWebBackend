using AyniWebBackend.Ayni.Domain.Models;
using AyniWebBackend.Ayni.Domain.Repositories;
using AyniWebBackend.Shared.Persistence.Contexts;
using AyniWebBackend.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AyniWebBackend.Ayni.Persistence.Repositories;

public class CropRepository : BaseRepository, ICropRepository
{
    public CropRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Crop>> ListAsync()
    {
        return await _context.Crops
            .Include(p => p.User)
            .ToListAsync();
    }

    public async Task AddAsync(Crop crop)
    {
        await _context.Crops.AddAsync(crop);

    }

    public async Task<Crop> FindByIdAsync(int cropId)
    {
        return await _context.Crops
            .Include(p => p.User)
            .FirstOrDefaultAsync(p => p.Id == cropId);

    }

    public async Task<Crop> FindByTitleAsync(string name)
    {
        return await _context.Crops
            .Include(p => p.User)
            .FirstOrDefaultAsync(p => p.Name == name);
    }

    public async Task<IEnumerable<Crop>> FindByUserIdAsync(int userId)
    {
        return await _context.Crops
            .Where(p => p.UserId == userId)
            .Include(p => p.User)
            .ToListAsync();

    }

    public void Update(Crop crop)
    {
        _context.Crops.Update(crop);

    }

    public void Remove(Crop crop)
    {
        _context.Crops.Remove(crop);

    }
}