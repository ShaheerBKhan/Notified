using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Backend.Database;

public class Program
{
    public static void Main(string[] args)
    {
        var host = CreateHostBuilder(args).Build();

        using (var scope = host.Services.CreateScope())
        {
            var services = scope.ServiceProvider;

            try
            {
                var context = services.GetRequiredService<NotifiedContext>();
                context.Database.Migrate();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while migrating the database.");
                Console.WriteLine(ex.Message);
            }
        }

        host.Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureServices((hostContext, services) =>
            {
                string connectionString = "Host=localhost; Port=5432; Database=Notified; Username=postgres; Password=postgres;";
                services.AddDbContext<NotifiedContext>(options =>
                    options.UseNpgsql(connectionString));
            });
}