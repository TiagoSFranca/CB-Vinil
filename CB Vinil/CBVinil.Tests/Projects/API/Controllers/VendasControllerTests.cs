using CBVinil.Application.Paginacoes.Models;
using CBVinil.Application.Vendas.Commands.VenderDiscos;
using CBVinil.Application.Vendas.Models;
using CBVinil.Tests.Settings.Factories;
using CBVinil.Tests.Settings.Seeds;
using Newtonsoft.Json;
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
        private string UrlVenderDiscos => Url + "/Vender";

        private readonly VendaTestSeed _vendaTestSeed;
        private readonly VendaSemCashbackParametroTestSeed _vendaSemCashbackParametroTestSeed;

        public VendasControllerTests()
        {
            _vendaTestSeed = new VendaTestSeed();
            _vendaSemCashbackParametroTestSeed = new VendaSemCashbackParametroTestSeed();
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public async Task Success_GetVenda(int id)
        {
            HttpClient httpClient = new WebUIFactory(_vendaTestSeed).CreateClient();

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
            HttpClient httpClient = new WebUIFactory(_vendaTestSeed).CreateClient();

            var httpResponse = await httpClient.GetAsync(Url + "/" + id.ToString());

            var stringResponse = await httpResponse.Content.ReadAsStringAsync();
            Assert.Equal(HttpStatusCode.NotFound, httpResponse.StatusCode);
        }

        [Theory]
        [InlineData("nada")]
        [InlineData(null)]
        public async Task Success_Search(string nome)
        {
            HttpClient httpClient = new WebUIFactory(_vendaTestSeed).CreateClient();

            var httpResponse = await httpClient.GetAsync(Url + "?nome=" + nome);

            var stringResponse = await httpResponse.Content.ReadAsStringAsync();
            Assert.Equal(HttpStatusCode.OK, httpResponse.StatusCode);
        }

        [Fact]
        public async Task Success_Search_AllItens()
        {
            HttpClient httpClient = new WebUIFactory(_vendaTestSeed).CreateClient();

            var httpResponse = await httpClient.GetAsync(Url + "?pagina=1&itensPorPagina=500");

            var stringResponse = await httpResponse.Content.ReadAsStringAsync();
            Assert.Equal(HttpStatusCode.OK, httpResponse.StatusCode);

            var disco = JsonConvert.DeserializeObject<ConsultaPaginadaViewModel<VendaViewModel>>(stringResponse);
            Assert.NotNull(disco);
            Assert.NotEmpty(disco.Itens);
            Assert.Equal(VendaTestSeed.Seeds.Count, disco.Itens.Count);
        }

        [Fact]
        public async Task Success_Vender()
        {
            HttpClient httpClient = new WebUIFactory(_vendaTestSeed).CreateClient();
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

            var commandSerialized = JsonConvert.SerializeObject(command);
            var content = new StringContent(commandSerialized, Encoding.UTF8, "application/json");

            var httpResponse = await httpClient.PostAsync(UrlVenderDiscos, content);

            var stringResponse = await httpResponse.Content.ReadAsStringAsync();

            Assert.Equal(HttpStatusCode.OK, httpResponse.StatusCode);
        }

        [Fact]
        public async Task Error_VenderDiscos_BusinessException()
        {
            HttpClient httpClient = new WebUIFactory(_vendaSemCashbackParametroTestSeed).CreateClient();

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

            var commandSerialized = JsonConvert.SerializeObject(command);
            var content = new StringContent(commandSerialized, Encoding.UTF8, "application/json");

            var httpResponse = await httpClient.PostAsync(UrlVenderDiscos, content);

            var stringResponse = await httpResponse.Content.ReadAsStringAsync();

            Assert.Equal(HttpStatusCode.BadRequest, httpResponse.StatusCode);
        }

        [Fact]
        public async Task Error_VenderDiscos_NotFound()
        {
            HttpClient httpClient = new WebUIFactory(_vendaTestSeed).CreateClient();

            var command = new VenderDiscosCommand()
            {
                Discos = new List<VenderDiscoViewModel>()
                {
                    new VenderDiscoViewModel()
                    {
                        IdDisco = 19,
                        Quantidade = 4
                    }
                }
            };

            var commandSerialized = JsonConvert.SerializeObject(command);
            var content = new StringContent(commandSerialized, Encoding.UTF8, "application/json");

            var httpResponse = await httpClient.PostAsync(UrlVenderDiscos, content);

            var stringResponse = await httpResponse.Content.ReadAsStringAsync();

            Assert.Equal(HttpStatusCode.NotFound, httpResponse.StatusCode);
        }

        [Fact]
        public async Task Error_VenderDiscos_ValidationException()
        {
            HttpClient httpClient = new WebUIFactory(_vendaTestSeed).CreateClient();

            var command = new VenderDiscosCommand()
            {
            };

            var commandSerialized = JsonConvert.SerializeObject(command);
            var content = new StringContent(commandSerialized, Encoding.UTF8, "application/json");

            var httpResponse = await httpClient.PostAsync(UrlVenderDiscos, content);

            var stringResponse = await httpResponse.Content.ReadAsStringAsync();

            Assert.Equal(HttpStatusCode.BadRequest, httpResponse.StatusCode);
        }
    }
}
