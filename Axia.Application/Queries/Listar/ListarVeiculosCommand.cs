using Axia.Domain.Entities;
using MediatR;

namespace Axia.Application.Queries.Listar;

public record ListarVeiculosCommand() : IRequest<IEnumerable<Veiculo>>;