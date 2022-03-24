using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using University.API.Models;

namespace University.Frontend.Data
{
    public class StudentService
    {
        private readonly HttpClient _client;

        public StudentService(HttpClient client)
        {
            _client = client;
        }

        public async Task<List<Student>> GetData()
        {
            HttpResponseMessage res = await _client.GetAsync("api/student");

            if (res.IsSuccessStatusCode)
            {
                return await res.Content.ReadFromJsonAsync<List<Student>>();
            }
            else
            {
                return new List<Student>();
            }
        }

    }
}
