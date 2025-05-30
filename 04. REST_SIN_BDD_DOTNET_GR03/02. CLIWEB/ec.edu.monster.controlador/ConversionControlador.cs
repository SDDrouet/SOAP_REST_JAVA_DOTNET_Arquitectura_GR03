﻿using _02._CLICON.ec.edu.monster.modelo;
using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

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

        /// <summary>
        /// Consume el servicio RESTful para convertir temperaturas
        /// </summary>
        public async Task<Response> ConvertirAsync(Request request)
        {
            try
            {
                string url = "http://localhost:8093/ec.edu.monster.controlador/ConversionController.svc/convertir";

                var json = JsonSerializer.Serialize(request);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync(url, content);
                response.EnsureSuccessStatusCode();

                string jsonResponse = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<Response>(jsonResponse, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error al consumir el servicio REST: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Realiza login vía REST
        /// </summary>
        public async Task<bool> LoginAsync(Usuario user)
        {
            try
            {
                string url = "http://localhost:8093/ec.edu.monster.controlador/ConversionController.svc/login";

                var json = JsonSerializer.Serialize(user);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync(url, content);

                if (!response.IsSuccessStatusCode)
                    return false;

                string result = await response.Content.ReadAsStringAsync();
                return bool.TryParse(result, out bool loginOk) && loginOk;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error durante el login REST: {ex.Message}");
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
