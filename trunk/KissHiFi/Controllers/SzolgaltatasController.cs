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
    public class SzolgaltatasController : Controller
    {
        private UnitOfWork unitOfWork = new UnitOfWork();
        private KissHifiContext db = new KissHifiContext();

        //
        // GET: /Szolgaltatas/

        public ActionResult Index()
        {
            return View(unitOfWork.SzolgaltatasRepository.Get());
        }

        //
        // GET: /Szolgaltatas/Edit/5

        [Authorize]
        public ActionResult Edit()
        {
            return View(unitOfWork.SzolgaltatasRepository.Get().FirstOrDefault());
        }

        //
        // POST: /Szolgaltatas/Edit/5

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Szolgaltatas szolgaltatas)
        {
            try
            {
                int count = (int) unitOfWork.SzolgaltatasRepository.Get().Count();

                if (count == 0)
                {
                    unitOfWork.SzolgaltatasRepository.Insert(szolgaltatas);
                    unitOfWork.Save();
                }
                {
                    db.Entry(szolgaltatas).State = EntityState.Modified;
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
               
            }
            catch (DataException)
            {
                ModelState.AddModelError(string.Empty, "Nem sikerült az adatok mentése");
            }
            return View(szolgaltatas);
        }

        protected override void Dispose(bool disposing)
        {
            unitOfWork.Dispose();
            base.Dispose(disposing);
        }
    }
}