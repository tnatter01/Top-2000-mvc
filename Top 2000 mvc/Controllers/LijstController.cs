using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using Top_2000_mvc.Models;
using System.Web.Mvc;

namespace Top_2000_mvc.Controllers
{
    public class LijstController : Controller
    {
        private LijstEntities2 db = new LijstEntities2();


        // GET: Lijst
        public ActionResult Index()
        {
            var liedjes = from Lijst in db.Lijst
                          where
                            Lijst.top2000jaar == 2018
                          orderby
                            Lijst.positie
                          select new
                          {
                              Lijst.positie,
                              Lijst.Song.titel,
                              Lijst.Song.Artiest.naam,
                              Lijst.Song.jaar
                          };

            return View(liedjes.ToList());
        }

        // GET: Lijst/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Lijst/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Lijst/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Lijst/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Lijst/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Lijst/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Lijst/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
