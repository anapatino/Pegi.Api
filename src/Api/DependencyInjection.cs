using Api.Controllers.Auth;
using Data.Repository;
using Entities;
using Services;

namespace Api;

public static class DependencyInjection
{
    public static void AddRepositories(this IServiceCollection repositories)
    {
        repositories.AddScoped<UsersRepository>();
        repositories.AddScoped<PeopleRepository>();
        repositories.AddScoped<CitiesRepository>();
        repositories.AddScoped<DepartmentsRepository>();
        repositories.AddScoped<StudiesRespository>();
        repositories.AddScoped<ExperiencesRepository>();
        repositories.AddScoped<ProfessorRepository>();
        repositories.AddScoped<AcademicProgramsRepository>();
        repositories.AddScoped<StudentsRepository>();
        repositories.AddScoped<ThematicAreasRepository>();
        repositories.AddScoped<ResearchSubLinesRepository>();
        repositories.AddScoped<ResearchLinesRepository>();
        repositories.AddScoped<ProposalRepository>();
        repositories.AddScoped<ProposalFeedBackRepository>();
        repositories.AddScoped<HistoryProposalsRepository>();
        repositories.AddScoped<ProjectRepository>();
        repositories.AddScoped<HistoryProjectRepository>();
        repositories.AddScoped<ProjectFeedBackRepository>();
        repositories.AddScoped<MessageRepository>();
    }

    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<LocationsService>();
        services.AddScoped<AuthService>();
        services.AddScoped<UsersService>();
        services.AddScoped<PeopleService>();
        services.AddScoped<StudiesService>();
        services.AddScoped<ExperienceService>();
        services.AddScoped<ProfessorService>();
        services.AddScoped<AcademicProgramService>();
        services.AddScoped<StudentsService>();
        services.AddScoped<ThematicAreaService>();
        services.AddScoped<ResearchSubLineService>();
        services.AddScoped<ResearchLineService>();
        services.AddScoped<ProposalService>();
        services.AddScoped<ProposalFeedBackService>();
        services.AddScoped<HistoryProposalService>();
        services.AddScoped<ProjectService>();
        services.AddScoped<HistoryProjectService>();
        services.AddScoped<ProjectFeedBackService>();
        services.AddScoped<MessageService>();
    }
}
