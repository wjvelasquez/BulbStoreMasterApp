using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace BulbStoreMaster.Server.Repositories;

public class BulbRepository : IBulbRepository
{
    private readonly DataContext _context;

    public BulbRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Bulb>> GetBullsAsync()
    {
        var bulbs = await _context.Bulbs.ToListAsync();
        return bulbs;
    }

    public async Task<Bulb> GetBullByIdAsync(int? id)
    {
        var bulb = await _context.Bulbs.FindAsync(id);
        if (bulb is not null) 
            return bulb;

        throw new Exception("Bulb not found");
    }
    public async Task<Bulb> CreateAsync(Bulb bulb)
    {
        await _context.Bulbs.AddAsync(bulb);
        await _context.SaveChangesAsync();
        return bulb;
    }

    public async Task<Bulb> UpdateAsync(Bulb bulb, int? id)
    {
        var currentBulb = await _context.Bulbs!.FirstOrDefaultAsync(b => b.Id == id);
        if (currentBulb is not null)
        {
            //newBulb = bulb;

            currentBulb.Description = bulb.Description;
            currentBulb.type = bulb.type;
            currentBulb.Power = bulb.Power;
            currentBulb.Lumens = bulb.Lumens;
            currentBulb.Color = bulb.Color;
            currentBulb.Cod = bulb.Cod;

            await _context.SaveChangesAsync();
            return currentBulb;

        }

        return bulb;
    }
    public async Task<bool> DeleteAsync(int id)
    {
        var toDelBulb = await _context.Bulbs!.FindAsync(id);

        if (toDelBulb is not null)
        {
            _context.Bulbs!.Remove(toDelBulb);
            await _context.SaveChangesAsync();
            return true;
        }

        return false;
    }
}
