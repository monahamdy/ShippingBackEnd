using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Shipping.Models
{
    public class ApplicationUser: IdentityUser
    {
        [Required]
        public string Address { get; set; }
        public bool IsDeleted { get; set; } = false ;


        //[ForeignKey(nameof(branches))]
        //public string Id_Branch { get; set; }
        //public virtual Branches? branches { get; set; }
        //[ForeignKey(nameof(Governates))]
        //public string Id_Governate { get; set; }
        //public virtual Governates? Governates { get; set; }
    }
}




