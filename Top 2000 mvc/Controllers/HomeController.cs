using System;
using System.Collections.Generic;
using System.Linq;
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

        public ActionResult Edit(int id)

        {

            return View();

        }

        [AcceptVerbs(HttpVerbs.Post)]

        public ActionResult Edit(int id, FormCollection collection)

        {

            try

            {

                return RedirectToAction("Index");

            }

            catch

            {
                return View();

            }
        }
    }
}