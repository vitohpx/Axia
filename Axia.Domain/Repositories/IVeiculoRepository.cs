using Axia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Axia.Domain.Repositories
{
    public interface IVeiculoRepository
    {
        Task AddAsync(Veiculo veiculo);
        Task UpdateAsync(Veiculo veiculo);
        Task DeleteAsync(Guid id);
        Task<Veiculo?> GetByIdAsync(Guid id);
        Task<IEnumerable<Veiculo>> GetAllAsync();
    }
}
