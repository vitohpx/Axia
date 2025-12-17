using Axia.Domain.Entities;
using MediatR;

namespace Application.Commands.Listar;

public record ListarVeiculosCommand() : IRequest<IEnumerable<Veiculo>>;