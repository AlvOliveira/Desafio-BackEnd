using Microsoft.EntityFrameworkCore;
using Motto.MR.DataAccess.Contexts;
using Motto.MR.Domain.Interfaces.Repositories;
using Motto.MR.Shared.Constants;
using Motto.MR.Shared.Models;

namespace Motto.MR.DataAccess.Repositories
{
    public class MotorcycleRepository : IMotorcycleRepository
    {
        private readonly MottoMRContext _context;

        public MotorcycleRepository(MottoMRContext context)
        {
            _context = context;
        }

        public void Create(Motorcycle motorcycle)
        {
            var exists = _context.Motorcycles.Any(m => m.LicensePlate == motorcycle.LicensePlate);
            if (exists)
            {
                throw new Exception("The motorcycle with this LicensePlate is already registered.");
            }

            _context.Motorcycles.Add(motorcycle);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var motorcycle = _context.Motorcycles.Find(id);
            if (motorcycle != null)
            {
                _context.Motorcycles.Remove(motorcycle);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception(StringConstants.RegistrationNotFound);
            }
        }

        public List<Motorcycle> GetAllAsNoTracking()
        {
            return _context.Motorcycles.AsNoTracking().ToList();
        }

        public Motorcycle GetById(int id)
        {
            return _context.Motorcycles.Find(id);
        }

        public Motorcycle GetByLicensePlate(string LicensePlate)
        {
            return _context.Motorcycles.FirstOrDefault(mt => mt.LicensePlate == LicensePlate);
        }

        public void Update(int id, Motorcycle motorcycle)
        {
            var existingMotorcycle = _context.Motorcycles.Find(id);
            if (existingMotorcycle != null)
            {
                motorcycle.SetId(existingMotorcycle.Id);
                _context.Entry(existingMotorcycle).CurrentValues.SetValues(motorcycle);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception(StringConstants.RegistrationNotFound);
            }
        }
    }

}
