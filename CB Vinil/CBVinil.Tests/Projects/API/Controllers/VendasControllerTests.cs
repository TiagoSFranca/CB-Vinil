using CBVinil.Application.Paginacoes.Models;
using CBVinil.Application.Vendas.Models;
using CBVinil.Tests.Settings.Factories;
using CBVinil.Tests.Settings.Seeds;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CBVinil.Tests.Projects.API.Controllers
{
    public class VendasControllerTests
    {
        private string Url => "/api/Vendas";

        private readonly VendaTestSeed _discoTestSeed;

        public VendasControllerTests()
        {
            _discoTestSeed = new VendaTestSeed();
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public async Task Success_GetVenda(int id)
        {
            HttpClient httpClient = new WebUIFactory(_discoTestSeed).CreateClient();

            var httpResponse = await httpClient.GetAsync(Url + "/" + id.ToString());

            var stringResponse = await httpResponse.Content.ReadAsStringAsync();
            Assert.Equal(HttpStatusCode.OK, httpResponse.StatusCode);
            var disco = JsonConvert.DeserializeObject<VendaViewModel>(stringResponse);
            Assert.Equal(id, disco.IdVenda);
        }

        [Theory]
        [InlineData(32)]
        [InlineData(41)]
        [InlineData(-4)]
        public async Task Error_GetVenda_NotFound(int id)
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

            var disco = JsonConvert.DeserializeObject<ConsultaPaginadaViewModel<VendaViewModel>>(stringResponse);
            Assert.NotNull(disco);
            Assert.NotEmpty(disco.Itens);
            Assert.Equal(VendaTestSeed.Seeds.Count, disco.Itens.Count);
        }

    }
}
