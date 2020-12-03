using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YoMateProjectShare.Data;
using YoMateProjectShare.Areas.Identity.Data;
using System.Dynamic;

namespace YoMateProjectShare.Controllers
{
    public class FriendController : Controller
    {
        private readonly YoMateProjectShareContext _context;
        private readonly YoMateProjectShareDBContext _dbcontext;
        public FriendController(YoMateProjectShareContext context, YoMateProjectShareDBContext dbcontext)
        {
            _context = context;
            _dbcontext = dbcontext;
        }

        public IActionResult Index()
        {
            var uid = _dbcontext.Users.FirstOrDefault(u => u.UserName == User.Identity.Name).Id;
            var targetid = from s in _context.Friends select s;
            if (targetid == null) return NotFound();
            targetid = targetid.Where(s => s.belongtoId == uid);
            return View(targetid);
        }

        public async Task<IActionResult> Defriend(string name)
        {
            var tUser = await _dbcontext.Users.FirstOrDefaultAsync(u => u.UserName == name);
            var cUser = await _dbcontext.Users.FirstOrDefaultAsync(s => s.UserName == User.Identity.Name);

            var target1 = from s in _context.Friends select s;
            if (target1 == null) return NotFound();
            var target2 = target1;
            var t1 = target1.Where(s => s.belongtoId == cUser.Id).Where(s => s.friendId == tUser.Id).First();
            var t2 = target2.Where(s => s.belongtoId == tUser.Id).Where(s => s.friendId == cUser.Id).First();

            _context.Friends.Remove(t1);
            _context.Friends.Remove(t2);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> UserDetail(string name)
        {
            if (name == null)
            {
                return NotFound();
            }
            var um = await _dbcontext.Users.FirstOrDefaultAsync(s => s.UserName == name);

            if (um == null)
            {
                um = new UserInfo
                {
                    UserName = "User Not Found",
                    Lastname = "User Not Found",
                    Firstname = "User Not Found"
                };
            }

            var projects = from s in _context.Projects select s;
            projects = projects.Where(s => s.AuthorName == um.UserName);

            dynamic newmodel = new ExpandoObject();
            newmodel.User = um;
            newmodel.Projects = projects;

            return View(newmodel);
        }
    }
}
