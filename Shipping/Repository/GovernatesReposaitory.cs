using Microsoft.EntityFrameworkCore;
using Shipping.Data;
using Shipping.Models;

namespace Shipping.Repository
{
    public class GovernatesReposaitory : IGovernates
    {
        private readonly ShippingContext _shippingContext;

        public GovernatesReposaitory(ShippingContext shippingContext)
        {
            _shippingContext = shippingContext;
        }
        public void Delete(string id)
        {
            var data = GetGovernates(id);
            data.IsDeleted = true;
            Save();

        }

        public List<Governates> GetGovernates()
        {
            return _shippingContext.Governates.Where(n => n.IsDeleted == false).ToList();
        }

        public Governates GetGovernates(string id)
        {
            return _shippingContext.Governates.FirstOrDefault(n => n.Id == id);
        }

        public void Insert(Governates Governate)
        {
            _shippingContext.Governates.Add(Governate);
            Save();
        }

        public void Save()
        {
            _shippingContext.SaveChanges();
        }

        public void Update(string id, Governates Governate)
        {
            var exitstingdata=_shippingContext.Governates.Local.FirstOrDefault(e => e.Id == id);
            if (exitstingdata != null)
            {
                _shippingContext.Entry(exitstingdata).State = EntityState.Detached;
            }
            _shippingContext.Governates.Update(Governate);
            Save();
        }
    }
}
