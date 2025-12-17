using Axia.Application.Services.Interfaces;
using Axia.Domain.Entities;
using Axia.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Axia.Application.Services
{
    public class VeiculoService : IVeiculoService
    {
        private readonly IVeiculoRepository _repository;

        public VeiculoService(IVeiculoRepository repository)
        {
            _repository = repository;
        }

        public async Task AddAsync(Veiculo veiculo)
        {
            await _repository.AddAsync(veiculo);
        }

        public async Task UpdateAsync(Veiculo veiculo)
        {
            await _repository.UpdateAsync(veiculo);
        }

        public async Task<Veiculo?> GetByIdAsync(Guid id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Veiculo>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
