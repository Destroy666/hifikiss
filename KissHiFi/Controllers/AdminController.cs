using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KissHiFi.Code;
using KissHiFi.DAL;
using KissHiFi.Models;

namespace KissHiFi.Controllers
{
    public class AdminController : Controller
    {
        UnitOfWork unitOfWork = new UnitOfWork();
        RouteName script = new RouteName();

        //
        // GET: /Admin/

        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult Hirek()
        {
            return RedirectToAction("AdminIndex", "Hirek");
        }

        [Authorize]
        public ActionResult Bemutatkozas()
        {
            return RedirectToAction("Edit", "Bemutatkozas");
        }

        [Authorize]
        public ActionResult Szolgaltatas()
        {
            return RedirectToAction("Edit", "Szolgaltatas");
        }

        [Authorize]
        public ActionResult Termek()
        {
            return
                View(
                    unitOfWork.TermekAdatlapRepository.Get(null, q => q.OrderBy(k => k.TermekKategoria.Nev))
                              .OrderBy(m => m.TermekMarka.Nev)
                              .ThenBy(a => a.Tipus));
        }

        [Authorize]
        public ActionResult TermekUj()
        {
            ViewBag.Kategoria = KategoriaList();
            ViewBag.Marka = MarkaList();

            return View();
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TermekUj(TermekAdatlap model, HttpPostedFileBase file)
        {
            try
            {
                model.RouteNev = script.RouteNev(model.Tipus);

                if (file != null && file.ContentLength > 0 && file.ContentType == "image/jpg" || file.ContentType == "image/jpeg")
                {
                    string fileName = script.FileNev(Path.GetFileName(file.FileName));
                    var path = Path.Combine(Server.MapPath("~/Content/Termekek"), fileName);
                    file.SaveAs(path);

                    model.Kep = fileName;

                    unitOfWork.TermekAdatlapRepository.Insert(model);
                    unitOfWork.Save();

                    return RedirectToAction("Termek");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError(string.Empty,"Nem sikerült a mentés");
            }
            return View(model);
        }

        [Authorize]
        public ActionResult TermekEdit(string id)
        {
            ViewBag.Kategoria = KategoriaList();
            ViewBag.Marka = MarkaList();

            return View(unitOfWork.TermekAdatlapRepository.Get(x => x.RouteNev == id).FirstOrDefault());
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TermekEdit(TermekAdatlap model)
        {
            try
            {
                model.TermekKategoriaId = Convert.ToInt32(model.TermekKategoriaId);
                model.TermekMarkaId = Convert.ToInt32(model.TermekMarkaId);

                if (ModelState.IsValid)
                {
                    unitOfWork.TermekAdatlapRepository.Update(model);
                    unitOfWork.Save();

                    return RedirectToAction("Termek");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError(string.Empty, "Nem sikerült a mentés");
            }
            return View(model);
        }

        [Authorize]
        public ActionResult Elerhetoseg()
        {
            return RedirectToAction("Edit", "Elerhetoseg");
        }

        [Authorize]
        [HttpPost]
        public ActionResult CreateKategoria(TermekKategoria model, HttpPostedFileBase file, bool uj)
        {
            try
            {
                if (file != null && file.ContentLength > 0 && (file.ContentType == "image/jpg" || file.ContentType == "image/jpeg"))
                {
                    string fileName = script.FileNev(Path.GetFileName(file.FileName));
                    var path = Path.Combine(Server.MapPath("~/Content/Termekek/Kategoria"), fileName);
                    file.SaveAs(path);

                    model.Kep = fileName;

                    model.RouteNev = script.RouteNev(model.Nev);
                    unitOfWork.TermekKategoriaRepository.Insert(model);
                    unitOfWork.Save();

                    if (uj)
                    {
                        return RedirectToAction("TermekUj");
                    }
                    {
                        return RedirectToAction("TermekEdit");
                    }
                }
                ModelState.AddModelError(string.Empty,"Nem sikrült a mentés.\nCsak JPG és JPEG fájokat fogad el az oldal.");
                if (uj)
                {
                    return RedirectToAction("TermekUj");
                }
                {
                    return RedirectToAction("TermekEdit");
                }
            }
            catch
            {
                ModelState.AddModelError(string.Empty, "Nem sikrült a mentés.");
                if (uj)
                {
                    return RedirectToAction("TermekUj");
                }
                {
                    return RedirectToAction("TermekEdit");
                }
            }
        }

        [Authorize]
        public ActionResult CreateMarka(TermekMarka model, HttpPostedFileBase file, bool uj)
        {
            try
            {
                if (file != null && file.ContentLength > 0 && (file.ContentType == "image/jpg" || file.ContentType == "image/jpeg"))
                {
                    string fileName = script.FileNev(Path.GetFileName(file.FileName));
                    var path = Path.Combine(Server.MapPath("~/Content/Termekek/Marka"), fileName);
                    file.SaveAs(path);

                    model.Kep = fileName;

                    model.RouteNev = script.RouteNev(model.Nev);
                    unitOfWork.TermekMarkaRepository.Insert(model);
                    unitOfWork.Save();

                    if (uj)
                    {
                        return RedirectToAction("TermekUj");
                    }
                    {
                        return RedirectToAction("TermekEdit");
                    }
                }
                ModelState.AddModelError(string.Empty, "Nem sikrült a mentés.\nCsak JPG és JPEG fájokat fogad el az oldal.");
                if (uj)
                {
                    return RedirectToAction("TermekUj");
                }
                {
                    return RedirectToAction("TermekEdit");
                }
            }
            catch
            {
                ModelState.AddModelError(string.Empty, "Nem sikrült a mentés.");
                if (uj)
                {
                    return RedirectToAction("TermekUj");
                }
                {
                    return RedirectToAction("TermekEdit");
                }
            }
        }

        [Authorize]
        public ActionResult Kepek()
        {
            return View();
        }

        [Authorize]
        public ActionResult SaveUploadedFile()
        {
            foreach (string fileName in Request.Files)
            {
                HttpPostedFileBase file = Request.Files[fileName];

                if (file.ContentLength > 0 && (file.ContentType == "image/jpg" || file.ContentType == "image/jpeg"))
                {
                    var fName = Path.GetFileName(file.FileName);
                    var path = Path.Combine(Server.MapPath("~/Content/Kepek"), fName);
                    file.SaveAs(path);
                }
            }
            return RedirectToAction("Kepek");
        }

        [Authorize]
        [HttpPost]
        public ActionResult Kepek(IEnumerable<HttpPostedFileBase> files)
        {
            foreach (var file in files)
            {
                if (file.ContentLength > 0 && (file.ContentType == "image/jpg" || file.ContentType == "image/jpeg"))
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var path = Path.Combine(Server.MapPath("~/Content/Kepek"), fileName);
                    file.SaveAs(path);
                }
            }
            return View();
        }

        [Authorize]
        private IOrderedEnumerable<SelectListItem> KategoriaList()
        {
            var kat = (from k in unitOfWork.TermekKategoriaRepository.Get()
                       select k).AsEnumerable().Select(x => new SelectListItem
                           {
                               Text = x.Nev,
                               Value = Convert.ToString(x.Id)
                           }).OrderBy(x => x.Text);
            return kat;
        }

        [Authorize]
        private IOrderedEnumerable<SelectListItem> MarkaList()
        {
            var marka = (from m in unitOfWork.TermekMarkaRepository.Get()
                         select m).AsEnumerable().Select(x => new SelectListItem
                             {
                                 Text = x.Nev,
                                 Value = Convert.ToString(x.Id)
                             }).OrderBy(x => x.Text);
            return marka;
        }
    }
}
