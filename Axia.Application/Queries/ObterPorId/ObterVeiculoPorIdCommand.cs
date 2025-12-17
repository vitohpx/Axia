using Axia.Domain.Entities;
using MediatR;

namespace Axia.Application.Queries.ObterPorId;

public record ObterVeiculoPorIdCommand(Guid Id) : IRequest<Veiculo?>;