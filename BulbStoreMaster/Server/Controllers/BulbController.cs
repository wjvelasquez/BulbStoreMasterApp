using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BulbStoreMaster.Server.Controllers;
[Route("api/[controller]")]
[ApiController]
public class BulbController : ControllerBase
{
    private readonly DataContext _context;

    public BulbController(DataContext context)
    {
        _context = context;
    }

    /// <summary>
    /// full load
    /// </summary>
    /// <returns></returns>
    [HttpGet("/api/Bulbs")]
    public async Task<ActionResult<Bulb>> GetBuldsAsync()
    {
        try
        {
            var bulds = await _context.Bulbs!.ToListAsync();
            return Ok(bulds);
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
        var buld = await _context.Bulbs!.FindAsync(id);
        return Ok(buld);
    }

    /// <summary>
    /// create new bulb
    /// </summary>
    /// <param name="bulb"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<ActionResult<Bulb>> CreateBulbAsync(Bulb bulb)
    {
        await _context.AddAsync(bulb);
        await _context.SaveChangesAsync();
        return Ok(bulb);
    }

    /// <summary>
    /// Update a bulb
    /// </summary>
    /// <param name="bulb"></param>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public async Task<ActionResult<Bulb>> UpdateBulbAsync(Bulb bulb, int id)
    {
        var newBulb = await _context.Bulbs!.FirstOrDefaultAsync(b => b.Id == id);
        if (newBulb is not null)
        {
            //newBulb = bulb;

            newBulb.Description = bulb.Description;
            newBulb.type = bulb.type;
            newBulb.Power = bulb.Power;
            newBulb.Lumens = bulb.Lumens;
            newBulb.Color = bulb.Color;
            newBulb.Cod = bulb.Cod;

            await _context.SaveChangesAsync();
            return Ok(newBulb);

        }

        return NotFound(bulb.Description);
    }

    /// <summary>
    /// Delete a bulb
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public async Task<ActionResult<Bulb>> DeleteBulbAsync(int id)
    {
        var toDelBulb = await _context.Bulbs!.FindAsync(id);

        if (toDelBulb is not null)
        {
            _context.Bulbs!.Remove(toDelBulb);
            await _context.SaveChangesAsync();
        }

        return Ok(new Bulb());
    }
}
