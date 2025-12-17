using Axia.Application.Services.Interfaces;
using Axia.Domain.Entities;
using MediatR;

namespace Application.Commands.Atualizar;

public class AtualizarVeiculoHandler
    : IRequestHandler<AtualizarVeiculoCommand, Unit>
{
    private readonly IVeiculoService _service;

    public AtualizarVeiculoHandler(IVeiculoService service)
    {
        _service = service;
    }

    public async Task<Unit> Handle(
        AtualizarVeiculoCommand request,
        CancellationToken cancellationToken)
    {
        var veiculo = new Veiculo
        {
            Id = request.Id,
            Descricao = request.Descricao,
            Marca = request.Marca,
            Modelo = request.Modelo,
            Valor = request.Valor
        };

        await _service.UpdateAsync(veiculo);

        return Unit.Value;
    }
}
