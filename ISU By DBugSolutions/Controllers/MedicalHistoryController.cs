using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ISU_By_DBugSolutions.Models;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Grid;
using Syncfusion.Pdf;
using Syncfusion.Drawing;
using System.IO;
using Microsoft.AspNetCore.Authorization;

namespace ISU_By_DBugSolutions.Controllers
{
    [Authorize(Roles = "Admin, ECDC Manager, Teacher")]
    public class MedicalHistoryController : Controller
    {
        private readonly ApplicationDBContext _context;

        public MedicalHistoryController(ApplicationDBContext context)
        {
            _context = context;
        }
        [Authorize(Roles = "Admin, ECDC Manager, Teacher, Parent")]
        // GET: MedicalHistory
        public IActionResult Index(int pg = 1, string SearchText = "")
        {
            List<MedicalHistory> enq = _context.MedicalHistory.ToList();
            if (SearchText != "" && SearchText != null)
            {
                enq = _context.MedicalHistory.Where(p => p.PupilName.Contains(SearchText) || p.AllergyName.Contains(SearchText) 
                                                        || p.DiseaseName.Contains(SearchText) || p.DoctorName.Contains(SearchText) 
                                                        || p.MedicationName.Contains(SearchText) || p.PupilSurname.Contains(SearchText)
                                                        || p.SurgeryName.Contains(SearchText)).ToList();


            }
            else
            {
                enq = _context.MedicalHistory.ToList();
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

        // GET: MedicalHistory/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicalHistory = await _context.MedicalHistory.FirstOrDefaultAsync(m => m.MedHistID == id);
            if (medicalHistory == null)
            {
                return NotFound();
            }

            return View(medicalHistory);
        }

        // GET: MedicalHistory/Create
        public IActionResult Create()
        {
            List<Pupil> listPupil = new List<Pupil>();
            listPupil = (from pup in _context.Pupil select pup).ToList();
            ViewBag.listOfPupils = listPupil;

            List<Disease> listDisease = new List<Disease>();
            listDisease = (from Dis in _context.Disease select Dis).ToList();
            ViewBag.listOfDiseases = listDisease;

            List<Surgery> listSurgery = new List<Surgery>();
            listSurgery = (from Sur in _context.Surgery select Sur).ToList();
            ViewBag.listOfSurgeries = listSurgery;

            List<Allergy> listAllergy = new List<Allergy>();
            listAllergy = (from All in _context.Allergy select All).ToList();
            ViewBag.listOfAllergies = listAllergy;

            List<Doctor> listDoctor = new List<Doctor>();
            listDoctor = (from Doc in _context.Doctor select Doc).ToList();
            ViewBag.listOfDoctors = listDoctor;

            List<Medication> listMed = new List<Medication>();
            listMed = (from Med in _context.Medication select Med).ToList();
            ViewBag.listOfMedications = listMed;

            return View();
        }

        // POST: MedicalHistory/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MedHistID,PupilName,PupilSurname,Date,DiseaseName,SurgeryName,AllergyName,DoctorName,MedicationName")] MedicalHistory medicalHistory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(medicalHistory);
                await _context.SaveChangesAsync();
                TempData["Message"] = "success";
                return RedirectToAction(nameof(Index));
            }
            return View(medicalHistory);
        }

        // GET: MedicalHistory/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            List<Pupil> listPupil = new List<Pupil>();
            listPupil = (from pup in _context.Pupil select pup).ToList();
            ViewBag.listOfPupils = listPupil;

            List<Disease> listDisease = new List<Disease>();
            listDisease = (from Dis in _context.Disease select Dis).ToList();
            ViewBag.listOfDiseases = listDisease;

            List<Surgery> listSurgery = new List<Surgery>();
            listSurgery = (from Sur in _context.Surgery select Sur).ToList();
            ViewBag.listOfSurgeries = listSurgery;

            List<Allergy> listAllergy = new List<Allergy>();
            listAllergy = (from All in _context.Allergy select All).ToList();
            ViewBag.listOfAllergies = listAllergy;

            List<Doctor> listDoctor = new List<Doctor>();
            listDoctor = (from Doc in _context.Doctor select Doc).ToList();
            ViewBag.listOfDoctors = listDoctor;

            List<Medication> listMed = new List<Medication>();
            listMed = (from Med in _context.Medication select Med).ToList();
            ViewBag.listOfMedications = listMed;

            if (id == null)
            {
                return NotFound();
            }

            var medicalHistory = await _context.MedicalHistory.FindAsync(id);
            if (medicalHistory == null)
            {
                return NotFound();
            }
            return View(medicalHistory);
        }

        // POST: MedicalHistory/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MedHistID,PupilName,PupilSurname,Date,DiseaseName,SurgeryName,AllergyName,DoctorName,MedicationName")] MedicalHistory medicalHistory)
        {
            if (id != medicalHistory.MedHistID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(medicalHistory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MedicalHistoryExists(medicalHistory.MedHistID))
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
            return View(medicalHistory);
        }

        // GET: MedicalHistory/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicalHistory = await _context.MedicalHistory
                .FirstOrDefaultAsync(m => m.MedHistID == id);
            if (medicalHistory == null)
            {
                return NotFound();
            }

            return View(medicalHistory);
        }

        // POST: MedicalHistory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var medicalHistory = await _context.MedicalHistory.FindAsync(id);
            _context.MedicalHistory.Remove(medicalHistory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MedicalHistoryExists(int id)
        {
            return _context.MedicalHistory.Any(e => e.MedHistID == id);
        }
        public IActionResult CreateDocument()
        {

            PdfDocument doc = new PdfDocument();

            PdfPage page = doc.Pages.Add();

            PdfGrid pdfGrid = new PdfGrid();

            List<MedicalHistory> enq = _context.MedicalHistory.ToList();


            IEnumerable<object> dataTable = enq;

            pdfGrid.DataSource = dataTable;

            PdfGraphics graphics = page.Graphics;


            PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 20);
            PdfFont font1 = new PdfStandardFont(PdfFontFamily.Helvetica, 13);
            graphics.DrawString("Student Medical History - Report:", font, PdfBrushes.Black, new PointF(0, 0));
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
