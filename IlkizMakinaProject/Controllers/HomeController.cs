using IlkizMakinaProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IlkizMakinaProject.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        [ActionName("Index")]
        public ActionResult IndexGet()
        {
            IndexViewModel model = new IndexViewModel();
            return View(model);
        }

        [HttpGet]
        [ActionName("About")]
        public ActionResult AboutGet()
        {
            AboutViewModel model = new AboutViewModel();
            return View(model);
        }

        [HttpGet]
        [ActionName("Contact")]
        public ActionResult ContactGet()
        {
            ContactViewModel model = new ContactViewModel();
            return View(model);
        }

        [HttpPost]
        [ActionName("Contact")]
        public ActionResult ContactPost(ContactViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.SendMessage();
            }

            return View(model);
        }

        [HttpGet]
        [ActionName("Portfolio")]
        public ActionResult PortfolioGet()
        {
            PortfolioViewModel model = new PortfolioViewModel();
            return View(model);
        }
       
        [HttpGet]
        [ActionName("Products")]
        public ActionResult ProductsGet(int? id)
        {
            if (id==null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ProductsViewModel model = new ProductsViewModel(id.Value);
                return View(model);
            }           
        }

    }
}