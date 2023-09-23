using System.Text;
using Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            // Agrega el servicio DbContext
            string? connectionString = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<PegiDbContext>(options =>
                options.SetupDatabaseEngine(connectionString)
            );

            // Configura la autenticación JwtBearer
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
                };
            });

            // Agrega los servicios de repositorios y servicios
            services.AddRepositories();
            services.AddServices();

            // Agrega los controladores de la API
            services.AddControllers();

            // Agrega la documentación de Swagger
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Pegi",
                    Version = "v1",
                    Description = "Es una api para la gestion de proyectos de investigación",
                    Contact = new OpenApiContact
                    {
                        Name = "Ana Patiño",
                        Email = "sofipatino614@gmail.com"
                    }
                });

                // Configura la seguridad para Swagger UI
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme.",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                }
            },
                        Array.Empty<string>()
        }
    });
            });

            // Configura CORS para permitir peticiones desde cualquier origen
            services.AddCors(options =>
                options.AddDefaultPolicy(
                    policy => policy.WithOrigins("*").AllowAnyMethod().AllowAnyHeader())
            );
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Si estás desplegando en AWS Lambda, deshabilita el manejo de excepciones en el entorno de desarrollo
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Comenta la redirección HTTPS, ya que AWS API Gateway manejará HTTPS
            // app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseCors(); // Agrega CORS antes de los endpoints

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Welcome to running ASP.NET Core on AWS Lambda");
                });
            });

            // Configura la generación de Swagger y el punto de enlace de Swagger
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Mi API v1");
            });
        }
    }
}
