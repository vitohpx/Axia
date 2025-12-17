using MediatR;

namespace Application.Commands.Excluir;

public record ExcluirVeiculoCommand(Guid Id) : IRequest;