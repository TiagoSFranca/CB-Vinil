using CBVinil.Common.Helpers;
using Xunit;

namespace CBVinil.Tests.Projects.Common.Helpers
{
    public class Base64HelperTests
    {
        [Theory]
        [InlineData("Teste 01")]
        [InlineData("Teste 02")]
        [InlineData(null)]
        [InlineData("  ")]
        public void Success_Encode(string text)
        {
            var resultado = Base64Helper.Encode(text);
            Assert.NotNull(resultado);
        }
    }
}
