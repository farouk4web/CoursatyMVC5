using Coursaty.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Coursaty.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required(ErrorMessageResourceName = "requiredFeildMsg", ErrorMessageResourceType =typeof(ModelsKeys))]
        [MinLength(4, ErrorMessageResourceName = "min4", ErrorMessageResourceType = typeof(ModelsKeys))]
        [MaxLength(60, ErrorMessageResourceName = "max60", ErrorMessageResourceType = typeof(ModelsKeys))]
        [Display(Name = "Name", ResourceType = typeof(ModelsKeys))]
        public string Name { get; set; }

        public virtual ICollection<Course> Courses { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}