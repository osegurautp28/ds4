using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laboratorio12
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, EventArgs e)
        {
            Metodos.CerrarApp();
        }

        private void btnCalcular_Click(object sender, EventArgs e)

        {
            
            double distanciatotal = Metodos.CalcularDistancia(txtVelocidad.Text, txtTiempo.Text);
            txtDistancia.Text = distanciatotal.ToString();
        }

        private void txtVelocidad_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Metodos.LimpiarTxt(txtVelocidad,txtTiempo,txtDistancia);
        }
    }
}
