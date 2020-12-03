using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using YoMateProjectShare.Models;

namespace YoMateProjectShare.Areas.Identity.Data
{
    public class UserInfo : IdentityUser
    {
        [PersonalData]
        public string Firstname { get; set; }

        [PersonalData]
        public string Lastname { get; set; }

        [PersonalData]
        public DateTime DOB { get; set; }

        [PersonalData]
        public DateTime DateJoined { get; set; }
    }
}
