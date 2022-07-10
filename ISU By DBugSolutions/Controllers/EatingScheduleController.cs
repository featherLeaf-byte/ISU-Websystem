using ISU_By_DBugSolutions.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Grid;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ISU_By_DBugSolutions.Controllers
{
 
    public class EatingScheduleController : Controller
    {
        private readonly ApplicationDBContext _context;

        public EatingScheduleController(ApplicationDBContext context)
        {
            _context = context;
        }

        public IActionResult Index(int pg = 1, string SearchText = "")
        {
            List<EatingSchedule> enq = _context.EatingSchedule.ToList();
            if (SearchText != "" && SearchText != null)
            {
                enq = _context.EatingSchedule.Where(p => p.CrecheName.Contains(SearchText) || p.MealName.Contains(SearchText) || p.Date.ToString().Contains(SearchText)).ToList();
            }
            else
            {
                enq = _context.EatingSchedule.ToList();
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

        // GET: Enquiry/Create
        public IActionResult Create()
        {
            List<Creche> listCreche = new List<Creche>();
            listCreche = (from creche in _context.Creche select creche).ToList();
            ViewBag.listCreche = listCreche;
            List<Meal> listMeal = new List<Meal>();
            listMeal = (from meal in _context.Meal select meal).ToList();
            ViewBag.listMeal = listMeal;            
            
            return View();
        }

        // POST: Enquiry/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin, ECDC Manager, Teacher")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EatingSchedID,CrecheName,MealName,Date")] EatingSchedule eating)
        {
            if (ModelState.IsValid)
            {
                _context.Add(eating);
                await _context.SaveChangesAsync();
                TempData["Message"] = "success";
                return RedirectToAction(nameof(Index));
            }
            return View(eating);
        }
        [Authorize(Roles = "Admin, ECDC Manager")]
        // GET: Enquiry/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            List<Creche> listCreche = new List<Creche>();
            listCreche = (from creche in _context.Creche select creche).ToList();
            ViewBag.listCreche = listCreche;
            List<Meal> listMeal = new List<Meal>();
            listMeal = (from meal in _context.Meal select meal).ToList();
            ViewBag.listMeal = listMeal;

            if (id == null)
            {
                return NotFound();
            }

            var enquiry = await _context.EatingSchedule.FindAsync(id);
            if (enquiry == null)
            {
                return NotFound();
            }
            return View(enquiry);
        }

        // POST: Enquiry/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost] 
        [Authorize(Roles = "Admin, ECDC Manager")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EatingSchedID,CrecheName,MealName,Date")] EatingSchedule eating)
        {
            if (id != eating.EatingSchedID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(eating);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EnquiryExists(eating.EatingSchedID))
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
            return View(eating);
        }
        [Authorize(Roles = "Admin")]
        // GET: Enquiry/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eat = await _context.EatingSchedule
                .FirstOrDefaultAsync(m => m.EatingSchedID == id);
            if (eat == null)
            {
                return NotFound();
            }

            return View(eat);
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eatsched = await _context.EatingSchedule
                .FirstOrDefaultAsync(m => m.EatingSchedID == id);
            if (eatsched == null)
            {
                return NotFound();
            }

            return View(eatsched);
        }

        // POST: Enquiry/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var enquiry = await _context.EatingSchedule.FindAsync(id);
            _context.EatingSchedule.Remove(enquiry);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EnquiryExists(int id)
        {
            return _context.EatingSchedule.Any(e => e.EatingSchedID == id);
        }
        [Authorize(Roles = "Admin,Teacher,ECDC Manager, Regional Coordinator, Provincial Coordinator")]
        public IActionResult CreateDocument()
        {

            PdfDocument doc = new PdfDocument();

            PdfPage page = doc.Pages.Add();

            PdfGrid pdfGrid = new PdfGrid();

            List<EatingSchedule> enq = _context.EatingSchedule.ToList();


            IEnumerable<object> dataTable = enq;

            pdfGrid.DataSource = dataTable;

            PdfGraphics graphics = page.Graphics;


            PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 20);
            PdfFont font1 = new PdfStandardFont(PdfFontFamily.Helvetica, 13);
            graphics.DrawString("Eating Schedule List - Report:", font, PdfBrushes.Black, new PointF(0, 0));
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
