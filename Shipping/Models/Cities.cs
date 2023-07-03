using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace Shipping.Models
{
    public class Cities
    {
        private string GenerateUniqueId()
        {
            Guid guid = Guid.NewGuid();
            return guid.ToString();
        }
        public Cities()
        {
            Id = GenerateUniqueId();
        }
        [Key]

        public string Id { get; set; }
        public string Name { get; set; }
        public double Regular_Shipping { get; set; }
        public bool IsDeleted { get; set; }

        [ForeignKey(nameof(governates))]
        public string? Id_Governate { get; set; }
        public Governates? governates { get; set; }
        public virtual ICollection<Branches>? branches { get; set; }

        //public virtual ICollection<Trader>? traders { get; set; }
        //public virtual Order? order { get; set; }


    }
}
