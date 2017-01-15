using Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebClient.Utils;
using WebPortal.Models;

namespace WebPortal.Controllers
{
    public class HomeController : Controller
    {
        private readonly BootstrapingResult app = Bootstraper.Bootstrap();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult CreateStudent()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateStudent(StudentViewModel data)
        {
            if (ModelState.IsValid)
            {
                app.Send(new CreateNewStudent(Guid.NewGuid(), data.Name, data.StudyYear));
            }
            else
            {
                //TODO: log 
            }
            return RedirectToAction("Index");
        }
    }
}