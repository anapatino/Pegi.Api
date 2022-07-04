using Data;
using Services;

namespace Api;

public static class DependencyInjection
{
    public static void AddRepositories(this IServiceCollection repositories)
    {
        repositories.AddScoped<UsersRepository>();
        repositories.AddScoped<DepartmentsRepository>();
        repositories.AddScoped<CitiesRepository>();
        repositories.AddScoped<PeopleRepository>();
    }

    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<AuthService>();
        services.AddScoped<UsersService>();
        services.AddScoped<LocationsService>();
    }
}
