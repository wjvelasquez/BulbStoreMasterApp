namespace BulbStoreMaster.Server.Repositories;

public interface IBulbRepository
{
    Task<IEnumerable<Bulb>> GetBullsAsync();
    Task<Bulb> GetBullByIdAsync(int? id);
    Task<Bulb> CreateAsync(Bulb bulb);
    Task<Bulb> UpdateAsync(Bulb bulb, int? id);
    Task<bool> DeleteAsync(int id);
}
