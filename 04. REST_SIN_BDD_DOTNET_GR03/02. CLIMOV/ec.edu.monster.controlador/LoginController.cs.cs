using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using _02._CLICON.ec.edu.monster.modelo;

namespace _02._CLIMOV.ec.edu.monster.controlador
{
    public class LoginController : IDisposable
    {
        private readonly HttpClient _httpClient;
        private bool _disposed = false;
        private const string LOGIN_URL = "http://192.168.1.15:8093/ec.edu.monster.controlador/ConversionController.svc/login";

        public LoginController()
        {
            _httpClient = new HttpClient();
        }

        /// <summary>
        /// Valida credenciales enviándolas como JSON al servicio REST
        /// </summary>
        /// <param name="usuario">Nombre de usuario</param>
        /// <param name="contrasena">Contraseña</param>
        /// <returns>true si el login fue exitoso</returns>
        public async Task<bool> ValidarLoginAsync(string usuario, string contrasena)
        {
            var user = new Usuario
            {
                usuario = usuario,
                password = contrasena
            };

            try
            {
                var json = JsonSerializer.Serialize(user);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync(LOGIN_URL, content);

                if (!response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"❌ Error HTTP {(int)response.StatusCode}: {response.ReasonPhrase}");
                    return false;
                }

                string result = await response.Content.ReadAsStringAsync();
                return bool.TryParse(result, out bool loginCorrecto) && loginCorrecto;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error de login REST: {ex.Message}");
                return false;
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
