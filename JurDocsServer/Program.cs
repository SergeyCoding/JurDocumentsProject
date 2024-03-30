using DbModel;
using JurDocsServer.Service;

namespace JurDocsServer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c => { c.EnableAnnotations(); });
            builder.Services.AddTransient<SecurityInfoReader>();
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

        private static void CheckDb(WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                try
                {
                    var db = scope.ServiceProvider.GetRequiredService<JurDocsDbContext>();
                    db.Database.EnsureCreated();

                    db.Set<JurDocUser>().Add(new JurDocUser { Id = 1, Login = "root", Name = "root", Password = "root", Path = "" });
                    db.SaveChanges();

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    Console.WriteLine("Не удалось создать БД");
                    return;
                }
            }
        }
    }
}
