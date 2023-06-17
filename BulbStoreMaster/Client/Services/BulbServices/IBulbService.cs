using BulbStoreMaster.Shared;

namespace BulbStoreMaster.Client.Services.BulbServices;

public interface IBulbService
{
    event Action? BulbChanged;
    string? Message { get; set; }
    Task<IEnumerable<Bulb>> GetBulbsAsync();
    Task<Bulb> GetBulbAsync(int? id);
    Task<bool> CreateBulbAsync(Bulb bulb);
    Task<bool> UpdateBulbAsync(Bulb bulb);
    Task<bool> DeleteAsync(Bulb bulb);
}
