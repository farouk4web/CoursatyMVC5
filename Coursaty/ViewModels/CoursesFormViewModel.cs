using Coursaty.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Coursaty.ViewModels
{
    public class CoursesFormViewModel
    {
        public Course Course { get; set; }

        public IList<Category> Categories { get; set; }
    }
}