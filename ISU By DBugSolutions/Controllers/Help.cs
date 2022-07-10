using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISU_By_DBugSolutions.Controllers
{
    [AllowAnonymous]
    public class Help : Controller
    {
        // GET: Help
        public ActionResult Accounts()
        {
            return View();
        }
        public ActionResult Navigation()
        {
            return View();
        }

    }
}
