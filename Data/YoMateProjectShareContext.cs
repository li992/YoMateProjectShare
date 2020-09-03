using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using YoMateProjectShare.Models;

namespace YoMateProjectShare.Data
{
    public class YoMateProjectShareContext:DbContext
    {
        public YoMateProjectShareContext(DbContextOptions<YoMateProjectShareContext> options) : base(options)
        {

        }

        public DbSet<Projects> Projects { get; set; }
    }
}
