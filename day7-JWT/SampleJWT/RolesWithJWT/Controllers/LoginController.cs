using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace RolesWithJWT.Controllers
{
    public class LoginController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory; // Using a factory instead of new HttpClient() prevents socket exhaustion — the factory reuses connections efficiently.

            public LoginController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Index() => View();

        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            var client = _httpClientFactory.CreateClient(); // Creates a fresh HttpClient from the factory to make HTTP calls to the auth server.

            // Send as query string instead of JSON body
            var url = $"https://localhost:7238/api/Auth/login?username={username}&password={password}";

            var response = await client.PostAsync(url, null); // Sends a POST request to the auth server. null means no request body — everything is in the URL

            //If auth server returns anything other than 200 OK (like 401 Unauthorized),
            //put an error message in ViewBag and return the login form again so the user can retry.
            if (!response.IsSuccessStatusCode)
            {
                ViewBag.Error = "Invalid credentials";
                return View("Index");
            }

            // Reads the raw response body as a string. At this point json looks like {"token":"eyJhbG..."}.
            var json = await response.Content.ReadAsStringAsync();

            var result = JsonSerializer.Deserialize<TokenResponse>(json); // Converts the JSON string into a TokenResponse object so you can access the token as a proper C# property instead of parsing the string manually.

            if (result?.token is null)
            {
                ViewBag.Error = "Token not received";
                return View();
            }
            // Saves the JWT token in server-side session storage with the key "JWT".
            // The browser only gets a session cookie (an ID), never the actual token. This token will be read on every future request by OnMessageReceived.
            HttpContext.Session.SetString("JWT", result.token);
            return RedirectToAction("Index", "Home");   // Login successful — redirect the user to HomeController.Index()
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("JWT"); // remove token
            return RedirectToAction("Index");
        }
    }

    // Matches { token } returned by your auth server
    public record TokenResponse(string token);
}