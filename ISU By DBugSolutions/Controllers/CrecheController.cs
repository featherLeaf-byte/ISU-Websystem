using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ISU_By_DBugSolutions.Models;
using System.IO;
using Syncfusion.Pdf;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Extensions;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Drawing;
using Syncfusion.Pdf.Grid;
using Microsoft.AspNetCore.Authorization;

namespace ISU_By_DBugSolutions.Controllers
{

    public class CrecheController : Controller
    {
        private readonly ApplicationDBContext _context;
        private readonly IHostingEnvironment _hostingEnvironment;
     
        public CrecheController(ApplicationDBContext context, IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }

        // GET: Creche
        [Authorize(Roles = "Admin, ECDC Manager, Regional Coordinator, Provincial Liason")]
        public IActionResult Index(int pg = 1, string SearchText = "")
        {
            List<Creche> enq = _context.Creche.ToList();
            if (SearchText != "" && SearchText != null)
            {
                enq = _context.Creche.Where(p => p.Name.Contains(SearchText) || p.ProvinceName.Contains(SearchText) || p.StreetName.Contains(SearchText)
                                            || p.SuburbName.Contains(SearchText) || p.CityName.Contains(SearchText)).ToList();

            }
            else
            {
                enq = _context.Creche.ToList();
            }

            const int pageSize = 5;
            if (pg < 1)
            {
                pg = 1;
            }
            int recsCount = enq.Count();
            var pager = new Pager(recsCount, pg, pageSize);
            int recSkip = (pg - 1) * pageSize;
            var data = enq.Skip(recSkip).Take(pager.PageSize).ToList();
            this.ViewBag.Pager = pager;

            return View(data);
        }

        // GET: Creche/Details/5
        [Authorize(Roles = "Admin, ECDC Manager, Regional Coordinator, Provincial Liason")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var creche = await _context.Creche
                .FirstOrDefaultAsync(m => m.CrecheID == id);
            if (creche == null)
            {
                return NotFound();
            }

            return View(creche);
        }

        // GET: Creche/Create
        [HttpGet] 
        [Authorize(Roles = "Admin, ECDC Manager, Regional Coordinator, Provincial Liason")]
        public IActionResult Create()
        {
          

            List<Province> listProv = new List<Province>();
            listProv = (from prov in _context.Province select prov).ToList();
            ViewBag.listOfProvs = listProv;

            return View();
        }

        // POST: Creche/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        
        public async Task<IActionResult> Create([Bind("CrecheID,Name,HouseNo,StreetName,SuburbName,CityName,ProvinceName")] Creche creche)
        {
            if (ModelState.IsValid)
            {
                _context.Add(creche);
                await _context.SaveChangesAsync();
                TempData["Message"] = "success";
                return RedirectToAction(nameof(Index));
            }
            return View(creche);
        }

        // GET: Creche/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
      

            List<Province> listProv = new List<Province>();
            listProv = (from prov in _context.Province select prov).ToList();
            ViewBag.listOfProvs = listProv;

            if (id == null)
            {
                return NotFound();
            }

            var creche = await _context.Creche.FindAsync(id);
            if (creche == null)
            {
                return NotFound();
            }
            return View(creche);
        }

        // POST: Creche/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id, [Bind("CrecheID,Name,HouseNo,StreetName,SuburbName,CityName,ProvinceName")] Creche creche)
        {
            if (id != creche.CrecheID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(creche);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CrecheExists(creche.CrecheID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(creche);
        }

        // GET: Creche/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var creche = await _context.Creche
                .FirstOrDefaultAsync(m => m.CrecheID == id);
            if (creche == null)
            {
                return NotFound();
            }

            return View(creche);
        }

        // POST: Creche/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var creche = await _context.Creche.FindAsync(id);
            _context.Creche.Remove(creche);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CrecheExists(int id)
        {
            return _context.Creche.Any(e => e.CrecheID == id);
        }

        [Authorize(Roles = "Admin, ECDC Manager, Regional Coordinator, Provincial Liason")]
        public IActionResult CreateDocument()
        {
  
            PdfDocument doc = new PdfDocument();
     
            PdfPage page = doc.Pages.Add();
    
            PdfGrid pdfGrid = new PdfGrid();
           
            List<Creche> enq = _context.Creche.ToList();
      
        
            IEnumerable<object> dataTable = enq;
     
            pdfGrid.DataSource = dataTable;
   
            PdfGraphics graphics = page.Graphics;

      
            PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 20);
            PdfFont font1 = new PdfStandardFont(PdfFontFamily.Helvetica, 13);
            graphics.DrawString("Creche List - Report:", font, PdfBrushes.Black, new PointF(0, 0));
            string date = DateTime.Now.ToString();
            graphics.DrawString(date, font1, PdfBrushes.Black, new PointF(250, 5));
            pdfGrid.Draw(page, new Syncfusion.Drawing.PointF(10, 50));
      
            MemoryStream stream = new MemoryStream();
            doc.Save(stream);
       
            stream.Position = 0;
  
            doc.Close(true);
           
            string contentType = "application/pdf";
         
            string fileName = "Report.pdf";
          
            return File(stream, contentType, fileName);
        }
    }
}
