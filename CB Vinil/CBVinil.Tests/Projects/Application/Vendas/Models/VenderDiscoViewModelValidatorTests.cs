using CBVinil.Application.Vendas.Models;
using System.Threading.Tasks;
using Xunit;

namespace CBVinil.Tests.Projects.Application.Vendas.Models
{
    public class VenderDiscoViewModelValidatorTests
    {
        private readonly VenderDiscoViewModelValidator _validator;

        public VenderDiscoViewModelValidatorTests()
        {
            _validator = new VenderDiscoViewModelValidator();
        }

        [Fact]
        public async Task Success_Validate()
        {
            var model = new VenderDiscoViewModel()
            {
                IdDisco = 1,
                Quantidade = 1
            };

            var result = await _validator.ValidateAsync(model);

            Assert.Empty(result.Errors);
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(0, -1)]
        [InlineData(-3, 0)]
        public async Task Error_Validate(int idDisco, int quantidade)
        {
            var model = new VenderDiscoViewModel()
            {
                IdDisco = idDisco,
                Quantidade = quantidade
            };

            var result = await _validator.ValidateAsync(model);

            Assert.NotEmpty(result.Errors);
        }
    }
}
