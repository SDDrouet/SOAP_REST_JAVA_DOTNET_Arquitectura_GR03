using _02._CLICON.ec.edu.monster.controlador;
using ConversionSevicio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _02._CLIESC.ec.edu.monster.vista
{
    public partial class ConvertirVista : Form
    {
        public ConvertirVista()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private async void btnConvertir_Click(object sender, EventArgs e)
        {
            double valor;
            if (double.TryParse(txtConvertir.Text, out valor))
            {
                char origen = combOrigen.Text.FirstOrDefault();
                char destino = combDestino.Text.FirstOrDefault();
                ConversionControlador _conversionControlador = new ConversionControlador();
                Request _request = new Request();
                _request.valor = valor;
                _request.origen = origen.ToString();
                _request.destino = destino.ToString();
                Response _response = await _conversionControlador.convertirAsync(_request);
                label3.Text = _response.mensaje.ToString();
            }
            else
            {
                MessageBox.Show("El valor ingresado no es válido. Por favor, ingrese un número válido.");
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
