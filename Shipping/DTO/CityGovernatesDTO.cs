using Shipping.Models;

namespace Shipping.DTO
{
    public class CityGovernatesDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public double Regular_Shipping { get; set; }
        public bool IsDeleted { get; set; }
        public List<Governates> Governates { get; set; }

    }
}
