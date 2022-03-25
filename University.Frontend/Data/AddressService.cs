using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using University.API.Models;
using University.API.Controllers;

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

        public async Task<Address> GetDataById(int id)
        {
            HttpResponseMessage res = await _client.GetAsync($"api/address/{id}");

            if (res.IsSuccessStatusCode)
            {
                return await res.Content.ReadFromJsonAsync<Address>();
            }
            else
            {
                return new Address();
            }
        }

        public async Task<List<Address>> PostData(Address obj)
        {
            HttpResponseMessage res = await _client.PostAsJsonAsync("api/address", obj);
            
            if (res.IsSuccessStatusCode)
            {
                return await res.Content.ReadFromJsonAsync<List<Address>>();
            }
            else
            {
                return new List<Address>();
            }
        }

        public async Task<List<Address>> PutData(Address obj)
        {
            HttpResponseMessage res = await _client.PutAsJsonAsync("api/address", obj);
            
            if (res.IsSuccessStatusCode)
            {
                return await res.Content.ReadFromJsonAsync<List<Address>>();
            }
            else
            {
                return new List<Address>();
            }
        }

        public async Task<List<Address>> DeleteData(int id)
        {
            HttpResponseMessage res = await _client.DeleteAsync($"api/address/{id}");
            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine(res.StatusCode);
            Console.WriteLine("-------------------------------------------------------------");
            
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
