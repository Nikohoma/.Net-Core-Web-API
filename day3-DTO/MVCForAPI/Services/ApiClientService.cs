using Microsoft.AspNetCore.Mvc;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Text.Json;


namespace MVCForAPI.Services
{
    public class ApiClientService
    {
        private readonly HttpClient _client;
        private static readonly JsonSerializerOptions Opt = new() { PropertyNameCaseInsensitive = true };

        public ApiClientService(HttpClient client)
        {
            _client = client;
            _client.BaseAddress = new Uri("https://localhost:7074/api/");
        }

        public async Task<List<T>?> GetListAsync<T>(string endpoint)    // endpoint = url
        {
            return await _client.GetFromJsonAsync<List<T>>(endpoint,Opt);
        }

    }
}
