using FluentValidation;

namespace CBVinil.Application.Vendas.Models
{
    public class VenderDiscoViewModel
    {
        public int IdDisco { get; set; }
        public int Quantidade { get; set; }
    }

    public class VenderDiscoViewModelValidator : AbstractValidator<VenderDiscoViewModel>
    {
        public VenderDiscoViewModelValidator()
        {
            RuleFor(x => x.IdDisco).GreaterThan(0);
            RuleFor(x => x.Quantidade).GreaterThan(0);
        }
    }
}
