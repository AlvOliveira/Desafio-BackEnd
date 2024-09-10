using Motto.MR.Domain.Commands.Requests.Rent;
using Motto.MR.Domain.Interfaces.Repositories;
using Motto.MR.Shared.Commands;
using Motto.MR.Shared.Constants;

namespace Motto.MR.Domain.Handler
{
    public class RentalHandler
    {
        private readonly IRentalRepository _repository;

        public RentalHandler(IRentalRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handle(CreateRentalRequest command)
        {
            _repository.Create(command.Rental);

            return new CommandResultDefault(true, StringConstants.SuccessMessage);
        }

        public ICommandResult Handle(UpdateRentalRequest command)
        {
            _repository.Update(command.Id, command.Rental);

            return new CommandResultDefault(true, StringConstants.SuccessMessage);
        }

        public ICommandResult Handle(DeleteRentalRequest command)
        {
            _repository.Delete(command.Id);

            return new CommandResultDefault(true, StringConstants.SuccessMessage);
        }

        public ICommandResult Handle()
        {
            var resultList = _repository.GetAllAsNoTracking();

            return new CommandResultDefault(true, StringConstants.SuccessMessage, resultList);
        }

        public ICommandResult Handle(GetByIdRentalRequest command)
        {
            var result = _repository.GetById(command.Id);

            return new CommandResultDefault(true, StringConstants.SuccessMessage, result);
        }
    }
}
