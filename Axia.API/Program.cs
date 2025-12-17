using Axia.Domain.Repositories;
using Axia.Infra.Context;
using Infra.Repository;

public class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);


        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();


        builder.Services.AddDbContext<AppDbContext>(opt =>
        opt.UseInMemoryDatabase("AxiaDB"));


        builder.Services.AddMediatR(cfg =>
        cfg.RegisterServicesFromAssembly(typeof(AdicionarVeiculoCommand).Assembly));


        builder.Services.AddValidatorsFromAssemblyContaining<VeiculoValidator>();


        builder.Services.AddScoped<IVeiculoRepository, VeiculoRepository>();


        var app = builder.Build();


        app.UseSwagger();
        app.UseSwaggerUI();


        app.UseAuthorization();
        app.MapControllers();
        app.Run();
    }
}