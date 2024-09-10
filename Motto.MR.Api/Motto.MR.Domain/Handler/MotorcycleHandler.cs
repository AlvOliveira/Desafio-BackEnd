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
            _repository.Create(command.Motorcycle);

            var rabbitMq = new RabbitMqProducerService();
            rabbitMq.SendMessage(command.Motorcycle);

            return new CommandResultDefault(true, StringConstants.SuccessMessage);
        }

        public ICommandResult Handle(UpdateMotorcycleRequest command)
        {
            _repository.Update(command.Id, command.Motorcycle);

            return new CommandResultDefault(true, StringConstants.SuccessMessage);
        }

        public ICommandResult Handle(DeleteMotorcycleRequest command)
        {
            _repository.Delete(command.Id);

            return new CommandResultDefault(true, StringConstants.SuccessMessage);
        }

        public ICommandResult Handle()
        {
            var resultList = _repository.GetAllAsNoTracking();

            return new CommandResultDefault(true, StringConstants.SuccessMessage, resultList);
        }

        public ICommandResult Handle(GetByIdMotorcycleRequest command)
        {
            var result = _repository.GetById(command.Id);

            return new CommandResultDefault(true, StringConstants.SuccessMessage, result);
        }
        public ICommandResult Handle(GetByLicensePlateMotorcycleRequest command)
        {
            var result = _repository.GetByLicensePlate(command.LicensePlate);

            if (result == null)
                return new CommandResultDefault(false, StringConstants.LicensePlateNotFound);

            return new CommandResultDefault(true, StringConstants.SuccessMessage, result);
        }
    }
}
