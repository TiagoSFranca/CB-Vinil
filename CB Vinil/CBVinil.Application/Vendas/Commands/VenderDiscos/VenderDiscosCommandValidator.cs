using CBVinil.Application.Vendas.Models;
using FluentValidation;

namespace CBVinil.Application.Vendas.Commands.VenderDiscos
{
    public class VenderDiscosCommandValidator : AbstractValidator<VenderDiscosCommand>
    {
        public VenderDiscosCommandValidator()
        {
            RuleFor(e => e.Discos)
                .NotEmpty()
                .NotNull();

            RuleForEach(e => e.Discos)
                .SetValidator(new VenderDiscoViewModelValidator());

        }
    }
}
