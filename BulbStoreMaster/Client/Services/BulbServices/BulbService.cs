using BulbStoreMaster.Shared;
using System.Net.Http.Json;
using System.Reflection.Metadata.Ecma335;

namespace BulbStoreMaster.Client.Services.BulbServices;

public class BulbService : IBulbService
{
    private readonly HttpClient _http;

    public string? Message { get; set; }

    public event Action? BulbChanged;

    public BulbService(HttpClient http)
    {
        _http = http;
    }

    public async Task<bool> CreateBulbAsync(Bulb bulb)
    {
        var result = await _http.PostAsJsonAsync("api/Bulb", bulb);
        return result.IsSuccessStatusCode;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var result = await _http.DeleteAsync($"api/Bulb/{id}");
        return result.IsSuccessStatusCode;
    }

    public async Task<Bulb> GetBulbAsync(int? id)
    {
        var bulb = await _http.GetFromJsonAsync<Bulb>($"api/Bulb/{id}");
        if (bulb is not null)
            return bulb;

        throw new Exception("Bulb not found");
    }

    public async Task<IEnumerable<Bulb>> GetBulbsAsync()
    {
        var bulbs = await _http.GetFromJsonAsync<IEnumerable<Bulb>>("api/Bulbs");
        if (bulbs is not null)
        {
            if (bulbs!.Count() is 0)
                Message = "There is not bulbs :\"";

            return bulbs;
        }


        throw new Exception("Bulbs not found");
    }

    public async Task<bool> UpdateBulbAsync(Bulb bulb)
    {
        var result = await _http.PutAsJsonAsync($"api/Bulb/{bulb.Id}", bulb);
        return result.IsSuccessStatusCode;
    }
}
