using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parcial2
{
    public partial class Form1 : Form
    {
        
        string connectionString =@"Server=DESKTOP-CSL8HP7\MYSSQLSERVEROS;Database=Operaciones_Parcial2;TrustServerCertificate=True;Integrated Security=SSPI;";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CargarHistorial();
        }

       

        private void InsertarOperacion(string tipo, string entrada, string salida)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(connectionString))
                {
                    conexion.Open();

                    string query = "INSERT INTO HistorialOperaciones (TipoOperacion, ValorEntrada, ValorSalida) VALUES (@tipo, @entrada, @salida)";

                    SqlCommand cmd = new SqlCommand(query, conexion);
                    cmd.Parameters.AddWithValue("@tipo", tipo);
                    cmd.Parameters.AddWithValue("@entrada", entrada);
                    cmd.Parameters.AddWithValue("@salida", salida);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar en la base de datos: " + ex.Message);
            }
        }

        private void CargarHistorial()
        {
            try
            {
                listBox1.Items.Clear();

                using (SqlConnection conexion = new SqlConnection(connectionString))
                {
                    conexion.Open();

                    string query = "SELECT Fecha, TipoOperacion, ValorEntrada, ValorSalida FROM HistorialOperaciones ORDER BY Id DESC";
                    SqlCommand cmd = new SqlCommand(query, conexion);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        string fecha = Convert.ToDateTime(reader["Fecha"]).ToString("yyyy-MM-dd HH:mm");
                        string tipo = reader["TipoOperacion"].ToString();
                        string entrada = reader["ValorEntrada"].ToString();
                        string salida = reader["ValorSalida"].ToString();

                        listBox1.Items.Add($"{fecha} | {tipo} | In: {entrada} → Out: {salida}");
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar historial: " + ex.Message);
            }
        }

        

        private void btnHexaDec_Click(object sender, EventArgs e)
        {
            try
            {
                long resultado = Metodos.HexaDec(txtHex1.Text);
                txtDec1.Text = resultado.ToString();

                InsertarOperacion("Hex→Dec", txtHex1.Text, txtDec1.Text);
                CargarHistorial();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDecHexa_Click(object sender, EventArgs e)
        {
            try
            {
                long numeroDec = Convert.ToInt64(txtDec2.Text);
                string resultado = Metodos.DecHexa(numeroDec);
                txtHex2.Text = resultado;

                InsertarOperacion("Dec→Hex", txtDec2.Text, txtHex2.Text);
                CargarHistorial();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnOctDec_Click(object sender, EventArgs e)
        {
            try
            {
                long resultado = Metodos.OctDec(txtOct1.Text);
                txtDec3.Text = resultado.ToString();

                InsertarOperacion("Oct→Dec", txtOct1.Text, txtDec3.Text);
                CargarHistorial();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDecOct_Click(object sender, EventArgs e)
        {
            try
            {
                long numeroDec = Convert.ToInt64(txtDec4.Text);
                string resultado = Metodos.DecOct(numeroDec);
                txtOct2.Text = resultado;

                InsertarOperacion("Dec→Oct", txtDec4.Text, txtOct2.Text);
                CargarHistorial();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
    

