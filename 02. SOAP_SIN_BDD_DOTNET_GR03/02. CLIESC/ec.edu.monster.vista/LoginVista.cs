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
    public partial class LoginVista : Form
    {
        public LoginVista()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnAcceder_Click(object sender, EventArgs e)
        {
            String getUsuario = txtUsuario.Text;
            String getContrasena = txtContrasena.Text;

            if (getUsuario.Equals("MONSTER") && getContrasena.Equals("MONSTER9"))
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
    }
}
