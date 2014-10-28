using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KissHiFi.Models;
using KissHiFi.DAL;

namespace KissHiFi.Controllers
{
    public class ElerhetosegController : Controller
    {
        private UnitOfWork unitOfWork = new UnitOfWork();
        private KissHifiContext db = new KissHifiContext();

        //
        // GET: /Elerhetoseg/

        public ActionResult Index()
        {
            return View(unitOfWork.ElerhetosegRepository.Get());
        }

        //
        // GET: /Elerhetoseg/Edit/5

        [Authorize]
        public ActionResult Edit()
        {
            return View(unitOfWork.ElerhetosegRepository.Get().FirstOrDefault());
        }

        //
        // POST: /Elerhetoseg/Edit/5

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Elerhetoseg elerhetoseg)
        {
            try
            {
                int count = (int) unitOfWork.ElerhetosegRepository.Get().Count();
                if (count == 0)
                {
                    unitOfWork.ElerhetosegRepository.Insert(elerhetoseg);
                    unitOfWork.Save();
                }
                {
                    db.Entry(elerhetoseg).State = EntityState.Modified;
                    db.SaveChanges();
                }
                
                return RedirectToAction("Index");
            }
            catch (DataException)
            {
                ModelState.AddModelError(string.Empty, "Nem sikerült a mentés.");
            }
            return View(elerhetoseg);
        }

        protected override void Dispose(bool disposing)
        {
            unitOfWork.Dispose();
            base.Dispose(disposing);
        }
    }
}