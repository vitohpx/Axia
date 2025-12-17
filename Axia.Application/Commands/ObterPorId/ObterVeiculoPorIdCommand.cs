using Axia.Domain.Entities;
using MediatR;

namespace Application.Commands.ObterPorId;

public record ObterVeiculoPorIdCommand(Guid Id) : IRequest<Veiculo?>;