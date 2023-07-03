using Shipping.Models;

namespace Shipping.DTO
{
    public class UpdateRepresentiveDTO
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Branch { get; set; }
        public string Governate { get; set; }
        public DiscountType type_of_discount { get; set; }
        public int  Percent { get; set; }

    }
}
