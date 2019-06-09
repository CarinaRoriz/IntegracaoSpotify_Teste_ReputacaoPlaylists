using IntegracaoSpotify_Teste_ReputacaoPlaylist.Modelos;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace IntegracaoSpotify_Teste_ReputacaoPlaylist
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public async System.Threading.Tasks.Task AdicionarNotaMenorQue1Async()
        {
            ReputacaoPlaylists reputacaoPlaylists = new ReputacaoPlaylists
            {
                Nota = 0,
                PlaylistId = "834738"
            };

            HttpClient clientToken = new HttpClient();
            HttpResponseMessage respToken = await clientToken.GetAsync($"https://localhost:5001/v1/autorizacao");
            string msgToken = await respToken.Content.ReadAsStringAsync();

            Token token = JsonConvert.DeserializeObject<Token>(msgToken);

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token.AccessToken}");

            var stringContent = new StringContent(JsonConvert.SerializeObject(reputacaoPlaylists), Encoding.UTF8, "application/json");

            HttpResponseMessage resp = await client.PostAsync($"https://localhost:5008/v1/reputacoesplaylists", stringContent);
            string msg = await resp.Content.ReadAsStringAsync();
            
            Assert.AreEqual(msg, "Nota Inválida");
        }

        [TestMethod]
        public async System.Threading.Tasks.Task AdicionarNotaMaiorQue5Async()
        {
            ReputacaoPlaylists reputacaoPlaylists = new ReputacaoPlaylists
            {
                Nota = 10,
                PlaylistId = "834738"
            };

            HttpClient clientToken = new HttpClient();
            HttpResponseMessage respToken = await clientToken.GetAsync($"https://localhost:5001/v1/autorizacao");
            string msgToken = await respToken.Content.ReadAsStringAsync();

            Token token = JsonConvert.DeserializeObject<Token>(msgToken);
            
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token.AccessToken}");

            var stringContent = new StringContent(JsonConvert.SerializeObject(reputacaoPlaylists), Encoding.UTF8, "application/json");

            HttpResponseMessage resp = await client.PostAsync($"https://localhost:5008/v1/reputacoesplaylists", stringContent);
            string msg = await resp.Content.ReadAsStringAsync();

            Assert.AreEqual(msg, "Nota Inválida");
        }
    }
}
