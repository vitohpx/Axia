using Axia.Domain.Enums;
using MediatR;

namespace Application.Commands.Atualizar;

public record AtualizarVeiculoCommand(
    Guid Id,
    string Descricao,
    Marca Marca,
    string Modelo,
    decimal? Valor
) : IRequest<Unit>;