using Motto.MR.Shared.Models;

namespace Motto.MR.Domain.Interfaces.Repositories
{
    public interface IDeliveryPersonRepository
    {
        List<DeliveryPerson> GetAllAsNoTracking();
        void Create(DeliveryPerson deliveryPerson);
        void Update(int id, DeliveryPerson deliveryPerson);
        void Delete(int id);
        DeliveryPerson GetById(int id);
    }
}
