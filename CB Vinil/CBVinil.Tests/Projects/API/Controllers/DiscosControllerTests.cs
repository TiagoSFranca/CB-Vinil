using CBVinil.Application.Discos.Models;
using CBVinil.Application.Paginacoes.Models;
using CBVinil.Tests.Settings.Factories;
using CBVinil.Tests.Settings.Seeds;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace CBVinil.Tests.Projects.API.Controllers
{
    public class DiscosControllerTests
    {
        private string Url => "/api/Discos";

        private readonly DiscoTestSeed _discoTestSeed;

        public DiscosControllerTests()
        {
            _discoTestSeed = new DiscoTestSeed();
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public async Task Success_GetDisco(int id)
        {
            HttpClient httpClient = new WebUIFactory(_discoTestSeed).CreateClient();

            var httpResponse = await httpClient.GetAsync(Url + "/" + id.ToString());

            var stringResponse = await httpResponse.Content.ReadAsStringAsync();
            Assert.Equal(HttpStatusCode.OK, httpResponse.StatusCode);
            var disco = JsonConvert.DeserializeObject<DiscoViewModel>(stringResponse);
            Assert.Equal(id, disco.IdDisco);
        }

        [Theory]
        [InlineData(32)]
        [InlineData(41)]
        [InlineData(-4)]
        public async Task Error_GetDisco_NotFound(int id)
        {
            HttpClient httpClient = new WebUIFactory(_discoTestSeed).CreateClient();

            var httpResponse = await httpClient.GetAsync(Url + "/" + id.ToString());

            var stringResponse = await httpResponse.Content.ReadAsStringAsync();
            Assert.Equal(HttpStatusCode.NotFound, httpResponse.StatusCode);
        }

        [Theory]
        [InlineData("nada")]
        [InlineData(null)]
        public async Task Success_Search(string nome)
        {
            HttpClient httpClient = new WebUIFactory(_discoTestSeed).CreateClient();

            var httpResponse = await httpClient.GetAsync(Url + "?nome=" + nome);

            var stringResponse = await httpResponse.Content.ReadAsStringAsync();
            Assert.Equal(HttpStatusCode.OK, httpResponse.StatusCode);
        }

        [Fact]
        public async Task Success_Search_AllItens()
        {
            HttpClient httpClient = new WebUIFactory(_discoTestSeed).CreateClient();

            var httpResponse = await httpClient.GetAsync(Url + "?pagina=1&itensPorPagina=500");

            var stringResponse = await httpResponse.Content.ReadAsStringAsync();
            Assert.Equal(HttpStatusCode.OK, httpResponse.StatusCode);

            var disco = JsonConvert.DeserializeObject<ConsultaPaginadaViewModel<DiscoViewModel>>(stringResponse);
            Assert.NotNull(disco);
            Assert.NotEmpty(disco.Itens);
            Assert.Equal(DiscoTestSeed.Seeds.Count, disco.Itens.Count);
        }

    }
}
