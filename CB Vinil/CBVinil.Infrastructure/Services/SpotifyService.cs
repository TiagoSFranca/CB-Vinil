using CBVinil.Application.Exceptions;
using CBVinil.Application.Interfaces;
using CBVinil.Application.Settings.Models;
using CBVinil.Common.Constants;
using CBVinil.Common.Helpers;
using CBVinil.Domain.Entities;
using CBVinil.Infrastructure.Models;
using CBVinil.Persistence;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CBVinil.Infrastructure.Services
{
    public class SpotifyService : ISpotifyService
    {
        private readonly SpotifySettings _spotifySettings;
        private readonly CBVinilContext _context;

        public SpotifyService(CBVinilContext context, IOptions<SpotifySettings> options)
        {
            _context = context;
            _spotifySettings = options.Value;
        }

        public async Task PopularDiscos()
        {
            if (_context.Disco.Any())
                return;

            var discos = await ObterDiscos();
            try
            {
                _context.Disco.AddRange(discos);
                _context.SaveChanges();
            }
            catch (Exception exception)
            {
                throw new PersistenceException(exception);
            }
        }

        private async Task<string> GetToken()
        {
            SpotifyToken token = new SpotifyToken();
            var encoded = Base64Helper.Encode(string.Format("{0}:{1}", _spotifySettings.ClientId, _spotifySettings.ClientSecret));
            string postString = string.Format("grant_type=client_credentials");

            byte[] byteArray = Encoding.UTF8.GetBytes(postString);

            WebRequest request = WebRequest.Create(_spotifySettings.TokenUrl);
            request.Method = "POST";
            request.Headers.Add("Authorization", "Basic " + encoded);
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = byteArray.Length;

            try
            {
                using (Stream dataStream = request.GetRequestStream())
                {
                    dataStream.Write(byteArray, 0, byteArray.Length);
                    using (WebResponse response = await request.GetResponseAsync())
                    {
                        using (Stream responseStream = response.GetResponseStream())
                        {
                            using (StreamReader reader = new StreamReader(responseStream))
                            {
                                string responseFromServer = reader.ReadToEnd();
                                token = JsonConvert.DeserializeObject<SpotifyToken>(responseFromServer);
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
            }

            return token.access_token;
        }

        private async Task<T> GetSpotifyType<T>(string token, string url)
        {
            try
            {
                WebRequest request = WebRequest.Create(url);
                request.Method = "GET";
                request.Headers.Add("Authorization", "Bearer " + token);
                request.ContentType = "application/json; charset=utf-8";
                T type = default(T);

                using (WebResponse response = await request.GetResponseAsync())
                {
                    using (Stream dataStream = response.GetResponseStream())
                    {
                        using (StreamReader reader = new StreamReader(dataStream))
                        {
                            string responseFromServer = reader.ReadToEnd();
                            type = JsonConvert.DeserializeObject<T>(responseFromServer);
                        }
                    }
                }

                return type;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private async Task<List<Disco>> ObterDiscos()
        {
            var token = await GetToken();
            var generos = _context.GeneroMusical.ToList();
            var listaDiscos = new List<Disco>();

            foreach (var genero in generos)
            {
                try
                {
                    var discos = await ObterListaDiscosPorGenero(token, genero, listaDiscos);
                    listaDiscos.AddRange(discos);
                }
                catch (Exception)
                {
                }
            }

            return listaDiscos;
        }

        private async Task<List<Disco>> ObterListaDiscosPorGenero(string token, GeneroMusical genero, List<Disco> listaDiscos)
        {
            int offset = 1;
            var albunsFinal = new List<Album>();
            bool continuar = true;
            while (albunsFinal.Count < SpotifyConstants.MaxAlbuns && continuar)
            {
                var query = string.Format("q=genre%3A{0}&type=track&limit={1}&offset={2}", genero.ArgSpotify.ToLower(), SpotifyConstants.MaxAlbuns, offset);
                var url = _spotifySettings.SearchUrl + query;
                var consultaTrack = await GetSpotifyType<ConsultaTrack>(token, url);

                var albuns = consultaTrack?.tracks?.items?.Select(e => e.album).ToList();
                albuns = albuns.GroupBy(e => e.id).Select(e => e.FirstOrDefault()).ToList();

                var idAlbuns = albuns.Select(e => e.id).Distinct().ToList();

                if (idAlbuns.Count <= 0)
                    continuar = false;

                var idDiscos = listaDiscos.Select(e => e.CodSpotify).Distinct().ToList();

                var idAlbunsFinais = albunsFinal.Select(e => e.id).Distinct().ToList();
                idAlbunsFinais.AddRange(idDiscos);
                idAlbunsFinais = idAlbunsFinais.Distinct().ToList();

                var idsExcept = idAlbuns.Except(idAlbunsFinais).ToList();

                var lista = albuns.Where(e => idsExcept.Contains(e.id)).ToList();

                albunsFinal.AddRange(lista);

                offset += SpotifyConstants.MaxAlbuns;
            }
            var ids = albunsFinal.Select(e => e.id).Distinct().ToList();
            albunsFinal = albunsFinal.Skip(0).Take(SpotifyConstants.MaxAlbuns).ToList();
            var discos = albunsFinal.Select(e => new Disco() { IdGeneroMusical = genero.IdGeneroMusical, Nome = e.name, CodSpotify = e.id, Preco = GerarPrecoRandom(), Artistas = string.Join(",", e.artists.Select(f => f.name).ToList()) }).ToList();

            return discos;
        }

        private decimal GerarPrecoRandom()
        {
            int min = 1;
            int max = 100;
            Random random = new Random();
            var centavos = ((decimal)random.Next(min, max) / max);
            var valor = random.Next(min, max) + centavos;

            return valor;
        }
    }
}
