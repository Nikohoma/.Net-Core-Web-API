using ConsumingAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace ConsumingAPI.Controllers
{
    public class ProductController : Controller
    {
        private static readonly HttpClient _client = new HttpClient();
        private readonly string _baseUrl = "https://dummyjson.com/products";

        public async Task<IActionResult> Index()
        {
            List<Product> products = new List<Product>();

            var response = await _client.GetAsync(_baseUrl);

            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();

                var result = JsonSerializer.Deserialize<ProductResponse>(
                    data,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                if (result != null)
                {
                    products = result.productsList;
                }
            }

            return View(products);
        }
    }
}