using Microsoft.AspNetCore.Mvc;
using ProjetoParticipacaoMVC.Models;
using System.Net.Http;
using System.Net.Http.Json;

namespace ProjetoParticipacaoMVC.Controllers
{
    public class ProjetoParticipacaoController : Controller
    {
        private readonly HttpClient _httpClient;

        public ProjetoParticipacaoController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri("http://www.antony.somee.com");
        }

        public async Task<IActionResult> Projeto(int idProjeto)
        {
            var participacoes = await _httpClient.GetFromJsonAsync<List<ProjetoParticipacaoViewModel>>($"ProjetoParticipacao/projeto/{idProjeto}");
            return View(participacoes);
        }

        public async Task<IActionResult> Usuario(int idUsuario)
        {
            var participacoes = await _httpClient.GetFromJsonAsync<List<ProjetoParticipacaoViewModel>>($"ProjetoParticipacao/usuario/{idUsuario}");
            return View("Projeto", participacoes);
        }
    }
}
