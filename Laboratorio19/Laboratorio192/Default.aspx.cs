using System;
using System.IO;
using System.Net;
using System.Web.UI;

namespace Laboratorio192
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetItems();
            }
        }

        private void GetItems()
        {
            var url = "https://localhost:44353/api/values/Get"; // usa tu puerto real

            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "application/json";
            request.Accept = "application/json";

            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    using (Stream strReader = response.GetResponseStream())
                    {
                        if (strReader == null) return;

                        using (StreamReader objReader = new StreamReader(strReader))
                        {
                            string responseBody = objReader.ReadToEnd();

                            
                            Response.Write(responseBody);

                            
                            Console.WriteLine(responseBody);
                        }
                    }
                }
            }
            catch (WebException ex)
            {
                Response.Write("Error al llamar el API");
            }
        }
    }
}
