using Microsoft.EntityFrameworkCore;

namespace Api;

public static class DatabaseProvider
{
    private const string MigrationsAssembly = "Api";

    public static DbContextOptionsBuilder SetupDatabaseEngine(
        this DbContextOptionsBuilder options, string connectionString
    )
    {
        MySqlServerVersion mysqlVersion = new(new Version(8, 0));
        options.UseMySql(connectionString, mysqlVersion,
            builder => builder.MigrationsAssembly(MigrationsAssembly))
            .EnableDetailedErrors();
        return options;
    }
}
