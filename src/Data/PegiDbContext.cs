using Entities;
using Microsoft.EntityFrameworkCore;

namespace Data;

public class PegiDbContext : DbContext
{
    public PegiDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<Person> People { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<Study> Studies { get; set; }
    public DbSet<Experience> Experiences { get; set; }
    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<CV> Cvs { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Program> Programs { get; set; }
    public DbSet<Committee> Committees { get; set; }
    public DbSet<LineInvestigation> LinesInvestigation { get; set; }
    public DbSet<SublineInvestigation> SublinesInvestigation { get; set; }
    public DbSet<ThematicArea> ThematicAreas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasIndex(user => user.Name)
            .IsUnique();
    }
}
