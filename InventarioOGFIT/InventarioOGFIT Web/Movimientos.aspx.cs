using System;
using System.IO;
using System.Net;
using System.Collections.Generic;
using Newtonsoft.Json;
using InventarioOGFITWeb.Models;
using System.Text;

namespace InventarioOGFITWeb
{
    public partial class PaginaMovimientos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarProductosEnCombo();
                CargarStockGrid();
            }

        }
        private void CargarProductosEnCombo()
        {
            string url = "https://localhost:44381/api/productos"; // puerto del API

            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.Accept = "application/json";

            try
            {
                using (var response = (HttpWebResponse)request.GetResponse())
                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    string json = reader.ReadToEnd();

                    var apiResp = JsonConvert.DeserializeObject<ApiResponse<List<ProductoDto>>>(json);

                    if (apiResp != null && apiResp.Result == 1)
                    {
                        ddlProductos.DataSource = apiResp.Data;
                        ddlProductos.DataTextField = "Nombre";      // lo que se ve
                        ddlProductos.DataValueField = "ProductoId"; // el id real
                        ddlProductos.DataBind();

                        lblMsg.Text = "Productos cargados.";
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
        
            protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            // 1) Validaciones simples
            int productoId = int.Parse(ddlProductos.SelectedValue);

            int cantidad;
            if (!int.TryParse(txtCantidad.Text.Trim(), out cantidad) || cantidad <= 0)
            {
                lblMsg.Text = "Cantidad inválida.";
                return;
            }

            string tipo = rblTipo.SelectedValue; // "ENTRADA" o "SALIDA"
            string nota = txtNota.Text.Trim();

            // 2) Armar URL según tipo
            string baseUrl = "https://localhost:44381"; // tu puerto del API
            string endpoint = (tipo == "ENTRADA") ? "/api/stock/entrada" : "/api/stock/salida";
            string url = baseUrl + endpoint;

            // 3) Armar objeto a enviar
            var reqObj = new MovimientoRequest
            {
                ProductoId = productoId,
                Cantidad = cantidad,
                Nota = nota
            };

            // 4) Convertir a JSON
            string jsonBody = Newtonsoft.Json.JsonConvert.SerializeObject(reqObj);

            // 5) Crear request POST
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
            request.ContentType = "application/json";
            request.Accept = "application/json";

            try
            {
                // Enviar body
                using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                {
                    streamWriter.Write(jsonBody);
                }

                // Leer respuesta
                using (var response = (HttpWebResponse)request.GetResponse())
                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    string jsonResp = reader.ReadToEnd();

                    // convertir respuesta a ApiResponse<object>
                    var apiResp = Newtonsoft.Json.JsonConvert.DeserializeObject<ApiResponse<object>>(jsonResp);

                    if (apiResp != null && apiResp.Result == 1)
                    {
                        lblMsg.ForeColor = System.Drawing.Color.Green;
                        lblMsg.Text = apiResp.Message;
                        CargarStockGrid();     // refresca el grid
                        txtCantidad.Text = ""; // limpia campos
                        txtNota.Text = "";
                    }
                    else
                    {
                        lblMsg.ForeColor = System.Drawing.Color.Red;

                        lblMsg.Text = (apiResp != null) ? apiResp.Message : "Respuesta inválida del API.";
                    }
                }
            }
            catch (WebException ex)
            {
                lblMsg.ForeColor = System.Drawing.Color.Red;

                // leer mensaje de error del API (si viene en JSON)
                try
                {
                    using (var errResp = (HttpWebResponse)ex.Response)
                    using (var reader = new StreamReader(errResp.GetResponseStream()))
                    {
                        string errJson = reader.ReadToEnd();
                        lblMsg.Text = errJson;
                    }
                }
                catch
                {
                    lblMsg.Text = "Error al llamar API: " + ex.Message;
                }
            }
        }
        private void CargarStockGrid()
        {
            string url = "https://localhost:44381/api/productos"; // tu puerto

            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.Accept = "application/json";

            try
            {
                using (var response = (HttpWebResponse)request.GetResponse())
                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    string json = reader.ReadToEnd();
                    var apiResp = Newtonsoft.Json.JsonConvert.DeserializeObject<ApiResponse<List<ProductoDto>>>(json);

                    if (apiResp != null && apiResp.Result == 1)
                    {
                        gvStock.DataSource = apiResp.Data;
                        gvStock.DataBind();
                    }
                }
            }
            catch
            {
                // aquí no hace falta spamear errores, ya tienes lblMsg para lo importante
            }
        }

    }

}
