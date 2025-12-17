using Axia.Domain.Entities;
using Axia.Domain.Repositories;
using Axia.Infra.Context;
using Microsoft.EntityFrameworkCore;


namespace Infra.Repository;


public class VeiculoRepository : IVeiculoRepository
{
    private readonly AppDbContext _context;


    public VeiculoRepository(AppDbContext context)
    {
        _context = context;
    }


    public async Task AddAsync(Veiculo veiculo)
    {
        _context.Veiculos.Add(veiculo);
        await _context.SaveChangesAsync();
    }


    public async Task UpdateAsync(Veiculo veiculo)
    {
        _context.Veiculos.Update(veiculo);
        await _context.SaveChangesAsync();
    }


    public async Task DeleteAsync(Guid id)
    {
        var veiculo = await GetByIdAsync(id);
        if (veiculo != null)
        {
            _context.Veiculos.Remove(veiculo);
            await _context.SaveChangesAsync();
        }
    }


    public async Task<Veiculo?> GetByIdAsync(Guid id)
    => await _context.Veiculos.FirstOrDefaultAsync(x => x.Id == id);


    public async Task<IEnumerable<Veiculo>> GetAllAsync()
    => await _context.Veiculos.ToListAsync();
}