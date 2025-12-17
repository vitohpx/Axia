using Axia.Application.Commands.Adicionar;
using FluentValidation;

namespace Application.Commands.Adicionar;

public class AdicionarVeiculoValidator : AbstractValidator<AdicionarVeiculoCommand>
{
    public AdicionarVeiculoValidator()
    {
        RuleFor(x => x.Descricao)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
            .WithMessage("A descrição do veículo é obrigatória.");

        RuleFor(x => x.Modelo)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
            .WithMessage("O modelo do veículo é obrigatório.");

        RuleFor(x => x.Marca)
            .Cascade(CascadeMode.Stop)
            .IsInEnum()
            .WithMessage("A marca do veículo informada é inválida.");
    }
}