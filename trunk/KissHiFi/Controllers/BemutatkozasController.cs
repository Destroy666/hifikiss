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
    public class BemutatkozasController : Controller
    {
        private UnitOfWork unitOfWork = new UnitOfWork();
        private KissHifiContext db = new KissHifiContext();

        //
        // GET: /Bemutatkozas/

        public ActionResult Index()
        {
            return View(unitOfWork.BemutatkozasRepository.Get());
        }

        //
        // GET: /Bemutatkozas/Edit/5

        [Authorize]
        public ActionResult Edit()
        {
            return View(unitOfWork.BemutatkozasRepository.Get().FirstOrDefault());
        }

        //
        // POST: /Bemutatkozas/Edit/5

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Bemutatkozas bemutatkozas)
        {
            try
            {
                int count = (int) unitOfWork.BemutatkozasRepository.Get().Count();

                if (count == 0)
                {
                    unitOfWork.BemutatkozasRepository.Insert(bemutatkozas);
                    unitOfWork.Save();
                }
                else
                {
                    //unitOfWork.BemutatkozasRepository.Update(bemutatkozas);
                    db.Entry(bemutatkozas).State = EntityState.Modified;
                    db.SaveChanges();
                }
                return RedirectToAction("Index");

            }
            catch (DataException)
            {
                ModelState.AddModelError(string.Empty,"Nem sikerült az adatok mentése.");
            }
            return View(bemutatkozas);
        }

        protected override void Dispose(bool disposing)
        {
            unitOfWork.Dispose();
            base.Dispose(disposing);
        }
    }
}