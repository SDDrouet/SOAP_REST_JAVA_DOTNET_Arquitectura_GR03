using _02._CLICON.ec.edu.monster.controlador;
using _02._CLICON.ec.edu.monster.modelo;
using System;
using System.Windows.Forms;

namespace _02._CLIESC.ec.edu.monster.vista
{
    public partial class LoginVista : Form
    {
        private readonly ConversionControlador _controlador;

        public LoginVista()
        {
            InitializeComponent();
            _controlador = new ConversionControlador();
        }

        private async void btnAcceder_Click(object sender, EventArgs e)
        {
            string getUsuario = txtUsuario.Text.Trim();
            string getContrasena = txtContrasena.Text;

            if (string.IsNullOrWhiteSpace(getUsuario) || string.IsNullOrWhiteSpace(getContrasena))
            {
                MessageBox.Show("Por favor, complete ambos campos.");
                return;
            }

            try
            {
                Usuario user = new Usuario
                {
                    usuario = getUsuario,
                    password = getContrasena
                };

                bool loginCorrecto = await _controlador.LoginAsync(user);

                if (loginCorrecto)
                {
                    ConvertirVista convertirVista = new ConvertirVista();
                    convertirVista.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Usuario o contraseña incorrectos");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error durante el login:\n" + ex.Message);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // Acción si se hace clic en la imagen
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            _controlador.Dispose();
            base.OnFormClosed(e);
        }
    }
}
