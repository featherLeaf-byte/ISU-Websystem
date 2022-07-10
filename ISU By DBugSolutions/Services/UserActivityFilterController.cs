using ISU_By_DBugSolutions.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISU_By_DBugSolutions.Service
{
    public class UserActivityFilterController : Controller
    {
        private readonly ApplicationDBContext _context;

        public UserActivityFilterController(ApplicationDBContext context)
        {
            _context = context;
        }

        public IActionResult Index(int pg = 1, string SearchText = "")
        {
            List<UserActivity> enq = _context.UserActivity.ToList();
            if (SearchText != "" && SearchText != null)
            {
                enq = _context.UserActivity.Where(p => p.Url.Contains(SearchText) 
                || p.Data.Contains(SearchText) 
                || p.UserName.Contains(SearchText) 
                || p.IpAddress.Contains(SearchText) 
                || p.ActivityDate.ToString().Contains(SearchText)).ToList();
            }
            else
            {
                enq = _context.UserActivity.ToList();
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
    }
}
