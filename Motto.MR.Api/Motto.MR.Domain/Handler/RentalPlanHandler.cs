using Motto.MR.Domain.Commands.Requests.Rent;
using Motto.MR.Domain.Interfaces.Repositories;
using Motto.MR.Shared.Commands;
using Motto.MR.Shared.Constants;

namespace Motto.MR.Domain.Handler
{
    public class RentalPlanHandler
    {
        private readonly IRentalPlanRepository _repository;

        public RentalPlanHandler(IRentalPlanRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handle(CreateRentalPlanRequest command)
        {
            _repository.Create(command.RentalPlanOperation);

            return new CommandResultDefault(true, StringConstants.SuccessMessage);
        }

        public ICommandResult Handle(UpdateRentalPlanRequest command)
        {
            _repository.Update(command.Id, command.RentalPlanOperation);

            return new CommandResultDefault(true, StringConstants.SuccessMessage);
        }

        public ICommandResult Handle(DeleteRentalPlanRequest command)
        {
            _repository.Delete(command.Id);

            return new CommandResultDefault(true, StringConstants.SuccessMessage);
        }

        public ICommandResult Handle()
        {
            var resultList = _repository.GetAllAsNoTracking();

            return new CommandResultDefault(true, StringConstants.SuccessMessage, resultList);
        }

        public ICommandResult Handle(GetByIdRentalPlanRequest command)
        {
            var result = _repository.GetById(command.Id);

            if (result == null)
            {
                return new CommandResultDefault(false, StringConstants.RegistrationNotFound);
            }

            return new CommandResultDefault(true, StringConstants.SuccessMessage, result);
        }
    }
}
