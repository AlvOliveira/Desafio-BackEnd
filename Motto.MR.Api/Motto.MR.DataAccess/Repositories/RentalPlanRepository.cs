using Microsoft.EntityFrameworkCore;
using Motto.MR.DataAccess.Contexts;
using Motto.MR.Domain.Interfaces.Repositories;
using Motto.MR.Shared.Constants;
using Motto.MR.Shared.Models;

namespace Motto.MR.DataAccess.Repositories
{
    public class RentalPlanRepository : IRentalPlanRepository
    {
        private readonly MottoMRContext _context;

        public RentalPlanRepository(MottoMRContext context)
        {
            _context = context;
        }

        public void Create(RentalPlanOperation rentalPlanOperation)
        {
            _context.RentalPlans.Add(rentalPlanOperation.GetRentalPlan(0));
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var rentalPlan = _context.RentalPlans.Find(id);
            if (rentalPlan != null)
            {
                _context.RentalPlans.Remove(rentalPlan);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception(StringConstants.RegistrationNotFound);
            }

        }

        public List<RentalPlan> GetAllAsNoTracking()
        {
            return _context.RentalPlans
                           .AsNoTracking()
                           .ToList();
        }

        public RentalPlan GetById(int id)
        {
            return _context.RentalPlans
                           .FirstOrDefault(r => r.Id == id);
        }

        public void Update(int id, RentalPlanOperation rentalPlanOperation)
        {
            var existingRentalPlan = _context.RentalPlans.Find(id);
            if (existingRentalPlan != null)
            {
                var rentalPlan = rentalPlanOperation.GetRentalPlan(existingRentalPlan.Id);

                _context.Entry(existingRentalPlan).CurrentValues.SetValues(rentalPlan);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception(StringConstants.RegistrationNotFound);
            }
        }
    }
}
