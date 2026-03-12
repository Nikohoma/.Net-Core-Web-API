using System.Collections.Specialized;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;


namespace MVCForAPI.Services
{
    public class ApiClientService
    {
        private readonly HttpClient _client;

        public ApiClientService(HttpClient client)
        {
            _client = client;
        }

        public async Task<List<T>?> GetListAsync<T>(string endpoint)  //endpoint = url
        {
            return await _client.GetFromJsonAsync<List<T>>(endpoint);
        }
    }
}
