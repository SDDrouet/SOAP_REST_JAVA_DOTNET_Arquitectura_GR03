using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        private void OnLoginClicked(object sender, EventArgs e)
        {
            ValidarIngreso();
        }

        private void ValidarIngreso()
        {
            if (LoginController.ValidarLogin(entryUsuario.Text, entryContrasena.Text))
            {
                Application.Current.MainPage = new ConversionPage();
            }
            else
            {
                DisplayAlert("Error", "Credenciales inválidas", "OK");
            }
        }
    }
}

