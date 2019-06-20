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
        public ActionResult Index([DefaultValue(2018)]int jaar, [DefaultValue("NULL")]string ZoekString)
        {
            //Connectie maken met de lokale sql server database
            String constring = "Server=localhost;Database=TOP2000;Integrated Security=SSPI";
            SqlConnection sqlcon = new SqlConnection(constring);
            //Selecteer welke stored procedure er uitgevoerd moet worden
            String pname = "spGetListByYear";
            //Als er een zoekstring is ingevuld gebruik de stored procedure waarmee gezocht kan worden
            if(ZoekString != "NULL")
            { pname = "spSearchListByYear"; }
            //Open de sql connectie
            sqlcon.Open();
            SqlCommand com = new SqlCommand(pname, sqlcon);
            //Als er een zoekstring is ingevuld voeg deze als parameter toe aan de stored procedure
            if (ZoekString != "NULL")
            {
                com.Parameters.Add("@ZOEKOPDRACHT", ZoekString);
            }
            com.CommandType = CommandType.StoredProcedure;
            //Als jaar niet gelijk is aan 2018 voeg het jaar toe als parameter aan de stored procedure
            if(jaar != 2018) 
            {
                com.Parameters.Add(
                            new SqlParameter("@YEAR", jaar));
            }
            //Voer de stored procedure uit in de database
            SqlDataReader dr = com.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            //Stuur de resultaten terug in een datatable naar een view
            return View(dt);
        }

        public ActionResult top10([DefaultValue(2018)]int jaar)
        {
            //Connectie maken met de lokale sql server database
            String constring = "Server=localhost;Database=TOP2000;Integrated Security=SSPI";
            SqlConnection sqlcon = new SqlConnection(constring);
            //Selecteer welke stored procedure er uitgevoerd moet worden
            String pname = "spTop10ByYear";
            //Open de sql connectie
            sqlcon.Open();
            SqlCommand com = new SqlCommand(pname, sqlcon);
            com.CommandType = CommandType.StoredProcedure;
            //Als jaar niet gelijk is aan 2018 voeg het jaar toe als parameter aan de stored procedure
            if (jaar != 2018)
            {
                com.Parameters.Add(
                            new SqlParameter("@YEAR", jaar));
            }
            //Voer de stored procedure uit in de database
            SqlDataReader dr = com.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            //Stuur de resultaten terug in een datatable naar een view
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
