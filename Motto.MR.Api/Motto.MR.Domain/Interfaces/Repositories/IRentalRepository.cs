using Motto.MR.Shared.Models;

namespace Motto.MR.Domain.Interfaces.Repositories
{
    public interface IRentalRepository
    {
        List<Rental> GetAllAsNoTracking();
        void Create(Rental rental);
        void Update(int id, Rental rental);
        void Delete(int id);
        Rental GetById(int id);
    }
}
