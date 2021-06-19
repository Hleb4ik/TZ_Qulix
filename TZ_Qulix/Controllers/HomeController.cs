using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TZ_Qulix.Models;

namespace TZ_Qulix.Controllers
{
    public class HomeController : Controller
    {
        WorkerContext workerContext = new WorkerContext();

        public ActionResult Index()
        {
            IEnumerable<Worker> workers = workerContext.Workers;

            ViewBag.Workers = workers;

            return View();
        }

        public ActionResult Workers()
        {
            IEnumerable<Worker> workers = workerContext.Workers;

            ViewBag.Workers = workers;

            return View();
        }

        public ActionResult Companies()
        {
            IEnumerable<Company> companies = workerContext.Companies;

            ViewBag.Companies = companies;

            return View();
        }
    }
}