using CBVinil.Application.Vendas.Commands.VenderDiscos;
using CBVinil.Application.Vendas.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace CBVinil.Tests.Projects.Application.Vendas.Commands.VenderDiscos
{
    public class VenderDiscosCommandValidatorTests
    {
        private readonly VenderDiscosCommandValidator _commandValidator;

        public VenderDiscosCommandValidatorTests()
        {
            _commandValidator = new VenderDiscosCommandValidator();
        }

        [Fact]
        public async Task Success_Validate()
        {
            var command = new VenderDiscosCommand()
            {
                Discos = new List<VenderDiscoViewModel>()
                {
                    new VenderDiscoViewModel()
                    {
                        IdDisco = 1,
                        Quantidade = 1
                    }
                }
            };

            var result = await _commandValidator.ValidateAsync(command);

            Assert.Empty(result.Errors);
        }

        [Fact]
        public async Task Error_Validate()
        {
            var command = new VenderDiscosCommand();

            var result = await _commandValidator.ValidateAsync(command);

            Assert.NotEmpty(result.Errors);
        }
    }
}
