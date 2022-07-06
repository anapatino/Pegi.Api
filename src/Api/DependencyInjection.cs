using Data.Repositories;
using Services;

namespace Api;

public static class DependencyInjection
{
    public static void AddRepositories(this IServiceCollection repositories)
    {
        repositories.AddScoped<UsersRepository>();
        repositories.AddScoped<DepartmentsRepository>();
        repositories.AddScoped<CitiesRepository>();
        repositories.AddScoped<CountriesRepository>();
        repositories.AddScoped<PeopleRepository>();
        repositories.AddScoped<CVRepository>();
        repositories.AddScoped<MembersRepository>();
        repositories.AddScoped<ProgramsRepository>();
        repositories.AddScoped<LinesInvestigationRepository>();
        repositories.AddScoped<SublinesInvestigationRepository>();
        repositories.AddScoped<ThematicAreasRepository>();
        repositories.AddScoped<ProposalsRepository>();
        repositories.AddScoped<ProjectsRepository>();
    }

    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<AuthService>();
        services.AddScoped<UsersService>();
        services.AddScoped<LocationsService>();
        services.AddScoped<PeopleService>();
        services.AddScoped<CVService>();
        services.AddScoped<MembersService>();
        services.AddScoped<ProgramsService>();
        services.AddScoped<LinesInvestigationService>();
        services.AddScoped<SublinesInvestigationService>();
        services.AddScoped<ThematicAreasService>();
        services.AddScoped<ProposalsService>();
        services.AddScoped<ProjectsService>();
    }
}
