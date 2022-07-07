using Api;
using Api.Controllers.People;
using Data;
using Entities;
using Mapster;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;
var connectionString =
    configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<PegiDbContext>(options =>
    options.SetupDatabaseEngine(connectionString)
        .UseSnakeCaseNamingConvention()
);

TypeAdapterConfig.GlobalSettings.NewConfig<CreatePersonRequest, Person>()
    .PreserveReference(true);
TypeAdapterConfig.GlobalSettings.NewConfig<CreateStudyRequest, Study>()
    .PreserveReference(true);
TypeAdapterConfig.GlobalSettings
    .NewConfig<CreateExperienceRequest, Experience>()
    .PreserveReference(true);


TypeAdapterConfig.GlobalSettings.NewConfig<Person, PersonResponse>()
    .PreserveReference(true);
TypeAdapterConfig.GlobalSettings.NewConfig<Study, StudyResponse>()
    .PreserveReference(true);
TypeAdapterConfig.GlobalSettings
    .NewConfig<Experience, ExperienceResponse>()
    .PreserveReference(true);

builder.Services.AddRepositories();
builder.Services.AddServices();
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
    options.AddDefaultPolicy(
        policy => policy.WithOrigins("*").AllowAnyMethod().AllowAnyHeader())
);


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
