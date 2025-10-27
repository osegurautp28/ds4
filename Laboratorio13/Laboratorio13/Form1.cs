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

namespace Laboratorio13
{
    public partial class Form1 : Form
    { string connectionString= @"Server=DESKTOP-CSL8HP7\MYSSQLSERVEROS;Database=Northwind;TrustServerCertificate=true;Integrated Security=SSPI;";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conexion = new SqlConnection(connectionString);
            conexion.Open();
            MessageBox.Show("Se abrió la conexión con el servidor SQL Server y se seleccionó la base de datos");
            conexion.Close();
            MessageBox.Show("Se cerró la conexión.");
           

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string query = "SELECT ProductName FROM [dbo].[Products]";

            SqlConnection conexion = new SqlConnection(connectionString);
            SqlCommand comando = new SqlCommand(query, conexion);
            conexion.Open();

            SqlDataReader reader = comando.ExecuteReader();

            listBox1.Items.Clear();

            while (reader.Read())
            {
                listBox1.Items.Add(reader["ProductName"].ToString());
            }

            reader.Close();
            conexion.Close();
        }
    }
    
}
