using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KissHiFi.Models;
using KissHiFi.DAL;

namespace KissHiFi.Controllers
{
    public class KepekController : Controller
    {
        //
        // GET: /Kepek/

        public ActionResult Index()
        {
            string folder = Server.MapPath("~/Content/Kepek/");
            string filter = "*.jpg";
            string[] files = Directory.GetFiles(folder, filter);
            List<string> fileName = new List<string>();

            foreach (string file in files)
            {
                fileName.Add(Path.GetFileName(file));
            }

            return View(fileName);
        }
    }
}