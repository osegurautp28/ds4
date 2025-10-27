using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laboratorio123
{
    public partial class Form1 : Form

    {
        double ladoA, ladoB, ladoC, Semip, AreaTotal;

        private void btnReset_Click(object sender, EventArgs e)
        {
            Metodos.Reset(txtLadoA, txtLadoB, txtLadoC, txtSemip, txtArea);
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Metodos.CerrarApp();
        }

        public void btnSemiP_Click(object sender, EventArgs e)
        {
            ladoA = double.Parse(txtLadoA.Text);
            ladoB=double.Parse(txtLadoB.Text);
            ladoC=double.Parse(txtLadoC.Text);

            Semip=Metodos.CalcularSemip(ladoA, ladoB, ladoC);
            txtSemip.Text = Semip.ToString();
        }

        private void btnArea_Click(object sender, EventArgs e)
        {
            AreaTotal = Metodos.CalcularArea(ladoA, ladoB, ladoC, Semip);
            txtArea.Text= $"{AreaTotal:F2}";
        }
    }
}
