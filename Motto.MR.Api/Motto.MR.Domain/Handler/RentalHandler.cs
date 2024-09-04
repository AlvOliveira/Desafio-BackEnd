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
            if (command.UserIdentifier.ToLower().Trim()!="admin")
                return new CommandResultDefault(false, StringConstants.ErrorUserMessage);

            _repository.Create(command.Rental);

            return new CommandResultDefault(true, StringConstants.SuccessMessage);
        }

        public ICommandResult Handle(UpdateRentalRequest command)
        {
            if (command.UserIdentifier.ToLower().Trim() != "admin")
                return new CommandResultDefault(false, StringConstants.ErrorUserMessage);

            _repository.Update(command.Id, command.Rental);

            return new CommandResultDefault(true, StringConstants.SuccessMessage);
        }

        public ICommandResult Handle(DeleteRentalRequest command)
        {
            if (command.UserIdentifier.ToLower().Trim() != "admin")
                return new CommandResultDefault(false, StringConstants.ErrorUserMessage);

            _repository.Delete(command.Id);

            return new CommandResultDefault(true, StringConstants.SuccessMessage);
        }

        public ICommandResult Handle(GetAllRentalsRequest command)
        {
            if (command.UserIdentifier.ToLower().Trim() != "admin")
                return new CommandResultDefault(false, StringConstants.ErrorUserMessage);

            var resultList = _repository.GetAllAsNoTracking();

            return new CommandResultDefault(true, StringConstants.SuccessMessage, resultList);
        }

        public ICommandResult Handle(GetByIdRentalRequest command)
        {
            if (command.UserIdentifier.ToLower().Trim() != "admin")
                return new CommandResultDefault(false, StringConstants.ErrorUserMessage);

            var result = _repository.GetById(command.Id);

            return new CommandResultDefault(true, StringConstants.SuccessMessage, result);
        }
    }
}
