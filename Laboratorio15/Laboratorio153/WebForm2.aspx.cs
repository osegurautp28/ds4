using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Laboratorio153
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void BotonSumar_Click(object sender, EventArgs e)
        {
            double num1 = Convert.ToDouble(Numero1.Text);
            double num2 = Convert.ToDouble(Numero2.Text);

            double suma = num1 + num2;
            SumaTotal.Text = $"La suma total es:{suma}";
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}