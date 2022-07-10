using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISU_By_DBugSolutions.Controllers
{
    
    public class PageController : Controller
    {
        // GET: PageController
        [AllowAnonymous]
        public ActionResult AboutUs()
        {
            return View();
        }
        [AllowAnonymous]
        public ActionResult ContactUs()
        {
            return View();
        }
        [AllowAnonymous]
        public ActionResult Help()
        {
            return View();
        }
        [AllowAnonymous]
        public ActionResult Games()
        {
            return View();
        }
        [AllowAnonymous]
        public ActionResult ECDCGuide()
        {
            return View();
        }
        [AllowAnonymous]
        public ActionResult SafetyGuide()
        {
            return View();
        }

    }
}
