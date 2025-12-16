using InventarioOGFITWeb;
using InventarioOGFITWeb.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InventarioOGFITWeb
{
    public partial class Productos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarProductos();
            }

        }
        private void CargarProductos()
        {
            string url = "https://localhost:44381/api/productos"; // cambia el puerto si es necesario

            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.Accept = "application/json";

            try
            {
                using (var response = (HttpWebResponse)request.GetResponse())
                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    string json = reader.ReadToEnd();

                    // Convertir JSON a objeto
                    var apiResp = JsonConvert.DeserializeObject<ApiResponse<List<ProductoDto>>>(json);

                    if (apiResp != null && apiResp.Result == 1)
                    {
                        gvProductos.DataSource = apiResp.Data;
                        gvProductos.DataBind();
                        lblMsg.Text = apiResp.Message;
                    }
                    else
                    {
                        lblMsg.Text = "No se pudieron cargar productos.";
                    }
                }
            }
            catch (WebException ex)
            {
                lblMsg.Text = "Error al llamar API: " + ex.Message;
            }
        }
    }
}



