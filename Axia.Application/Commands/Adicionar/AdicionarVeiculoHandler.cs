using Axia.Application.Services.Interfaces;
using Axia.Domain.Entities;
using MediatR;

namespace Axia.Application.Commands.Adicionar;


public class AdicionarVeiculoHandler
    : IRequestHandler<AdicionarVeiculoCommand, Guid>
{
    private readonly IVeiculoService _service;

    public AdicionarVeiculoHandler(IVeiculoService service)
    {
        _service = service;
    }

    public async Task<Guid> Handle(
        AdicionarVeiculoCommand request,
        CancellationToken cancellationToken)
    {
        var veiculo = new Veiculo
        {
            Id = Guid.NewGuid(),
            Descricao = request.Descricao,
            Marca = request.Marca,
            Modelo = request.Modelo,
            Valor = request.Valor
        };

        return await _service.AddAsync(veiculo);
    }
}