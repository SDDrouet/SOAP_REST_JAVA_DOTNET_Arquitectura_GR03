using System;
using Microsoft.Maui.Controls;
using _02._CLIMOV.ec.edu.monster.controlador;
using _02._CLIMOV.ec.edu.monster.modelo;

namespace _02._CLIMOV.ec.edu.monster.vista
{
    public partial class ConversionPage : ContentPage
    {
        public ConversionPage()
        {
            InitializeComponent();
        }

        private async void OnConvertirClicked(object sender, EventArgs e)
        {
            try
            {
                string input = entryValor.Text?.Trim();

                if (!string.IsNullOrWhiteSpace(input) &&
                    input.Length <= 11 &&
                    double.TryParse(input, out double valor) &&
                    pickerOrigen.SelectedItem != null &&
                    pickerDestino.SelectedItem != null)
                {
                    string unidadOrigen = pickerOrigen.SelectedItem.ToString();
                    string unidadDestino = pickerDestino.SelectedItem.ToString();

                    if (unidadOrigen == unidadDestino)
                    {
                        lblResultado.Text = $"ℹ️ No se requiere conversión:\n\n" +
                                            $"{valor} {unidadOrigen} equivale a {valor} {unidadDestino}.";
                        return;
                    }

                    var request = new Request
                    {
                        valor = valor,
                        origen = ObtenerCodigoUnidad(unidadOrigen),
                        destino = ObtenerCodigoUnidad(unidadDestino)
                    };

                    using var controller = new ConversionController();
                    var response = await controller.ConvertirAsync(request);

                    lblResultado.Text = $"💡 Resultado:\n\n" +
                                        $"{valor} {unidadOrigen} = {response.valorConvertido} {unidadDestino}\n\n" +
                                        $"📝 {valor} {request.origen} son {response.valorConvertido} {request.destino}";
                }
                else
                {
                    await DisplayAlert("Error", "Completa todos los campos correctamente. Asegúrate de ingresar un número válido con máximo 10 caracteres.", "OK");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Sin conexión", "No se pudo conectar al servidor. Verifica tu conexión a internet o intenta más tarde.", "OK");
                lblResultado.Text = $"⚠️ Error de conexión:\n{ex.Message}";
            }
        }

        private void OnSalirClicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new LoginPage();
        }

        private string ObtenerCodigoUnidad(string unidadCompleta)
        {
            if (unidadCompleta.Contains("Celsius")) return "C";
            if (unidadCompleta.Contains("Fahrenheit")) return "F";
            if (unidadCompleta.Contains("Kelvin")) return "K";
            return "";
        }
    }
}
