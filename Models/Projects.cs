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
        public string ArticleName { get; set; }
        public string AuthorName { get; set; }
        [DataType(DataType.Date)]
        public DateTime UploadTime { get; set; }
        public string AbstractText { get; set; }
    }
}
