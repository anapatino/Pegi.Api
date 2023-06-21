using Microsoft.EntityFrameworkCore;

namespace Api;

public static class DataBaseProvider
{
    private const string MigrationsAssembly = "Api";


    public static DbContextOptionsBuilder SetupDatabaseEngine(
        this DbContextOptionsBuilder options, string connectionString
    )
    {
        options.UseNpgsql(connectionString, builder => builder.MigrationsAssembly(MigrationsAssembly))
            .EnableDetailedErrors();
        return options;
    }
}
