using Microsoft.EntityFrameworkCore;
using Motto.MR.DataAccess.Contexts;
using Motto.MR.Domain.Interfaces.Repositories;
using Motto.MR.Shared.Constants;
using Motto.MR.Shared.Models;

namespace Motto.MR.DataAccess.Repositories
{
    public class RentalRepository : IRentalRepository
    {
        private readonly MottoMRContext _context;

        public RentalRepository(MottoMRContext context)
        {
            _context = context;
        }

        public void Create(RentalOperation rental)
        {
            _context.Rentals.Add(rental.GetRental());
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var rental = _context.Rentals.Find(id);
            if (rental != null)
            {
                _context.Rentals.Remove(rental);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception(StringConstants.RegistrationNotFound);
            }

        }

        public List<Rental> GetAllAsNoTracking()
        {
            return _context.Rentals
                           .Include(r => r.Motorcycle)
                           .Include(r => r.DeliveryPerson)
                           .AsNoTracking()
                           .ToList();
        }

        public Rental GetById(int id)
        {
            return _context.Rentals
                           .Include(r => r.Motorcycle)
                           .Include(r => r.DeliveryPerson)
                           .FirstOrDefault(r => r.Id == id);
        }

        public void Update(int id, RentalOperation rentalOperation)
        {
            var existingRental = _context.Rentals.Find(id);
            if (existingRental != null)
            {
                var motorcycle = _context.Motorcycles.Find(rentalOperation.MotorcycleId);
                var deliveryPerson = _context.DeliveryPersons.Find(rentalOperation.DeliveryPersonId);

                var rental = rentalOperation.GetRental();

                rental.SetId(existingRental.Id);
                rental.Motorcycle = motorcycle;
                rental.DeliveryPerson = deliveryPerson;

                _context.Entry(existingRental).CurrentValues.SetValues(rental);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception(StringConstants.RegistrationNotFound);
            }
        }
    }
}
