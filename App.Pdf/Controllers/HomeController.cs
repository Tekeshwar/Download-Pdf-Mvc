using App.Pdf.LanguageResource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json.Linq;

namespace App.Pdf.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact(bool success)
        {
            ViewBag.Message = "Your application description page.";
            var dowloadCookie = new HttpCookie("fileDownload")
            {
                Path = "/",
                HttpOnly = false
            };
            if (success)
            {
                byte[] bytes = System.IO.File.ReadAllBytes(Server.MapPath("~/PDF/mppebb.pdf"));
                dowloadCookie.Value = "true";
                Response.SetCookie(dowloadCookie);
                return File(bytes, System.Net.Mime.MediaTypeNames.Application.Octet, "abc.pdf");
            }
            dowloadCookie.Value = "false";
            Response.SetCookie(dowloadCookie);
            return new EmptyResult();
        }

        public ActionResult resources_()
        {
            var db = new DbResources();
            var data = db.GetResourcesForLanguage(Request.UserLanguages[0]);
            JObject json = new JObject();
            foreach (var item in data)
            {
                json.Add(item.Text, item.Value);
            }

           
            var js = " var _T = " + json.ToString();

            return Content(js);

        }
    }
}