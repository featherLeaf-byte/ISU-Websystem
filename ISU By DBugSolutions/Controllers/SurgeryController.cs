using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ISU_By_DBugSolutions.Models;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Grid;
using Syncfusion.Pdf.Graphics;
using System.IO;
using Syncfusion.Drawing;
using Microsoft.AspNetCore.Authorization;

namespace ISU_By_DBugSolutions.Controllers
{
    [Authorize(Roles = "Admin")]
    public class SurgeryController : Controller
    {
        private readonly ApplicationDBContext _context;

        public SurgeryController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: Surgery
        public IActionResult Index(int pg = 1, string SearchText = "")
        {
            List<Surgery> enq = _context.Surgery.ToList();
            if (SearchText != "" && SearchText != null)
            {
                enq = _context.Surgery.Where(p => p.SurgeryName.Contains(SearchText)).ToList();
            }
            else
            {
                enq = _context.Surgery.ToList();
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

        // GET: Surgery/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var surgery = await _context.Surgery
                .FirstOrDefaultAsync(m => m.SurgeryID == id);
            if (surgery == null)
            {
                return NotFound();
            }

            return View(surgery);
        }

        // GET: Surgery/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Surgery/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SurgeryID,SurgeryName,Description")] Surgery surgery)
        {
            if (ModelState.IsValid)
            {
                _context.Add(surgery);
                await _context.SaveChangesAsync();
                TempData["Message"] = "success";
                return RedirectToAction(nameof(Index));
            }
            return View(surgery);
        }

        // GET: Surgery/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var surgery = await _context.Surgery.FindAsync(id);
            if (surgery == null)
            {
                return NotFound();
            }
            return View(surgery);
        }

        // POST: Surgery/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SurgeryID,SurgeryName,Description")] Surgery surgery)
        {
            if (id != surgery.SurgeryID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(surgery);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SurgeryExists(surgery.SurgeryID))
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
            return View(surgery);
        }

        // GET: Surgery/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var surgery = await _context.Surgery
                .FirstOrDefaultAsync(m => m.SurgeryID == id);
            if (surgery == null)
            {
                return NotFound();
            }

            return View(surgery);
        }

        // POST: Surgery/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var surgery = await _context.Surgery.FindAsync(id);
            _context.Surgery.Remove(surgery);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SurgeryExists(int id)
        {
            return _context.Surgery.Any(e => e.SurgeryID == id);
        }

        public IActionResult CreateDocument()
        {

            PdfDocument doc = new PdfDocument();

            PdfPage page = doc.Pages.Add();

            PdfGrid pdfGrid = new PdfGrid();

            List<Surgery> enq = _context.Surgery.ToList();


            IEnumerable<object> dataTable = enq;

            pdfGrid.DataSource = dataTable;

            PdfGraphics graphics = page.Graphics;


            PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 20);
            PdfFont font1 = new PdfStandardFont(PdfFontFamily.Helvetica, 13);
            graphics.DrawString("Surgery List - Report:", font, PdfBrushes.Black, new PointF(0, 0));
            string date = DateTime.Now.ToString();
            graphics.DrawString(date, font1, PdfBrushes.Black, new PointF(350, 5));
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
