using Api;
using Data;

var builder = WebApplication.CreateBuilder(args);

ConfigurationManager configuration = builder.Configuration;

builder.Services.AddDbContext<PegiDbContext>(options =>
    options.SetupDatabaseEngine(
        configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddRepositories();
builder.Services.AddServices();
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
    options.AddPolicy("pegi",
        policy => policy.WithOrigins("*").AllowAnyMethod().AllowAnyMethod())
);


var app = builder.Build();

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
