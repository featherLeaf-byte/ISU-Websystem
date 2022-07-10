using ISU_By_DBugSolutions.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ISU_By_DBugSolutions.Controllers
{
    public class SpreadsheetController : Controller
    {
        private readonly ApplicationDBContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public SpreadsheetController(ApplicationDBContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            this._hostEnvironment = hostEnvironment;
        }

        // GET: Spreadsheets
        public async Task<IActionResult> Index()
        {
            return View(await _context.Spreadsheets.ToListAsync());
        }
        // GET: Spreadsheets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spreadSheet = await _context.Spreadsheets
                .FirstOrDefaultAsync(m => m.SpreadsheetID == id);
            if (spreadSheet == null)
            {
                return NotFound();
            }

            return View(spreadSheet );
        }

    
        // GET: SpreadsheetController/Create
        public ActionResult Create()
        {
            return View();
        }
        //public ActionResult DownloadDocument(int id)
        //{
           

        //}

        // POST: SpreadsheetController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SpreadsheetID,SheetName,DateOfUpload,SpreadsheetFile")] Spreadsheet spreadsheet)
        {

            if (ModelState.IsValid)
            {
                        string wwwRootPath = _hostEnvironment.WebRootPath;
                        string fileName = Path.GetFileNameWithoutExtension(spreadsheet.SpreadsheetFile.FileName);
                        string extension = Path.GetExtension(spreadsheet.SpreadsheetFile.FileName);
                        spreadsheet.SpreadsheetName = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                        string path = Path.Combine(wwwRootPath + "/Spreadsheet/", fileName);
                        using (var fileStream = new FileStream(path, FileMode.Create))
                        {
                            await spreadsheet.SpreadsheetFile.CopyToAsync(fileStream);
                        }


                        _context.Add(spreadsheet);
                        await _context.SaveChangesAsync();
                TempData["Message"] = "success";
                return RedirectToAction(nameof(Index));
               

            }
            return View(spreadsheet);
        }


        // GET: SpreadsheetController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SpreadsheetController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SpreadsheetController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SpreadsheetController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public async Task<IActionResult> Download(string name)
        {
            string filename = Path.GetFileName(name);
            if (filename == null)
                return Content("filename not present");

            var path = Path.Combine(
                           Directory.GetCurrentDirectory(),
                           "wwwroot","/Spreadsheet/", filename);

            var memory = new MemoryStream();
            using (var stream = new FileStream(path, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return File(memory, GetContentType(path), Path.GetFileName(path));
        }
        private string GetContentType(string path)
        {
            var types = GetMimeTypes();
            var ext = Path.GetExtension(path).ToLowerInvariant();
            return types[ext];
        }

        private Dictionary<string, string> GetMimeTypes()
        {
            return new Dictionary<string, string>
            {
                {".txt", "text/plain"},
                {".pdf", "application/pdf"},
                {".doc", "application/vnd.ms-word"},
                {".docx", "application/vnd.ms-word"},
                {".xls", "application/vnd.ms-excel"},
                {".xlsx", "application/vnd.openxmlformats  officedocument.spreadsheetml.sheet"},  
                {".png", "image/png"},
                {".jpg", "image/jpeg"},
                {".jpeg", "image/jpeg"},
                {".gif", "image/gif"},
                {".csv", "text/csv"}
            };
        }

    }
}
