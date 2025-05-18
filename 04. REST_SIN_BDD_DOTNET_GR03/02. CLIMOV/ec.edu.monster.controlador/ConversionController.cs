using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using _02._CLIMOV.ec.edu.monster.modelo;

namespace _02._CLIMOV.ec.edu.monster.controlador
{
    public class ConversionController : IDisposable
    {
        private readonly HttpClient _httpClient;
        private const string REST_URL = "http://192.168.1.15:8093/ec.edu.monster.controlador/ConversionController.svc/convertir";
        private bool _disposed = false;

        public ConversionController()
        {
            _httpClient = new HttpClient();
        }

        public async Task<Response> ConvertirAsync(Request req)
        {
            try
            {
                var json = JsonSerializer.Serialize(req);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync(REST_URL, content);
                response.EnsureSuccessStatusCode();

                var jsonResponse = await response.Content.ReadAsStringAsync();

                return JsonSerializer.Deserialize<Response>(jsonResponse, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error en conversión REST: {ex.Message}");
                throw;
            }
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
