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
    public class HirekController : Controller
    {
        private IHirekRepository hirekRepository;
        UnitOfWork unitOfWork = new UnitOfWork();

        public HirekController()
        {
            this.hirekRepository = new HirekRepository(new KissHifiContext());
        }

        public HirekController(IHirekRepository hirekRepository)
        {
            this.hirekRepository = hirekRepository;
        }

        //
        // GET: /Hirek/

        public ActionResult Index()
        {
            return View(hirekRepository.GetHirek().OrderByDescending(x=>x.Datum));
        }

        //
        // GET: /Hirek/Create

        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Hirek/Create

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Hirek hirek)
        {
            try
            {
                hirek.Datum = DateTime.UtcNow.AddHours(1);

                unitOfWork.HirekRepository.Insert(hirek);
                unitOfWork.Save();
                return RedirectToAction("Index");
            }
            catch (DataException)
            {
                ModelState.AddModelError(string.Empty,
                                         "Nem sikerült a mentés. Próbáld meg ismét elküdeni az adatokat.\nHa a hiba továbbra is fenáll, vedd fel a kapcsolatot a rendszergazdával.");
            }
            return View(hirek);
        }

        //
        // GET: /Hirek/Edit/5

        [Authorize]
        public ActionResult Edit(int id = 0)
        {
            Hirek hirek = hirekRepository.GetHirById(id);
            if (hirek == null)
            {
                return HttpNotFound();
            }
            return View(hirek);
        }

        //
        // POST: /Hirek/Edit/5

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Hirek hirek)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    hirekRepository.UpdateHir(hirek);
                    hirekRepository.Save();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError(string.Empty, "Nem sikerült a mentés. Próbáld meg ismét elküdeni az adatokat.\nHa a hiba továbbra is fenáll, vedd fel a kapcsolatot a rendszergazdával.");
            }
            return View(hirek);
        }

        //
        // GET: /Hirek/Delete/5

        [Authorize]
        public ActionResult Delete(bool? saveChangesError = false, int id = 0)
        {
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "A törlés nem sikerült.";
            }

            Hirek hirek = hirekRepository.GetHirById(id);
            if (hirek == null)
            {
                return HttpNotFound();
            }
            return View(hirek);
        }

        //
        // POST: /Hirek/Delete/5

        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                Hirek hirek = hirekRepository.GetHirById(id);
                hirekRepository.DeleteHir(id);
                hirekRepository.Save();
            }
            catch (DataException)
            {
                return RedirectToAction("Delete", new {id = id});
            }
            return RedirectToAction("Index");
        }

        [Authorize]
        public ActionResult AdminIndex()
        {
            return View(hirekRepository.GetHirek().OrderByDescending(x => x.Datum));
        }

        protected override void Dispose(bool disposing)
        {
            hirekRepository.Dispose();
            base.Dispose(disposing);
        }
    }
}