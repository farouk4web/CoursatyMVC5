using Coursaty.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Coursaty.Models
{
    public class Course
    {
        public int Id { get; set; }

        [Required(ErrorMessageResourceName = "requiredFeildMsg", ErrorMessageResourceType = typeof(ModelsKeys))]
        [MinLength(4, ErrorMessageResourceName = "min4", ErrorMessageResourceType = typeof(ModelsKeys))]
        [MaxLength(200, ErrorMessageResourceName = "max200", ErrorMessageResourceType = typeof(ModelsKeys))]
        [Display(Name = "Title", ResourceType = typeof(ModelsKeys))]
        public string Title { get; set; }

        [Required(ErrorMessageResourceName = "requiredFeildMsg", ErrorMessageResourceType = typeof(ModelsKeys))]
        [MinLength(4, ErrorMessageResourceName = "min4", ErrorMessageResourceType = typeof(ModelsKeys))]
        [MaxLength(60, ErrorMessageResourceName = "max60", ErrorMessageResourceType = typeof(ModelsKeys))]
        [RegularExpression("^[a-zA-Zء-ي ]*$", ErrorMessageResourceName = "vlaidHumanNameMsg", ErrorMessageResourceType = typeof(ModelsKeys))]
        [Display(Name = "Instructor", ResourceType = typeof(ModelsKeys))]
        public string Instructor { get; set; }

        [Required(ErrorMessageResourceName = "requiredFeildMsg", ErrorMessageResourceType = typeof(ModelsKeys))]
        [MinLength(50, ErrorMessageResourceName = "min50", ErrorMessageResourceType = typeof(ModelsKeys))]
        [MaxLength(300, ErrorMessageResourceName = "max300", ErrorMessageResourceType = typeof(ModelsKeys))]
        [Display(Name = "About", ResourceType = typeof(ModelsKeys))]
        public string About { get; set; }

        [Url]
        [Required(ErrorMessageResourceName = "requiredFeildMsg", ErrorMessageResourceType = typeof(ModelsKeys))]
        [Display(Name = "Link", ResourceType = typeof(ModelsKeys))]
        public string Link { get; set; }

        [Display(Name = "CoursePicture", ResourceType = typeof(ModelsKeys))]
        public string CoursePicture { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Link", ResourceType = typeof(ModelsKeys))]
        public DateTime PublishDate { get; set; }

        [Display(Name = "Likes", ResourceType = typeof(ModelsKeys))]
        public int Likes { get; set; }

        [Display(Name = "Views", ResourceType = typeof(ModelsKeys))]
        public int Views { get; set; }


        [Required(ErrorMessageResourceName = "requiredFeildMsg", ErrorMessageResourceType = typeof(ModelsKeys))]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }


        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}