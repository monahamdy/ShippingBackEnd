using Shipping.Models;

namespace Shipping.Repository
{
    public interface IRepresentiveRepository
    {
        List<Representive> getall();
        Representive getbyid(string id);
        void update(Representive s);

        void delete(string id);

    }
}
