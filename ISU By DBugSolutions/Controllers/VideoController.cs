using ISU_By_DBugSolutions.Models;
using Microsoft.AspNetCore.Authorization;
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
    public class VideoController : Controller
    {
        private readonly ApplicationDBContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public VideoController(ApplicationDBContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            this._hostEnvironment = hostEnvironment;
        }

        // GET: Video
        [Authorize(Roles = "Admin, Regional Coordinator, Provincial Coordinator, Teacher, Student, ECDC Manager, Parent")]
        public IActionResult Index(int pg = 1, string SearchText = "")
        {
            List<Video> enq = _context.Videos.ToList();
            if (SearchText != "" && SearchText != null)
            {
                enq = _context.Videos.Where(p => p.Title.Contains(SearchText) || p.Title.Contains(SearchText)).ToList();

            }
            else
            {
                enq = _context.Videos.ToList();
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
        [Authorize(Roles = "Admin, Regional Coordinator, Provincial Coordinator, Teacher, Student, ECDC Manager, Parent")]
        // GET: Video/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var videoModel = await _context.Videos
                .FirstOrDefaultAsync(m => m.VideoId == id);
            if (videoModel == null)
            {
                return NotFound();
            }

            return View(videoModel);
        }
        [Authorize(Roles = "Admin, ECDC Manager")]
        // GET: Video/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Video/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
     [Authorize(Roles = "Admin, ECDC Manager")]
        [HttpPost]
        [ValidateAntiForgeryToken]
    
        public async Task<IActionResult> Create([Bind("VideoId,Title,Year,VideoFile")] Video videoModel)
        {
            if (ModelState.IsValid)
            {

                string wwwRootPathVideo = _hostEnvironment.WebRootPath;
                string fileNameVideo = Path.GetFileNameWithoutExtension(videoModel.VideoFile.FileName);
                string extensionVideo = Path.GetExtension(videoModel.VideoFile.FileName);
                videoModel.VideoName = fileNameVideo = fileNameVideo + DateTime.Now.ToString("yymmssfff") + extensionVideo;
                string pathVideo = Path.Combine(wwwRootPathVideo + "/Video/", fileNameVideo);
                using (var fileStream = new FileStream(pathVideo, FileMode.Create))
                {
                    await videoModel.VideoFile.CopyToAsync(fileStream);
                }

                _context.Add(videoModel);
                await _context.SaveChangesAsync();
                TempData["Message"] = "success";
                return RedirectToAction(nameof(Index));
            }
            return View(videoModel);
        }
  [Authorize(Roles = "Admin, ECDC Manager")]
        // GET: Video/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var videoModel = await _context.Videos.FindAsync(id);
            if (videoModel == null)
            {
                return NotFound();
            }
            return View(videoModel);
        }

        // POST: Video/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Edit(int id, [Bind("VideoId,Title,Year,VideoName")] Video videoModel)
        {
            if (id != videoModel.VideoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(videoModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VideoModelExists(videoModel.VideoId))
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
            return View(videoModel);
        }
        [Authorize(Roles = "Admin, ECDC Manager")]
        // GET: Video/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var videoModel = await _context.Videos
                .FirstOrDefaultAsync(m => m.VideoId == id);
            if (videoModel == null)
            {
                return NotFound();
            }

            return View(videoModel);
        }
   [Authorize(Roles = "Admin, ECDC Manager")]
        // POST: Video/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var videoModel = await _context.Videos.FindAsync(id);
            _context.Videos.Remove(videoModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VideoModelExists(int id)
        {
            return _context.Videos.Any(e => e.VideoId == id);
        }
    }
}
