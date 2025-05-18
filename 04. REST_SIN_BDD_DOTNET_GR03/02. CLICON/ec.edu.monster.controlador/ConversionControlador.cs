using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using _02._CLICON.ec.edu.monster.modelo;

namespace _02._CLICON.ec.edu.monster.controlador
{
    public class ConversionControlador : IDisposable
    {
        private readonly HttpClient _httpClient;
        private bool _disposed = false;

        public ConversionControlador()
        {
            _httpClient = new HttpClient();
        }

        public async Task<Response> ConvertirAsync(Request request)
        {
            var json = JsonSerializer.Serialize(request);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(
                "http://localhost:8093/ec.edu.monster.controlador/ConversionController.svc/convertir", content);

            response.EnsureSuccessStatusCode();

            string jsonResponse = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<Response>(jsonResponse, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
        }

        public async Task<bool> LoginAsync(Usuario user)
        {
            string url = "http://localhost:8093/ec.edu.monster.controlador/ConversionController.svc/login";

            var json = JsonSerializer.Serialize(user);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(url, content);

            if (!response.IsSuccessStatusCode)
                return false;

            string result = await response.Content.ReadAsStringAsync();
            return bool.TryParse(result, out bool loginValido) && loginValido;
        }

        public void Dispose()
        {
            if (!_disposed)
            {
                _httpClient.Dispose();
                _disposed = true;
            }
        }
    }
}
