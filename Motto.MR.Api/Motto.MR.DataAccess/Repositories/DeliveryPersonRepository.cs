using Microsoft.EntityFrameworkCore;
using Motto.MR.DataAccess.Contexts;
using Motto.MR.Domain.Interfaces.Repositories;
using Motto.MR.Shared.Constants;
using Motto.MR.Shared.Models;

namespace Motto.MR.DataAccess.Repositories
{
    public class DeliveryPersonRepository : IDeliveryPersonRepository
    {
        private readonly MottoMRContext _context;

        public DeliveryPersonRepository(MottoMRContext context)
        {
            _context = context;
        }

        public void Create(DeliveryPerson deliveryPerson)
        {
            _context.DeliveryPersons.Add(deliveryPerson);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var deliveryPerson = _context.DeliveryPersons.Find(id);
            if (deliveryPerson != null)
            {
                _context.DeliveryPersons.Remove(deliveryPerson);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception(StringConstants.RegistrationNotFound);
            }
        }

        public List<DeliveryPerson> GetAllAsNoTracking()
        {
            return _context.DeliveryPersons.AsNoTracking().ToList();
        }

        public DeliveryPerson GetById(int id)
        {
            return _context.DeliveryPersons.Find(id);
        }

        public void Update(int id, DeliveryPerson deliveryPerson)
        {
            var existingDeliveryPerson = _context.DeliveryPersons.Find(id);
            if (existingDeliveryPerson != null)
            {
                deliveryPerson.SetId(id);
                deliveryPerson.SetDriverLicenseImagePath(existingDeliveryPerson.DriverLicenseImagePath);
                _context.Entry(existingDeliveryPerson).CurrentValues.SetValues(deliveryPerson);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception(StringConstants.RegistrationNotFound);
            }
        }
    }
}
