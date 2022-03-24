using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using University.API.Models;

namespace University.Frontend.Data
{
    public class AddressService
    {
        private readonly HttpClient _client;

        public AddressService(HttpClient client)
        {
            _client = client;
        }

        public async Task<List<Address>> GetData()
        {
            HttpResponseMessage res = await _client.GetAsync("api/address");

            if (res.IsSuccessStatusCode)
            {
                return await res.Content.ReadFromJsonAsync<List<Address>>();
            }
            else
            {
                return new List<Address>();
            }
        }

    }
}
