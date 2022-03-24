using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using University.API.Models;

namespace University.Frontend.Data
{
    public class ProfessorService
    {
        private readonly HttpClient _client;

        public ProfessorService(HttpClient client)
        {
            _client = client;
        }

        public async Task<List<Professor>> GetData()
        {
            HttpResponseMessage res = await _client.GetAsync("api/professor");

            if (res.IsSuccessStatusCode)
            {
                return await res.Content.ReadFromJsonAsync<List<Professor>>();
            }
            else
            {
                return new List<Professor>();
            }
        }

    }
}
