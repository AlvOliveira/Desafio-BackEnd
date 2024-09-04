using Motto.MR.Shared.Models;

namespace Motto.MR.Domain.Interfaces.Repositories
{
    public interface IMotorcycleRegisterLogRepository
    {
        List<MotorcycleRegisterLog> GetAllAsNoTracking();
        void Create(MotorcycleRegisterLog motorcycleRegisterLog);
    }
}
