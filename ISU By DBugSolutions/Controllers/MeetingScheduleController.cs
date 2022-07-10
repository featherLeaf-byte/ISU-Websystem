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
    public class MeetingScheduleController : Controller
    {
        private readonly ApplicationDBContext _context;

        public MeetingScheduleController(ApplicationDBContext context)
        {
            _context = context;
        }
        [Authorize(Roles = "Admin, ECDC Manager, Regional Coordinator, Provincial Liason, Parent")]
        public IActionResult Index(int pg = 1, string SearchText = "")
        {
            List<MeetingSchedule> enq = _context.MeetingSchedule.ToList();
            if (SearchText != "" && SearchText != null)
            {
                enq = _context.MeetingSchedule.Where(p => p.Subject.Contains(SearchText) || p.Details.Contains(SearchText)  || p.Scheduler.Contains(SearchText) || p.Date.ToString().Contains(SearchText)).ToList();
            }
            else
            {
                enq = _context.MeetingSchedule.ToList();
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
        [Authorize(Roles = "Admin, ECDC Manager, Regional Coordinator, Provincial Liason, Parent")]
        // GET: Enquiry/Create
        public IActionResult Create()
        {
          
            return View();
        }

        // POST: Enquiry/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin, ECDC Manager, Regional Coordinator, Provincial Liason, Parent")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MeetingScheduleID,Scheduler,Venue,Subject,Details,Date,StartTime,EndTime")] MeetingSchedule meet, int hours)
        {




            if (ModelState.IsValid)
            {
                if(meet.StartTime < DateTime.Now)
                {
                    TempData["error"] = "ok";
                }
                else
                {
 meet.EndTime = meet.StartTime.AddHours(2);
                _context.Add(meet);
                await _context.SaveChangesAsync();
                TempData["Message"] = "success";
                return RedirectToAction(nameof(Index));
                }
               
            }
       
            return View(meet);

        }

        // GET: Enquiry/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            List<Pupil> listPupil = new List<Pupil>();
            listPupil = (from pupil in _context.Pupil select pupil).ToList();
            ViewBag.listPupil = listPupil;            

            if (id == null)
            {
                return NotFound();
            }

            var meet = await _context.MeetingSchedule.FindAsync(id);
            if (meet == null)
            {
                return NotFound();
            }
            return View(meet);
        }

        // POST: Enquiry/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MeetingScheduleID,StudentName,Subject,Details,Date,StartTime,EndTime")] MeetingSchedule meet)
        {
            if (id != meet.MeetingScheduleID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(meet);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MeetingScheduleExist(meet.MeetingScheduleID))
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
            return View(meet);
        }
        [Authorize(Roles = "Admin")]
        // GET: Enquiry/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eat = await _context.MeetingSchedule
                .FirstOrDefaultAsync(m => m.MeetingScheduleID == id);
            if (eat == null)
            {
                return NotFound();
            }

            return View(eat);
        }
        [Authorize(Roles = "Admin, ECDC Manager, Regional Coordinator, Provincial Liason, Parent")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sched = await _context.MeetingSchedule
                .FirstOrDefaultAsync(m => m.MeetingScheduleID == id);
            if (sched == null)
            {
                return NotFound();
            }

            return View(sched);
        }
        [Authorize(Roles = "Admin")]
        // POST: Enquiry/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var enquiry = await _context.MeetingSchedule.FindAsync(id);
            _context.MeetingSchedule.Remove(enquiry);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MeetingScheduleExist(int id)
        {
            return _context.MeetingSchedule.Any(e => e.MeetingScheduleID == id);
        }
        [Authorize(Roles = "Admin, ECDC Manager, Regional Coordinator, Provincial Liason, Parent")]
        public IActionResult CreateDocument()
        {

            PdfDocument doc = new PdfDocument();

            PdfPage page = doc.Pages.Add();

            PdfGrid pdfGrid = new PdfGrid();

            List<MeetingSchedule> enq = _context.MeetingSchedule.ToList();


            IEnumerable<object> dataTable = enq;

            pdfGrid.DataSource = dataTable;

            PdfGraphics graphics = page.Graphics;


            PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 20);
            PdfFont font1 = new PdfStandardFont(PdfFontFamily.Helvetica, 13);
            graphics.DrawString("Meeting Schedule List - Report:", font, PdfBrushes.Black, new PointF(0, 0));
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
