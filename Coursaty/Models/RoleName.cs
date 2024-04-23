using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Coursaty.Models
{
    public static class RoleName
    {
        public const string Admins = "Admins";
        public const string WorkTeam = "WorkTeam";
        public const string AdminsAndWorkTeam = Admins + "," + WorkTeam;
    }
}