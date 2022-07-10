using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISU_By_DBugSolutions.Controllers
{
    public class AnimalSoundsController : Controller
    {
        //[Authorize(Roles = "Admin, ECDC Manager, Teacher, Student, Teacher")]
        // GET: AnimalSoundsController
        public ActionResult Index()
        {
            return View();
        }

    }
}
