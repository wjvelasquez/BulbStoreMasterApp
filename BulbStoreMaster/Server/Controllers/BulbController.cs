using BulbStoreMaster.Server.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BulbStoreMaster.Server.Controllers;
[Route("api/[controller]")]
[ApiController]
public class BulbController : ControllerBase
{
    private readonly IBulbRepository _repository;
    //private readonly DataContext _context;

    public BulbController(IBulbRepository repository)
    {
        _repository = repository;
        //_context = context;
    }

    /// <summary>
    /// full load
    /// </summary>
    /// <returns></returns>
    [HttpGet("/api/Bulbs")]
    public async Task<ActionResult<IEnumerable<Bulb>>> GetBuldsAsync()
    {
        try
        {
            var bulbs = await _repository.GetBullsAsync();
            //var bulbs = await _context.Bulbs!.ToListAsync();
            return Ok(bulbs);
        }
        catch (Exception)
        {
            return BadRequest("Something was bad!");
        }
    }

    /// <summary>
    /// search by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<Bulb>> GetBuldAsync(int? id)
    {
        var bulb = await _repository.GetBullByIdAsync(id);
        //var bulb = await _context.Bulbs!.FindAsync(id);
        return Ok(bulb);
    }

    /// <summary>
    /// create new bulb
    /// </summary>
    /// <param name="bulb"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<ActionResult<Bulb>> CreateBulbAsync(Bulb bulb)
    {
        //await _context.AddAsync(bulb);
        //await _context.SaveChangesAsync();
        var newBulb = await _repository.CreateAsync(bulb);
        return Ok(newBulb);
    }

    /// <summary>
    /// Update a bulb
    /// </summary>
    /// <param name="bulb"></param>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public async Task<ActionResult<Bulb>> UpdateBulbAsync(Bulb bulb, int? id)
    {
        var newBulb = await _repository.UpdateAsync(bulb, id);
        return Ok(newBulb);
    }

    /// <summary>
    /// Delete a bulb
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public async Task<ActionResult<bool>> DeleteBulbAsync(int id)
    {
        var toDelBulb = await _repository.DeleteAsync(id);

        if (toDelBulb is true)
            return Ok(true);

        return BadRequest(false);
    }
}
