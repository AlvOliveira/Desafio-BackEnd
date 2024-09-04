using Microsoft.EntityFrameworkCore;
using Motto.MR.DataAccess.Contexts;
using Motto.MR.Domain.Interfaces.Repositories;
using Motto.MR.Shared.Models;

namespace Motto.MR.DataAccess.Repositories
{
    public class MotorcycleRegisterLogRepository : IMotorcycleRegisterLogRepository
    {
        private readonly MottoMRContext _context;

        public MotorcycleRegisterLogRepository(MottoMRContext context)
        {
            _context = context;
        }

        public void Create(MotorcycleRegisterLog motorcycleRegisterLog)
        {
            var exists = _context.MotorcycleRegisterLogs.Any(m => m.LicensePlate == motorcycleRegisterLog.LicensePlate);
            if (exists)
            {
                throw new Exception("The motorcycle with this LicensePlate is already registered.");
            }

            _context.MotorcycleRegisterLogs.Add(motorcycleRegisterLog);
            _context.SaveChanges();
        }

        public List<MotorcycleRegisterLog> GetAllAsNoTracking()
        {
            return _context.MotorcycleRegisterLogs.AsNoTracking().ToList();
        }

    }

}
