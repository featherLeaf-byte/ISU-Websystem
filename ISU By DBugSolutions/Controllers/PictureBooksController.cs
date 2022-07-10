using ISU_By_DBugSolutions.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ISU_By_DBugSolutions.Controllers
{
    public class PictureBooksController : Controller
    {
        private readonly ApplicationDBContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public PictureBooksController(ApplicationDBContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            this._hostEnvironment = hostEnvironment;
        }
        [Authorize(Roles = "Admin, Parent, Teacher, Student")]
        // GET: PictureBooks
        public async Task<IActionResult> Index()
        {
            return View(await _context.PictureBooks.ToListAsync());
        }
[Authorize(Roles = "Admin, Parent, Teacher, Student")]
        // GET: PictureBooks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pictureBook = await _context.PictureBooks
                .FirstOrDefaultAsync(m => m.PictureBookId == id);
            if (pictureBook == null)
            {
                return NotFound();
            }

            return View(pictureBook);
        }
        [Authorize(Roles = "Admin, ECDC Manager")]
        // GET: PictureBooks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PictureBooks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, ECDC Manager")]
        public async Task<IActionResult> Create([Bind("PictureBookId,Title,Author,Synopsis,BookFile")] PictureBook pictureBook)
        {

            if (ModelState.IsValid)
            {
                if (pictureBook.BookFile.FileName != null && pictureBook.BookFile.FileName.Length > 0)
                {
                    try
                    {
                        string wwwRootPath = _hostEnvironment.WebRootPath;
                        string fileName = Path.GetFileNameWithoutExtension(pictureBook.BookFile.FileName);
                        string extension = Path.GetExtension(pictureBook.BookFile.FileName);
                        pictureBook.BookFileName = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                        string path = Path.Combine(wwwRootPath + "/Book/", fileName);
                        using (var fileStream = new FileStream(path, FileMode.Create))
                        {
                            await pictureBook.BookFile.CopyToAsync(fileStream);
                        }


                        _context.Add(pictureBook);
                        await _context.SaveChangesAsync();
                        TempData["Message"] = "success";
                        return RedirectToAction(nameof(Index));
                    }
                    catch (Exception e)
                    {
                        ViewBag.UploadError = "Upload file error";
                        return View("Index");
                    }

                }
                else
                {
                    ViewBag.UploadError = "Upload file error";
                    return View("Index");
                }

            }
            return View(pictureBook);
        }

  [Authorize(Roles = "Admin, ECDC Manager")]

        // GET: PictureBooks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pictureBook = await _context.PictureBooks.FindAsync(id);
            if (pictureBook == null)
            {
                return NotFound();
            }
            return View(pictureBook);
        }

        // POST: PictureBooks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, ECDC Manager")]
        public async Task<IActionResult> Edit(int id, [Bind("PictureBookId,Title,Author,Synopsis,BookFileName")] PictureBook pictureBook)
        {
            if (id != pictureBook.PictureBookId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pictureBook);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PictureBookExists(pictureBook.PictureBookId))
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
            return View(pictureBook);
        }

        // GET: PictureBooks/Delete/5
        [Authorize(Roles = "Admin, ECDC Manager")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pictureBook = await _context.PictureBooks
                .FirstOrDefaultAsync(m => m.PictureBookId == id);
            if (pictureBook == null)
            {
                return NotFound();
            }

            return View(pictureBook);
        }

        // POST: PictureBooks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, ECDC Manager")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pictureBook = await _context.PictureBooks.FindAsync(id);
            _context.PictureBooks.Remove(pictureBook);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PictureBookExists(int id)
        {
            return _context.PictureBooks.Any(e => e.PictureBookId == id);
        }
    }
}
