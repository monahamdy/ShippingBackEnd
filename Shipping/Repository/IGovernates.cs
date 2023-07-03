using Shipping.Models;

namespace Shipping.Repository
{
    public interface IGovernates
    {
        List<Governates> GetGovernates();
        Governates GetGovernates(string id);

        void Insert(Governates Governate);
        void Update(string id, Governates Governate);
        void Delete(string id);
        void Save();
    }
}
