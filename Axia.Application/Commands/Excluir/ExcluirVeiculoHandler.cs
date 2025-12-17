using Axia.Application.Services.Interfaces;
using Axia.Domain.Error;
using MediatR;

namespace Application.Commands.Excluir;

public class ExcluirVeiculoHandler : IRequestHandler<ExcluirVeiculoCommand>
{
    private readonly IVeiculoService _service;

    public ExcluirVeiculoHandler(IVeiculoService service)
    {
        _service = service;
    }

    public async Task Handle(ExcluirVeiculoCommand request, CancellationToken cancellationToken)
    {
        var veiculo = await _service.GetByIdAsync(request.Id);

        if (veiculo is null) 
            throw new NotFoundException(
                "Veículo",
                $"Veículo com Id {request.Id} não foi encontrado.");

        await _service.DeleteAsync(request.Id);
    }
}