using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laboratorio122
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnPromedio_Click(object sender, EventArgs e)
        {
            double nota1 = double.Parse(txtNota1.Text);
            double nota2 = double.Parse(txtNota2.Text);
            double nota3=double.Parse(txtNota3.Text);

            double promedio = Metodos.CalcularProm(nota1, nota2, nota3);
            txtProm.Text = promedio.ToString();


        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Metodos.LimpiarCelda(txtNota1, txtNota2, txtNota3, txtProm);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Metodos.CerrarApp();
        }
    }
}
