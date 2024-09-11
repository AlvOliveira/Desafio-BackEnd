using Motto.MR.Domain.Interfaces.Repositories;
using Motto.MR.Shared.Commands;
using Motto.MR.Shared.Constants;

namespace Motto.MR.Domain.Handler
{
    public class MotorcycleRegisterLogHandler
    {
        private readonly IMotorcycleRegisterLogRepository _repository;

        public MotorcycleRegisterLogHandler(IMotorcycleRegisterLogRepository repository)
        { 
            _repository = repository; 
        }

        public ICommandResult Handle()
        {
            var resultList = _repository.GetAllAsNoTracking();

            return new CommandResultDefault(true, StringConstants.SuccessMessage, resultList);
        }

    }
}
