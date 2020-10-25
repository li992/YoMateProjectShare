using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace YoMateProjectShare.Areas.Identity.Data
{
    public class UserInfo : IdentityUser
    {
        [PersonalData]
        public string Name { get; set; }

        [PersonalData]
        public DateTime DOB { get; set; }
    }
}
