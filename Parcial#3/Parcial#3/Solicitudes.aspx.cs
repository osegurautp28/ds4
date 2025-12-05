using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Parcial_3
{
    public partial class Solicitudes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            SqlSolicitudes.InsertParameters["PersonaId"].DefaultValue = ddlPersona.SelectedValue;
            SqlSolicitudes.InsertParameters["TipoPasaporteId"].DefaultValue = ddlTipo.SelectedValue;
            SqlSolicitudes.InsertParameters["EstadoSolicitudId"].DefaultValue = ddlEstado.SelectedValue;
            SqlSolicitudes.InsertParameters["Observaciones"].DefaultValue = txtObs.Text;

            SqlSolicitudes.Insert();
        }

    }
}