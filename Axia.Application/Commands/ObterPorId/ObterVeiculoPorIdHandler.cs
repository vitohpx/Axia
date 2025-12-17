using Axia.Application.Services.Interfaces;
using Axia.Domain.Entities;
using Axia.Domain.Error;
using MediatR;

namespace Application.Commands.ObterPorId;

public class ObterVeiculoPorIdHandler : IRequestHandler<ObterVeiculoPorIdCommand, Veiculo?>
{
    private readonly IVeiculoService _service;

    public ObterVeiculoPorIdHandler(IVeiculoService service)
    {
        _service = service;
    }

    public async Task<Veiculo> Handle(ObterVeiculoPorIdCommand request, CancellationToken cancellationToken)
    {
        var veiculo = await _service.GetByIdAsync(request.Id);

        if (veiculo is null) 
            throw new NotFoundException(
                "Veículo",
                $"Veículo com Id {request.Id} não foi encontrado.");

        return veiculo;
    }
}