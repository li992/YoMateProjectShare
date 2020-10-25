using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace YoMateProjectShare.Models
{
    public class Projects
    {
        public int Id { get; set; }

        [Display(Name = "Article")]
        [StringLength(200, MinimumLength = 3)]
        public string ArticleName { get; set; }
        
        [StringLength(60, MinimumLength = 3)]
        [Display(Name = "Author")]
        public string AuthorName { get; set; }
        
        [Display(Name ="Upload Time")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime UploadTime { get; set; }


        public string AbstractText { get; set; }

        //public string FieldOfStudy { get; set; }
    }
    
    public class ProjectsDBContext : DbContext
    {
        public DbSet<Projects> projects { get; set; }
    }
}

