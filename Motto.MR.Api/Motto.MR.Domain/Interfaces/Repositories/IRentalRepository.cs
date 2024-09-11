using Motto.MR.Shared.Models;

namespace Motto.MR.Domain.Interfaces.Repositories
{
    public interface IRentalRepository
    {
        List<Rental> GetAllAsNoTracking();
        void Create(RentalOperation rental);
        void Update(int id, RentalOperation rental);
        void Delete(int id);
        Rental GetById(int id);
    }
}
