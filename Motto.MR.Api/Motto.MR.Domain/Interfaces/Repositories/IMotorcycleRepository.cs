using Motto.MR.Shared.Models;

namespace Motto.MR.Domain.Interfaces.Repositories
{
    public interface IMotorcycleRepository
    {
        List<Motorcycle> GetAllAsNoTracking();
        void Create(Motorcycle motorcycle);
        void Update(int id, Motorcycle motorcycle);
        void Delete(int id);
        Motorcycle GetById(int id);
        Motorcycle GetByLicensePlate(string LicensePlate);
    }
}
