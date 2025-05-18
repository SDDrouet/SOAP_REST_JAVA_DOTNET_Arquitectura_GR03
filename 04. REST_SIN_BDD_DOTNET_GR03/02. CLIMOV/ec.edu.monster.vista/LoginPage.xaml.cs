using System;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;
using _02._CLIMOV.ec.edu.monster.controlador;

namespace _02._CLIMOV.ec.edu.monster.vista
{
    public partial class LoginPage : ContentPage
    {
        private bool mostrarContrasena = false;

        public LoginPage()
        {
            InitializeComponent();
        }

        private void OnTogglePasswordVisibility(object sender, EventArgs e)
        {
            mostrarContrasena = !mostrarContrasena;
            entryContrasena.IsPassword = !mostrarContrasena;
        }

        private async void OnLoginClicked(object sender, EventArgs e)
        {
            await ValidarIngreso();
        }

        private async Task ValidarIngreso()
        {
            // Instancia del controlador (usa IDisposable)
            using var loginController = new LoginController();

            bool loginCorrecto = await loginController.ValidarLoginAsync(entryUsuario.Text, entryContrasena.Text);

            if (loginCorrecto)
            {
                // Navegar a la siguiente página
                Application.Current.MainPage = new ConversionPage();
            }
            else
            {
                await DisplayAlert("Error", "Credenciales inválidas", "OK");
            }
        }
    }
}
