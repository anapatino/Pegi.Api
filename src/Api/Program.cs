using Api;
using Data;
using Microsoft.EntityFrameworkCore;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

ConfigurationManager configuration = builder.Configuration;
string connectionString =
    configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<PegiDbContext>(options =>
    options.SetupDatabaseEngine(connectionString)
        .UseSnakeCaseNamingConvention()
);

builder.Services.AddRepositories();
builder.Services.AddServices();
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
    options.AddPolicy("pegi",
        policy => policy.WithOrigins("*").AllowAnyMethod().AllowAnyMethod())
);


WebApplication app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("pegi");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
