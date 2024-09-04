using Motto.MR.Domain.Commands.Requests.Motor;
using Motto.MR.Domain.Interfaces.Repositories;
using Motto.MR.Shared.Commands;
using Motto.MR.Shared.Constants;
using Motto.MR.Shared.Services;

namespace Motto.MR.Domain.Handler
{
    public class MotorcycleHandler
    {
        private readonly IMotorcycleRepository _repository;

        public MotorcycleHandler(IMotorcycleRepository repository)
        { 
            _repository = repository; 
        }

        public ICommandResult Handle(CreateMotorcycleRequest command)
        {
            if (command.UserIdentifier.ToLower().Trim() != "admin")
                return new CommandResultDefault(false, StringConstants.ErrorUserMessage);

            _repository.Create(command.Motorcycle);

            var rabbitMq = new RabbitMqProducerService();
            rabbitMq.SendMessage(command.Motorcycle);

            return new CommandResultDefault(true, StringConstants.SuccessMessage);
        }

        public ICommandResult Handle(UpdateMotorcycleRequest command)
        {
            if (command.UserIdentifier.ToLower().Trim() != "admin")
                return new CommandResultDefault(false, StringConstants.ErrorUserMessage);

            _repository.Update(command.Id, command.Motorcycle);

            return new CommandResultDefault(true, StringConstants.SuccessMessage);
        }

        public ICommandResult Handle(DeleteMotorcycleRequest command)
        {
            if (command.UserIdentifier.ToLower().Trim() != "admin")
                return new CommandResultDefault(false, StringConstants.ErrorUserMessage);

            _repository.Delete(command.Id);

            return new CommandResultDefault(true, StringConstants.SuccessMessage);
        }

        public ICommandResult Handle(GetAllMotorcyclesRequest command)
        {
            if (command.UserIdentifier.ToLower().Trim() != "admin")
                return new CommandResultDefault(false, StringConstants.ErrorUserMessage);

            var resultList = _repository.GetAllAsNoTracking();

            return new CommandResultDefault(true, StringConstants.SuccessMessage, resultList);
        }

        public ICommandResult Handle(GetByIdMotorcycleRequest command)
        {
            if (command.UserIdentifier.ToLower().Trim() != "admin")
                return new CommandResultDefault(false, StringConstants.ErrorUserMessage);

            var result = _repository.GetById(command.Id);

            return new CommandResultDefault(true, StringConstants.SuccessMessage, result);
        }
        public ICommandResult Handle(GetByLicensePlateMotorcycleRequest command)
        {
            if (command.UserIdentifier.ToLower().Trim() != "admin")
                return new CommandResultDefault(false, StringConstants.ErrorUserMessage);

            var result = _repository.GetByLicensePlate(command.LicensePlate);

            if (result == null)
                return new CommandResultDefault(false, StringConstants.LicensePlateNotFound);

            return new CommandResultDefault(true, StringConstants.SuccessMessage, result);
        }
    }
}
