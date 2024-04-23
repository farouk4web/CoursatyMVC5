using Coursaty.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Coursaty.ViewModels
{
    public class CategoriesVM
    {
        public IList<Category> Categories { get; set; }

        public Category NewCategory { get; set; }
    }
}