using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AttributeRouting.Web.Mvc;
using KissHiFi.DAL;
using KissHiFi.ViewModel;

namespace KissHiFi.Controllers
{
    public class TermekekController : Controller
    {
        private UnitOfWork unitOfWork = new UnitOfWork();

        //
        // GET: /Termekek/

        public ActionResult Index()
        {
            return View(unitOfWork.TermekAdatlapRepository.Get().OrderBy(x => x.TermekKategoria.Nev));
        }

        [GET("Termekek/{kategoria}/{marka}/{termek}")]
        public ActionResult Adatlap(string kategoria, string marka, string termek)
        {
            return View(unitOfWork.TermekAdatlapRepository.Get(x => x.RouteNev == termek).FirstOrDefault());
        }

        [GET("Termekek/{kategoria}/{marka}")]
        public ActionResult IndexByMarka(string kategoria, string marka)
        {
            ViewBag.Kategoria = kategoria;
            ViewBag.Marka = marka;

            ViewBag.aktKategoria =
                unitOfWork.TermekKategoriaRepository.Get(x => x.RouteNev == kategoria)
                          .Select(x => x.Nev)
                          .FirstOrDefault();

            ViewBag.aktMarka =
                unitOfWork.TermekMarkaRepository.Get(x => x.RouteNev == marka).Select(x => x.Nev).FirstOrDefault();

            return
                View(
                    unitOfWork.TermekAdatlapRepository.Get(x => x.TermekKategoria.RouteNev == kategoria)
                              .Where(x => x.TermekMarka.RouteNev == marka));
        }

        [GET("Termekek/{kategoria}")]
        public ActionResult IndexByCategory(string kategoria)
        {
            ViewBag.Kategoria = kategoria;

            ViewBag.aktKategoria =
                unitOfWork.TermekKategoriaRepository.Get(x => x.RouteNev == kategoria)
                          .Select(x => x.Nev)
                          .FirstOrDefault();

            var marka =
                unitOfWork.TermekAdatlapRepository.Get(x => x.TermekKategoria.RouteNev == kategoria);

            return View(marka);
        }
    }
}
