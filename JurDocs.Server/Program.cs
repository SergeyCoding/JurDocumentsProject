using JurDocs.Common.Loggers;
using JurDocs.DbModel;
using JurDocs.Server.Configurations;
using JurDocs.Server.Service;
using Microsoft.OpenApi.Models;
using NLog;
using NLog.Web;

namespace JurDocs.Server
{
    public class Program
    {
        private const string _appsettingFile = "appsettings.json";

        public static void Main(string[] args)
        {
            var configStart = new ConfigurationBuilder().AddJsonFile(_appsettingFile).Build();
            var jdSettings = configStart.GetSection(JurDocsApp.sectionName).Get<JurDocsApp>();

            if (!string.IsNullOrWhiteSpace(jdSettings?.LogDir))
                LogManager.Configuration.Variables["logDirectory"] = jdSettings.LogDir;

            var logger = LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
            logger.Debug("init main");

            try
            {
                var builder = WebApplication.CreateBuilder(args);

                // Add services to the container.
                builder.Services.AddControllers();

                // NLog: Setup NLog for Dependency injection
                builder.Logging.ClearProviders();
                builder.Host.UseNLog();

                // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
                builder.Services.AddEndpointsApiExplorer();
                builder.Services.AddSwaggerGen(c =>
                {
                    c.EnableAnnotations();

                    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                    {
                        Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n 
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
                        Name = "Authorization",
                        In = ParameterLocation.Header,
                        Type = SecuritySchemeType.ApiKey,
                        Scheme = "Bearer"
                    });

                    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                    {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,
                        },
                        new List<string>()
                    }
                    });
                });

                builder.Services.AddDbContext<JurDocsDbContext>();

                builder.Services.AddAuthentication(JurDocsAuthOptions.DefaultScheme)
                    .AddScheme<JurDocsAuthOptions, JurDocsAuthHandler>(JurDocsAuthOptions.DefaultScheme,
                                                                       options => { });

                var app = builder.Build();

                CheckDb(app);

                app.UseCors(c =>
                {
                    c.AllowAnyOrigin();
                    c.AllowAnyHeader();
                    c.AllowAnyMethod();
                });

                app.UseSwagger();
                app.UseSwaggerUI();

                app.UseAuthentication();
                app.UseAuthorization();


                app.MapControllers();

                app.Run();
            }
            catch (Exception e)
            {
                // NLog: catch setup errors
                logger.Error(e, "Stopped program because of exception");
                throw;
            }
            finally
            {
                // Ensure to flush and stop internal timers/threads before application-exit (Avoid segmentation fault on Linux)
                LogManager.Shutdown();
            }
        }

        private static void CheckDb(WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var logger = scope.ServiceProvider.GetRequiredService<ILogger<LogConsole>>();

                try
                {
                    var db = scope.ServiceProvider.GetRequiredService<JurDocsDbContext>();
                    db.Database.EnsureCreated();

                    if (!db.Set<JurDocUser>().Any(x => x.Login == "root"))
                    {
                        db.Set<JurDocUser>().Add(new JurDocUser { Id = 1, Login = "root", Name = "root", Password = "root", Path = "" });
                        db.SaveChanges();
                    }
                }
                catch (Exception e)
                {
                    logger.LogError(e, "{msg}", "Не удалось создать БД");
                }
            }
        }
    }
}
