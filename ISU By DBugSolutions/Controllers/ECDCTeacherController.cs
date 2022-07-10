using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ISU_By_DBugSolutions.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using System.IO;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Grid;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Drawing;
using Microsoft.AspNetCore.Authorization;

namespace ISU_By_DBugSolutions.Controllers
{
    [Authorize(Roles = "Admin, ECDC Manager, Regional Coordinator")]
    public class ECDCTeacherController : Controller
    {
        private readonly ApplicationDBContext _context;
        private readonly IWebHostEnvironment _iweb;
        private readonly ApplicationDBContext _adb;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public ECDCTeacherController(SignInManager<ApplicationUser> signInManager, ApplicationDBContext context, IWebHostEnvironment iweb, ApplicationDBContext adb, UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
            _adb = adb;
            _context = context;
            _iweb = iweb;
            this.signInManager = signInManager;
        }

        // GET: ECDCTeacher
        public IActionResult Index(int pg = 1, string SearchText = "")
        {
            List<ECDCTeacher> enq = _context.ECDCTeacher.ToList();
            if (SearchText != "" && SearchText != null)
            {
                enq = _context.ECDCTeacher.Where(p => p.FirstName.Contains(SearchText) || p.LastName.Contains(SearchText)
                                                       || p.CityName.Contains(SearchText) || p.ContactNo.Contains(SearchText)
                                                       || p.Email.Contains(SearchText) || p.Gender.Contains(SearchText)
                                                       || p.ProvinceName.Contains(SearchText) || p.streetName.Contains(SearchText)
                                                       || p.SuburbName.Contains(SearchText)).ToList();
            }
            else
            {
                enq = _context.ECDCTeacher.ToList();
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

        // GET: ECDCTeacher/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eCDCTeacher = await _context.ECDCTeacher
                .FirstOrDefaultAsync(m => m.ECDCTeacherID == id);
            if (eCDCTeacher == null)
            {
                return NotFound();
            }

            return View(eCDCTeacher);
        }

        // GET: ECDCTeacher/Create
        public IActionResult Create()
        {
          

            return View();
        }

        // POST: ECDCTeacher/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ECDCTeacherID,FirstName,LastName,DateOfBirth,Gender,Email,ContactNo,ImageFile,houseNo,streetName,SuburbName,CityName,ProvinceName")] ECDCTeacher eCDCTeacher)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _iweb.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(eCDCTeacher.ImageFile.FileName);
                string extension = Path.GetExtension(eCDCTeacher.ImageFile.FileName);
                eCDCTeacher.ImageName = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                string path = Path.Combine(wwwRootPath + "/ECDCImages/", fileName);

                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await eCDCTeacher.ImageFile.CopyToAsync(fileStream);
                }
                _context.Add(eCDCTeacher);
                await _context.SaveChangesAsync();
                TempData["Message"] = "success";
                return RedirectToAction(nameof(Index));
            }
            return View(eCDCTeacher);
        }

        // GET: ECDCTeacher/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
        

            List<Province> listProv = new List<Province>();
            listProv = (from prov in _context.Province select prov).ToList();
            ViewBag.listOfProvs = listProv;

            if (id == null)
            {
                return NotFound();
            }

            var eCDCTeacher = await _context.ECDCTeacher.FindAsync(id);
            if (eCDCTeacher == null)
            {
                return NotFound();
            }
            return View(eCDCTeacher);
        }

        // POST: ECDCTeacher/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ECDCTeacherID,FirstName,LastName,DateOfBirth,Gender,Email,ContactNo,ImageFile,houseNo,streetName,SuburbName,CityName,ProvinceName")] ECDCTeacher eCDCTeacher)
        {
            if (id != eCDCTeacher.ECDCTeacherID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    string wwwRootPath = _iweb.WebRootPath;
                    string fileName = Path.GetFileNameWithoutExtension(eCDCTeacher.ImageFile.FileName);
                    string extension = Path.GetExtension(eCDCTeacher.ImageFile.FileName);
                    eCDCTeacher.ImageName = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    string path = Path.Combine(wwwRootPath + "/ECDCImages/", fileName);

                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        await eCDCTeacher.ImageFile.CopyToAsync(fileStream);
                    }
                    _context.Update(eCDCTeacher);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ECDCTeacherExists(eCDCTeacher.ECDCTeacherID))
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
            return View(eCDCTeacher);
        }

        // GET: ECDCTeacher/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eCDCTeacher = await _context.ECDCTeacher
                .FirstOrDefaultAsync(m => m.ECDCTeacherID == id);
            if (eCDCTeacher == null)
            {
                return NotFound();
            }

            return View(eCDCTeacher);
        }

        // POST: ECDCTeacher/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var eCDCTeacher = await _context.ECDCTeacher.FindAsync(id);
            var imagePath = Path.Combine(_iweb.WebRootPath, "ECDCImages", eCDCTeacher.ImageName);
            if (System.IO.File.Exists(imagePath))
            {
                System.IO.File.Delete(imagePath);
            }
            _context.ECDCTeacher.Remove(eCDCTeacher);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ECDCTeacherExists(int id)
        {
            return _context.ECDCTeacher.Any(e => e.ECDCTeacherID == id);
        }

        public IActionResult CreateDocument()
        {

            PdfDocument doc = new PdfDocument();

            PdfPage page = doc.Pages.Add();

            PdfGrid pdfGrid = new PdfGrid();

            List<ECDCTeacher> enq = _context.ECDCTeacher.ToList();


            IEnumerable<object> dataTable = enq;

            pdfGrid.DataSource = dataTable;

            PdfGraphics graphics = page.Graphics;


            PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 20);
            PdfFont font1 = new PdfStandardFont(PdfFontFamily.Helvetica, 13);
            graphics.DrawString("ECDC Teacher List - Report:", font, PdfBrushes.Black, new PointF(0, 0));
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
