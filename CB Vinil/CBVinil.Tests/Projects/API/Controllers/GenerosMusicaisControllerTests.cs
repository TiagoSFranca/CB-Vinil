using CBVinil.Tests.Settings.Factories;
using CBVinil.Tests.Settings.Seeds;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace CBVinil.Tests.Projects.API.Controllers
{
    public class GenerosMusicaisControllerTests
    {
        private string Url => "/api/GenerosMusicais";

        private readonly GeneroMusicalTestSeed _generoMusicalTestSeed;

        public GenerosMusicaisControllerTests()
        {
            _generoMusicalTestSeed = new GeneroMusicalTestSeed();
        }

        [Theory]
        [InlineData("nada")]
        [InlineData(null)]
        public async Task Success_Search(string nome)
        {
            HttpClient httpClient = new WebUIFactory(_generoMusicalTestSeed).CreateClient();

            var httpResponse = await httpClient.GetAsync(Url + "?nome=" + nome);

            var stringResponse = await httpResponse.Content.ReadAsStringAsync();
            Assert.Equal(HttpStatusCode.OK, httpResponse.StatusCode);
        }
    }
}
