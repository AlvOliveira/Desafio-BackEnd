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

            foreach (var result in resultList)
            {
                if (File.Exists(result.DeliveryPerson.DriverLicenseImagePath))
                {
                    // Ler o arquivo como um array de bytes
                    byte[] imageBytes = File.ReadAllBytes(result.DeliveryPerson.DriverLicenseImagePath);

                    string ext = Path.GetExtension(result.DeliveryPerson.DriverLicenseImagePath).Replace(".", string.Empty);

                    // Converter o array de bytes para uma string base64
                    result.DeliveryPerson.DriverLicenseImageBase64 = $"data:image/{ext};base64,{Convert.ToBase64String(imageBytes)}";
                }
                else
                {
                    result.DeliveryPerson.DriverLicenseImageBase64 = $"File {result.DeliveryPerson.DriverLicenseImagePath} not found";
                }
            }

            return new CommandResultDefault(true, StringConstants.SuccessMessage, resultList);
        }

        public ICommandResult Handle(GetByIdRentalRequest command)
        {
            var result = _repository.GetById(command.Id);

            if (result != null)
            {
                if (File.Exists(result.DeliveryPerson.DriverLicenseImagePath))
                {
                    // Ler o arquivo como um array de bytes
                    byte[] imageBytes = File.ReadAllBytes(result.DeliveryPerson.DriverLicenseImagePath);

                    string ext = Path.GetExtension(result.DeliveryPerson.DriverLicenseImagePath).Replace(".", string.Empty);

                    // Converter o array de bytes para uma string base64
                    result.DeliveryPerson.DriverLicenseImageBase64 = $"data:image/{ext};base64,{Convert.ToBase64String(imageBytes)}";
                }
                else
                {
                    result.DeliveryPerson.DriverLicenseImageBase64 = $"File {result.DeliveryPerson.DriverLicenseImagePath} not found";
                }
            }
            else
            {
                return new CommandResultDefault(false, StringConstants.RegistrationNotFound);
            }

            return new CommandResultDefault(true, StringConstants.SuccessMessage, result);
        }
    }
}
