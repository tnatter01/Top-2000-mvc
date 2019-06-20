﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Top_2000_mvc.Models;

namespace Top_2000_mvc.Controllers
{
    public class SongsController : Controller
    {
        private LijstEntities2 db = new LijstEntities2();

        // GET: Songs
        public ActionResult Index()
        {
            var song = db.Song.Include(s => s.Artiest);
            return View(song.ToList());
        }

        public ActionResult Average([DefaultValue(4671)]int SongId)
        {
            //Connectie maken met de lokale sql server database
            String constring = "Server=localhost;Database=TOP2000;Integrated Security=SSPI";
            SqlConnection sqlcon = new SqlConnection(constring);
            //Selecteer welke stored procedure gebruikt moet worden
            String pname = "spAvgPositiePerSong";
            //Open connectie met sql server database
            sqlcon.Open();
            SqlCommand com = new SqlCommand(pname, sqlcon);
            //Zeg dat het uitgevoerd moet worden als stored procedure
            com.CommandType = CommandType.StoredProcedure;
            //Voeg parameters toe aan de stored procedure
            com.Parameters.Add(new SqlParameter("@SongId", SongId));
            //Voer stored procedure uit, en lees resultaten uit
            SqlDataReader dr = com.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            //Stuur de resultaten terug in een datatable naar een view
            return View(dt);
        }

        public ActionResult Positie([DefaultValue(8357)]int SongId)
        {
            //Connectie maken met de lokale sql server database
            String constring = "Server=localhost;Database=TOP2000;Integrated Security=SSPI";
            SqlConnection sqlcon = new SqlConnection(constring);
            //Selecteer welke stored procedure gebruikt moet worden
            String pname = "spPlaatsPerJaar";
            //Open connectie met sql server database
            sqlcon.Open();
            SqlCommand com = new SqlCommand(pname, sqlcon);
            //Zeg dat het uitgevoerd moet worden als stored procedure
            com.CommandType = CommandType.StoredProcedure;
            //Voeg parameters toe aan de stored procedure
            com.Parameters.Add(new SqlParameter("@SongId", SongId));
            SqlDataReader dr = com.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            //Stuur de resultaten terug in een datatable naar een view
            return View(dt); 
        }
        // GET: Songs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Song song = db.Song.Find(id);
            if (song == null)
            {
                return HttpNotFound();
            }
            return View(song);
        }

        // GET: Songs/Create
        public ActionResult Create()
        {
            ViewBag.artiestid = new SelectList(db.Artiest, "artiestid", "naam");
            return View();
        }

        // POST: Songs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "songid,artiestid,titel,jaar")] Song song)
        {
            if (ModelState.IsValid)
            {
                db.Song.Add(song);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.artiestid = new SelectList(db.Artiest, "artiestid", "naam", song.artiestid);
            return View(song);
        }

        // GET: Songs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Song song = db.Song.Find(id);
            if (song == null)
            {
                return HttpNotFound();
            }
            ViewBag.artiestid = new SelectList(db.Artiest, "artiestid", "naam", song.artiestid);
            return View(song);
        }

        // POST: Songs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "songid,artiestid,titel,jaar")] Song song)
        {
            if (ModelState.IsValid)
            {
                db.Entry(song).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.artiestid = new SelectList(db.Artiest, "artiestid", "naam", song.artiestid);
            return View(song);
        }

        // GET: Songs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Song song = db.Song.Find(id);
            if (song == null)
            {
                return HttpNotFound();
            }
            return View(song);
        }

        // POST: Songs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Song song = db.Song.Find(id);
            db.Song.Remove(song);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
