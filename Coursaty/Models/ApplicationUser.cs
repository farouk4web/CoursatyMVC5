using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Coursaty.Resources;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Coursaty.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        //  CUSTOM PROPS
        [Required(ErrorMessageResourceName = "requiredFeildMsg", ErrorMessageResourceType = typeof(ModelsKeys))]
        [MinLength(4, ErrorMessageResourceName = "min4", ErrorMessageResourceType = typeof(ModelsKeys))]
        [MaxLength(60, ErrorMessageResourceName = "max60", ErrorMessageResourceType = typeof(ModelsKeys))]
        [RegularExpression("^[a-zA-Zء-ي ]*$", ErrorMessageResourceName = "vlaidHumanNameMsg", ErrorMessageResourceType = typeof(ModelsKeys))]
        [Display(Name = "FullName", ResourceType = typeof(ModelsKeys))]
        public string FullName { get; set; }

        [Display(Name = "ProfilePicture", ResourceType = typeof(ModelsKeys))]
        public string ProfilePicture { get; set; }
        
        public DateTime SignDate { get; set; }


        public virtual ICollection<Category> Categories { get; set; }

        public virtual ICollection<Course> Courses { get; set; }



        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}