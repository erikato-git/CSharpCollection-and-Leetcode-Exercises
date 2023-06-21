using LoadDataFromJsonFilesToDB_MVC;
using Microsoft.EntityFrameworkCore;

public class DataContext: DbContext
{
    public DataContext(DbContextOptions<DataContext> options): base(options)
    {
    }

    public DbSet<Group> Groups { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<PriceModel> Prices { get; set; }




}
