using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ISU_By_DBugSolutions.Models;
using Syncfusion.Pdf.Graphics;
using System.IO;
using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Grid;
using Microsoft.AspNetCore.Authorization;

namespace ISU_By_DBugSolutions.Controllers
{
    public class EnquiryController : Controller
    {
        private readonly ApplicationDBContext _context;

        public EnquiryController(ApplicationDBContext context)
        {
            _context = context;
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Index(int pg=1, string SearchText="")
        {
            List<Enquiry> enq = _context.Enquiry.ToList();
            if(SearchText!="" && SearchText!=null)
            {
                enq = _context.Enquiry.Where(p => p.Subject.Contains(SearchText) || p.Email.Contains(SearchText)).ToList();

            }
            else
            {
                enq = _context.Enquiry.ToList();
            }

            const int pageSize = 5;
            if(pg < 1)
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
        [Authorize(Roles = "Admin")]
        // GET: Enquiry/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enquiry = await _context.Enquiry
                .FirstOrDefaultAsync(m => m.EnquiryID == id);
            if (enquiry == null)
            {
                return NotFound();
            }

            return View(enquiry);
        }
        [AllowAnonymous]
        // GET: Enquiry/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Enquiry/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EnquiryID,Name,Email,Date,Subject,Details")] Enquiry enquiry)
        {
            if (ModelState.IsValid)
            {
                _context.Add(enquiry);
                await _context.SaveChangesAsync();
                TempData["Message"] = "success";
                return Redirect("~/Home/Index");
            }
            return View(enquiry);
        }

        // GET: Enquiry/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var enquiry = await _context.Enquiry.FindAsync(id);
        //    if (enquiry == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(enquiry);
        //}

        //// POST: Enquiry/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //// more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("EnquiryID,Name,Email,Date,Subject,Details")] Enquiry enquiry)
        //{
        //    if (id != enquiry.EnquiryID)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(enquiry);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!EnquiryExists(enquiry.EnquiryID))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(enquiry);
        //}

        [Authorize(Roles = "Admin")]
        // GET: Enquiry/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enquiry = await _context.Enquiry
                .FirstOrDefaultAsync(m => m.EnquiryID == id);
            if (enquiry == null)
            {
                return NotFound();
            }

            return View(enquiry);
        }
        [Authorize(Roles = "Admin")]
        // POST: Enquiry/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var enquiry = await _context.Enquiry.FindAsync(id);
            _context.Enquiry.Remove(enquiry);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EnquiryExists(int id)
        {
            return _context.Enquiry.Any(e => e.EnquiryID == id);
        }
        [Authorize(Roles = "Admin")]
        public IActionResult CreateDocument()
        {

            PdfDocument doc = new PdfDocument();

            PdfPage page = doc.Pages.Add();

            PdfGrid pdfGrid = new PdfGrid();

            List<Enquiry> enq = _context.Enquiry.ToList();


            IEnumerable<object> dataTable = enq;

            pdfGrid.DataSource = dataTable;

            PdfGraphics graphics = page.Graphics;


            PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 20);
            PdfFont font1 = new PdfStandardFont(PdfFontFamily.Helvetica, 13);
            graphics.DrawString("Enquiry List - Report:", font, PdfBrushes.Black, new PointF(0, 0));
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
