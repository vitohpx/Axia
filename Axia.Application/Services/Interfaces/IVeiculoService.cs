using Axia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Axia.Application.Services.Interfaces
{
    public interface IVeiculoService
    {
        Task AddAsync(Veiculo veiculo);
        Task UpdateAsync(Veiculo veiculo);
        Task<Veiculo?> GetByIdAsync(Guid id);
        Task<IEnumerable<Veiculo>> GetAllAsync();
        Task DeleteAsync(Guid id);
    }
}
