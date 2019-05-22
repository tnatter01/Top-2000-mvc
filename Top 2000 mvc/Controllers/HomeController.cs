using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using Top_2000_mvc.Models;

namespace Top_2000_mvc.Controllers

{

    public class HomeController : Controller

    {

        private Top2000Entities _db = new Top2000Entities();

        public ActionResult Index()

        {

            return View(_db.Table.ToList());

        }


    //

        // GET: /Home/Create 

        public ActionResult Create()

        {

            return View();

        }

        //

        // POST: /Home/Create 

        [AcceptVerbs(HttpVerbs.Post)]

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


        // GET: /Movies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Liedje liedje = _db.Table.Find(id);
            if (liedje == null)
            {
                return HttpNotFound();
            }
            return View(liedje);
        }

        // POST: /Movies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Titel,Artiest,Jaar,Plaats")] Liedje liedje)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(liedje).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(liedje);
        }
    }
}