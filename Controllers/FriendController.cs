using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using YoMateProjectShare.Data;

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
    }
}
