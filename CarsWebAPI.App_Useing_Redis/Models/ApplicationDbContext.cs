using Microsoft.EntityFrameworkCore;

namespace CarsWebAPI.App_Useing_Redis.Models;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
    public DbSet<Car> Cars { get; set; } = null!;
}