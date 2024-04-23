using Coursaty.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Coursaty.ViewModels
{
    public class UserAccountViewModel
    {
        public ApplicationUser User { get; set; }

        public bool IsAdmin { get; set; }

        public bool IsFromWorkTeam { get; set; }
    }
}