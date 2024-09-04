using Motto.MR.Domain.Interfaces.Repositories;
using Motto.MR.Shared.Commands;
using Motto.MR.Shared.Commands.Request;
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

        public ICommandResult Handle(GetAllMotorcycleRegisterLogsRequest command)
        {
            if (command.UserIdentifier.ToLower().Trim() != "admin")
                return new CommandResultDefault(false, StringConstants.ErrorUserMessage);

            var resultList = _repository.GetAllAsNoTracking();

            return new CommandResultDefault(true, StringConstants.SuccessMessage, resultList);
        }

    }
}
