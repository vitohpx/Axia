using Axia.Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace Axia.Infra.Context;


public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }


    public DbSet<Veiculo> Veiculos => Set<Veiculo>();
}