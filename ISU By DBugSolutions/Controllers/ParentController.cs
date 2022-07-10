using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ISU_By_DBugSolutions.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Drawing;
using Syncfusion.Pdf.Grid;
using Syncfusion.Pdf;
using Microsoft.AspNetCore.Authorization;

namespace ISU_By_DBugSolutions.Controllers
{
    [Authorize(Roles = "Admin, ECDC Manager, Teacher")]
    public class ParentController : Controller
    {
        private readonly ApplicationDBContext _context;
        private readonly IWebHostEnvironment _iweb;
        private readonly ApplicationDBContext _adb;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public ParentController(SignInManager<ApplicationUser> signInManager, ApplicationDBContext context, IWebHostEnvironment iweb, ApplicationDBContext adb, UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
            _adb = adb;
            _context = context;
            _iweb = iweb;
            this.signInManager = signInManager;
        }

        // GET: Parent
        public IActionResult Index(int pg = 1, string SearchText = "")
        {
            List<Parent> enq = _context.Parent.ToList();
            if (SearchText != "" && SearchText != null)
            {
                enq = _context.Parent.Where(p => p.FirstName.Contains(SearchText) || p.LastName.Contains(SearchText)
                                                        || p.CityName.Contains(SearchText) || p.ContactNo.Contains(SearchText)
                                                        || p.Email.Contains(SearchText) || p.Gender.Contains(SearchText)
                                                        || p.ProvinceName.Contains(SearchText) || p.streetName.Contains(SearchText) 
                                                        || p.SuburbName.Contains(SearchText)).ToList();

            }
            else
            {
                enq = _context.Parent.ToList();
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

        // GET: Parent/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parent = await _context.Parent
                .FirstOrDefaultAsync(m => m.ParentID == id);
            if (parent == null)
            {
                return NotFound();
            }

            return View(parent);
        }

        // GET: Parent/Create
        public IActionResult Create()
        {
        

            List<Province> listProv = new List<Province>();
            listProv = (from prov in _context.Province select prov).ToList();
            ViewBag.listOfProvs = listProv;

            return View();
        }

        // POST: Parent/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ParentID,FirstName,LastName,DateOfBirth,Gender,Email,ContactNo,ImageFile,houseNo,streetName,SuburbName,CityName,ProvinceName")] Parent parent)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _iweb.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(parent.ImageFile.FileName);
                string extension = Path.GetExtension(parent.ImageFile.FileName);
                parent.ImageName = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                string path = Path.Combine(wwwRootPath + "/ECDCImages/", fileName);

                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await parent.ImageFile.CopyToAsync(fileStream);
                }
                _context.Add(parent);
                await _context.SaveChangesAsync();
                TempData["Message"] = "success";
                return RedirectToAction(nameof(Index));
            }
            return View(parent);
        }

        // GET: Parent/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
       

            List<Province> listProv = new List<Province>();
            listProv = (from prov in _context.Province select prov).ToList();
            ViewBag.listOfProvs = listProv;

            if (id == null)
            {
                return NotFound();
            }

            var parent = await _context.Parent.FindAsync(id);
            if (parent == null)
            {
                return NotFound();
            }
            return View(parent);
        }

        // POST: Parent/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ParentID,FirstName,LastName,DateOfBirth,Gender,Email,ContactNo,ImageFile,houseNo,streetName,SuburbName,CityName,ProvinceName")] Parent parent)
        {
            if (id != parent.ParentID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    string wwwRootPath = _iweb.WebRootPath;
                    string fileName = Path.GetFileNameWithoutExtension(parent.ImageFile.FileName);
                    string extension = Path.GetExtension(parent.ImageFile.FileName);
                    parent.ImageName = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    string path = Path.Combine(wwwRootPath + "/ECDCImages/", fileName);

                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        await parent.ImageFile.CopyToAsync(fileStream);
                    }
                    _context.Update(parent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ParentExists(parent.ParentID))
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
            return View(parent);
        }

        // GET: Parent/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parent = await _context.Parent
                .FirstOrDefaultAsync(m => m.ParentID == id);
            if (parent == null)
            {
                return NotFound();
            }

            return View(parent);
        }

        // POST: Parent/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var parent = await _context.Parent.FindAsync(id);
            var imagePath = Path.Combine(_iweb.WebRootPath, "ECDCImages", parent.ImageName);
            if (System.IO.File.Exists(imagePath))
            {
                System.IO.File.Delete(imagePath);
            }
            _context.Parent.Remove(parent);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ParentExists(int id)
        {
            return _context.Parent.Any(e => e.ParentID == id);
        }
        public IActionResult CreateDocument()
        {

            PdfDocument doc = new PdfDocument();

            PdfPage page = doc.Pages.Add();

            PdfGrid pdfGrid = new PdfGrid();

            List<Parent> enq = _context.Parent.ToList();


            IEnumerable<object> dataTable = enq;

            pdfGrid.DataSource = dataTable;

            PdfGraphics graphics = page.Graphics;


            PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 20);
            PdfFont font1 = new PdfStandardFont(PdfFontFamily.Helvetica, 13);
            graphics.DrawString("Parent List - Report:", font, PdfBrushes.Black, new PointF(0, 0));
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
