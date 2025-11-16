using Microsoft.EntityFrameworkCore;
using PaymentPlanManagement_API.Infrastructure.Persistence;

namespace PaymentPlanManagement_API.WebApi;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        string provider = builder.Configuration["Database:Provider"] ?? "Postgres";
        string connectionString = builder.Configuration.GetConnectionString("DefaultConnection")!;

        if (provider == "SqlServer")
          builder.Services.AddDbContext<ApplicationDbContext>(o => o.UseSqlServer(connectionString));
        else
          builder.Services.AddDbContext<ApplicationDbContext>(o => o.UseNpgsql(connectionString));

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
          app.UseSwagger();
          app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}
