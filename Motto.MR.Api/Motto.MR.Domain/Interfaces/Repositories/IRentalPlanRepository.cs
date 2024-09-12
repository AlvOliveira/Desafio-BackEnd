using Motto.MR.Shared.Models;

namespace Motto.MR.Domain.Interfaces.Repositories
{
    public interface IRentalPlanRepository
    {
        List<RentalPlan> GetAllAsNoTracking();
        void Create(RentalPlanOperation rentalPlanOperation);
        void Update(int id, RentalPlanOperation rentalOperation);
        void Delete(int id);
        RentalPlan GetById(int id);
    }
}
