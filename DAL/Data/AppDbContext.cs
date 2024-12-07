using System.Reflection;


namespace DAL;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
   public  DbSet<Admin> Admins { get;set; }
   public DbSet<Company> Companies { get;set; }

}
