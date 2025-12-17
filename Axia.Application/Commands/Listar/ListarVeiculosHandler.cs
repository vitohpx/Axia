using Axia.Application.Services.Interfaces;
using Axia.Domain.Entities;
using MediatR;

namespace Application.Commands.Listar;

public class ListarVeiculosHandler : IRequestHandler<ListarVeiculosCommand, IEnumerable<Veiculo>>
{
    private readonly IVeiculoService _service;

    public ListarVeiculosHandler(IVeiculoService service)
    {
        _service = service;
    }

    public async Task<IEnumerable<Veiculo>> Handle(ListarVeiculosCommand request, CancellationToken cancellationToken)
    {
        return await _service.GetAllAsync();
    }
}