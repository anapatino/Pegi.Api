using Entities;
using Microsoft.EntityFrameworkCore;

namespace Data;

public class PegiDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<City> Cities { get; set; }
    public  DbSet<Person> Persons{ get; set; }

    public PegiDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasIndex(user => user.Name)
            .IsUnique();
    }
}
