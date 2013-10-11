using BusRoutesWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BusRoutesWeb.Controllers
{
    public class LocalRoutesController : Controller
    {
        public ActionResult Index()
        {
            var model = new LocalRoutesViewModel();
            return View(model);
        }

        public JsonResult Find()
        {
            throw new NotImplementedException(); 
        }
    }
}
