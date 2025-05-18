using _02._CLICON.ec.edu.monster.controlador;
using _02._CLICON.ec.edu.monster.modelo;
using System;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;

namespace _02._CLIESC.ec.edu.monster.vista
{
    public partial class ConvertirVista : Form
    {
        private readonly ConversionControlador _controlador;

        public ConvertirVista()
        {
            InitializeComponent();
            _controlador = new ConversionControlador();
        }

        private async void btnConvertir_Click(object sender, EventArgs e)
        {
            if (double.TryParse(txtConvertir.Text, out double valor))
            {
                string origen = combOrigen.Text;
                string destino = combDestino.Text;

                Request request = new Request
                {
                    valor = valor,
                    origen = origen.Substring(0, 1).ToUpper(),   // Por ejemplo "Celsius" → "C"
                    destino = destino.Substring(0, 1).ToUpper()
                };

                try
                {
                    Response response = await _controlador.ConvertirAsync(request);
                    label3.Text = $"{valor}° {origen} = {response.valorConvertido}° {destino}";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error en la conversión: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Ingrese un número válido.");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // Vacío si no se necesita
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            // Vacío si no haces gráficos personalizados
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            _controlador.Dispose();
            base.OnFormClosed(e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var confirmar = MessageBox.Show("¿Deseas salir y regresar al inicio de sesión?", "Confirmar salida", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmar == DialogResult.Yes)
            {
                this.Hide();
                LoginVista login = new LoginVista();
                login.Show();
            }
        }

    }
}
