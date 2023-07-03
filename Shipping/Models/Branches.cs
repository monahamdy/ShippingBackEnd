using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace Shipping.Models
{
    public class Branches
    {
        private string GenerateUniqueId()
        {
            Guid guid = Guid.NewGuid();
            return guid.ToString();
        }
        public Branches()
        {
            Id = GenerateUniqueId();
        }
        [Key]

        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public bool IsDeleted { get; set; }
        [ForeignKey(nameof(city))]
        public string? Id_city { get; set; }
        public virtual Cities? city { get; set; }
        //public virtual ICollection<Trader>? traders { get; set; }
        //public virtual ICollection<Employee>? employees { get; set; }
        //public virtual Order? order { get; set; }
        public virtual ICollection<Representive>? representive { get; set; }

    }
}
