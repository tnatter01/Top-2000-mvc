using System.Linq;
using Top_2000_mvc.Models;
using System.Web.Mvc;
using System.Data;
using System;
using System.Data.SqlClient;
using System.ComponentModel;

namespace Top_2000_mvc.Controllers
{
    public class LijstController : Controller
    {
        private LijstEntities2 db = new LijstEntities2();


        // GET: Lijst
        public ActionResult Index([DefaultValue(2018)]int jaar)
        {
            String constring = "Server=localhost;Database=TOP2000;Integrated Security=SSPI";
            SqlConnection sqlcon = new SqlConnection(constring);
            String pname = "spGetListByYear";
            sqlcon.Open();
            SqlCommand com = new SqlCommand(pname, sqlcon);
            com.CommandType = CommandType.StoredProcedure;
            if(jaar == 2018) { 
            com.Parameters.Add(
            new SqlParameter("@YEAR", 2018));
            } else
            {
                com.Parameters.Add(
                            new SqlParameter("@YEAR", 2018));
            }
            SqlDataReader dr = com.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            return View(dt);
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
