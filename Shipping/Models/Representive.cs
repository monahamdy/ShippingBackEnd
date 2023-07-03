using Microsoft.AspNetCore.Identity;
using Shipping.Repository;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shipping.Models
{

    public enum DiscountType
    {
        Percent,
        Fixed
    }
    public class Representive : ApplicationUser
    {

        public DiscountType type_of_discount { get; set; }
        public int company_percantage { get; set; }

        [ForeignKey(nameof(branches))]
        public string Id_Branch { get; set; }
        public virtual Branches? branches { get; set; }
        [ForeignKey(nameof(Governates))]
        public string Id_Governate { get; set; }
        public virtual Governates? Governates { get; set; }

    }
}
