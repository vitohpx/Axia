using Axia.Domain.Enums;
using MediatR;

namespace Axia.Application.Commands.Adicionar;

public record AdicionarVeiculoCommand(
    string Descricao,
    Marca Marca,
    string Modelo,
    decimal? Valor
) : IRequest<Guid>;