namespace BulbStoreMaster.Server.Data;

public class DataContext : DbContext
{
  public DataContext(DbContextOptions<DataContext> options) : base(options)
  {

  }
  public DbSet<Bulb>? Bulbs { get; set; }
}
