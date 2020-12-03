using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using YoMateProjectShare.Data;
using YoMateProjectShare.Models;
using Microsoft.AspNetCore.Identity;
using YoMateProjectShare.Areas.Identity.Data;

namespace YoMateProjectShare.Controllers
{
    public class ProjectController : Controller
    {
        private readonly YoMateProjectShareContext _context;
        private readonly YoMateProjectShareDBContext _dbcontext;
        public ProjectController(YoMateProjectShareContext context, YoMateProjectShareDBContext dbcontext)
        {
            _context = context;
            _dbcontext = dbcontext;
        }
        public async Task<IActionResult> Index(string sortOrder, string searchString, string currentFilter, int? pageNumber)
        {
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";
            ViewData["CurrentSort"] = sortOrder;

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            var projectlist = from s in _context.Projects select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                projectlist = projectlist.Where(s => s.AuthorName.Contains(searchString)
                                       || s.ArticleName.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    projectlist = projectlist.OrderByDescending(s => s.AuthorName);
                    break;
                case "Date":
                    projectlist = projectlist.OrderBy(s => s.UploadTime);
                    break;
                case "date_desc":
                    projectlist = projectlist.OrderByDescending(s => s.UploadTime);
                    break;
                default:
                    projectlist = projectlist.OrderBy(s => s.ArticleName);
                    break;
            }

            int pageSize = 10;
            return View(await PaginatedList<Projects>.CreateAsync(projectlist.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        public async Task<IActionResult> MyProject(string sortOrder, int? pageNumber)
        {
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";
            ViewData["CurrentSort"] = sortOrder;


            var projectlist = from s in _context.Projects select s;

            projectlist = projectlist.Where(s => s.AuthorName.Contains(User.Identity.Name));

            switch (sortOrder)
            {
                case "name_desc":
                    projectlist = projectlist.OrderByDescending(s => s.ArticleName);
                    break;
                case "Date":
                    projectlist = projectlist.OrderBy(s => s.UploadTime);
                    break;
                case "date_desc":
                    projectlist = projectlist.OrderByDescending(s => s.UploadTime);
                    break;
                default:
                    projectlist = projectlist.OrderBy(s => s.ArticleName);
                    break;
            }

            int pageSize = 10;
            return View(await PaginatedList<Projects>.CreateAsync(projectlist.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        public async Task<IActionResult> AddFriend(string name)
        {
            UserInfo currentUser = await _dbcontext.Users.FirstOrDefaultAsync(s => s.UserName == User.Identity.Name);
            UserInfo targetUser = await _dbcontext.Users.FirstOrDefaultAsync(a => a.UserName == name);
            var rel = new Friend
            {
                belongtoId = currentUser.Id,
                friendId = targetUser.Id,
                friendNickname = targetUser.UserName,
                addingTime = DateTime.Now
            };
            var rel2 = new Friend
            {
                belongtoId = targetUser.Id,
                friendId = currentUser.Id,
                friendNickname = currentUser.UserName,
                addingTime = DateTime.Now
            };

            _context.Add(rel);
            _context.Add(rel2);

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(MyProject));
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = await _context.Projects.FirstOrDefaultAsync(m=> m.Id == id);
            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }

        public async Task<IActionResult> UserInfo(string name)
        {
            if(name == null)
            {
                return NotFound();
            }
            var um = await _dbcontext.Users.FirstOrDefaultAsync(s => s.UserName == name);

            if (um == null){
                um = new UserInfo
                {
                    UserName="User Not Found",
                    Lastname="User Not Found",
                    Firstname="User Not Found"
                };
            }


            return View(um);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ArticleName,AuthorName,UploadTime,AbstractText")] Projects project)
        {
            if (ModelState.IsValid)
            {
                _context.Add(project);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(MyProject));
            }
            return View(project);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = await _context.Projects.FindAsync(id);
            if (project == null)
            {
                return NotFound();
            }
            return View(project);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ArticleName,AuthorName,UploadTime,AbstractText")] Projects project)
        {
            if (id != project.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(project);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction(nameof(MyProject));
            }
            return View(project);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var project = await _context.Projects.FirstOrDefaultAsync(m => m.Id == id);
            if (project == null) {
                return NotFound();
            }
            return View(project);
        }

        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var project = await _context.Projects.FindAsync(id);
            _context.Projects.Remove(project);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(MyProject));
        }

        public IActionResult Create()
        {
            return View();
        }
    }

    public class PaginatedList<T> : List<T>
    {
        public int PageIndex { get; private set; }
        public int TotalPages { get; private set; }

        public PaginatedList(List<T> items, int count, int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);

            this.AddRange(items);
        }

        public bool HasPreviousPage
        {
            get
            {
                return (PageIndex > 1);
            }
        }

        public bool HasNextPage
        {
            get
            {
                return (PageIndex < TotalPages);
            }
        }

        public static async Task<PaginatedList<T>> CreateAsync(IQueryable<T> source, int pageIndex, int pageSize)
        {
            var count = await source.CountAsync();
            var items = await source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
            return new PaginatedList<T>(items, count, pageIndex, pageSize);
        }


    }
}