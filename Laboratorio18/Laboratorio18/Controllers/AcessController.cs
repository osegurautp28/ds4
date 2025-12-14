using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Laboratorio18.Controllers
{
    public class AcessController : Controller
    {
        // GET: Acess
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Enter(String user, string password)
        {
            try
            {
                return Content("1");
            }
            catch (Exception ex)
            {
                return Content("Ocurrio un error :(" + ex.Message);
            }
        }

    }
}