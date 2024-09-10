using Motto.MR.Domain.Commands.Requests.Delivery;
using Motto.MR.Domain.Interfaces.Repositories;
using Motto.MR.Shared.Commands;
using Motto.MR.Shared.Constants;
using Motto.MR.Shared.Helper;

namespace Motto.MR.Domain.Handler
{
    public class DeliveryPersonHandler
    {

        private readonly IDeliveryPersonRepository _repository;

        public DeliveryPersonHandler(IDeliveryPersonRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handle(CreateDeliveryPersonRequest command)
        {
            string directoryPath = Path.Combine(Directory.GetCurrentDirectory(), "delivery", "images");
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            var imgType = ImageType.GetImageType(command.DeliveryPerson.DriverLicenseImageBase64);

            if (string.IsNullOrEmpty(imgType))
                return new CommandResultDefault(false, StringConstants.InvalidImageFormat);

            if (imgType!="png" &&  imgType!="bmp")
                return new CommandResultDefault(false, StringConstants.InvalidImageFormat);

            var base64Data = command.DeliveryPerson.DriverLicenseImageBase64.Substring(command.DeliveryPerson.DriverLicenseImageBase64.IndexOf(",") + 1);

            // Converter de Base64 para array de bytes
            byte[] imageBytes = Convert.FromBase64String(base64Data);

            string fileName = $"{Guid.NewGuid()}.{imgType}";

            string filePath = Path.Combine(directoryPath, fileName);

            command.DeliveryPerson.SetDriverLicenseImagePath(filePath);

            _repository.Create(command.DeliveryPerson);

            File.WriteAllBytes(filePath, imageBytes);

            return new CommandResultDefault(true, StringConstants.SuccessMessage);
        }

        public ICommandResult Handle(UpdateDeliveryPersonRequest command)
        {
            _repository.Update(command.Id, command.DeliveryPerson);

            return new CommandResultDefault(true, StringConstants.SuccessMessage);
        }

        public ICommandResult Handle(DeleteDeliveryPersonRequest command)
        {
            _repository.Delete(command.Id);

            return new CommandResultDefault(true, StringConstants.SuccessMessage);
        }

        public ICommandResult Handle()
        {
            var resultList = _repository.GetAllAsNoTracking();

            foreach ( var result in resultList )
            {
                if (File.Exists(result.DriverLicenseImagePath))
                {
                    // Ler o arquivo como um array de bytes
                    byte[] imageBytes = File.ReadAllBytes(result.DriverLicenseImagePath);

                    string ext = Path.GetExtension(result.DriverLicenseImagePath).Replace(".",string.Empty);

                    // Converter o array de bytes para uma string base64
                    result.DriverLicenseImageBase64 = $"data:image/{ext};base64,{Convert.ToBase64String(imageBytes)}";
                }
                else
                {
                    result.DriverLicenseImageBase64 = $"File {result.DriverLicenseImagePath} not found";
                }
            }

            return new CommandResultDefault(true, StringConstants.SuccessMessage, resultList);
        }

        public ICommandResult Handle(GetByIdDeliveryPersonRequest command)
        {
            var result = _repository.GetById(command.Id);

            if (result != null)
            {
                if (File.Exists(result.DriverLicenseImagePath))
                {
                    // Ler o arquivo como um array de bytes
                    byte[] imageBytes = File.ReadAllBytes(result.DriverLicenseImagePath);

                    string ext = Path.GetExtension(result.DriverLicenseImagePath).Replace(".", string.Empty);

                    // Converter o array de bytes para uma string base64
                    result.DriverLicenseImageBase64 = $"data:image/{ext};base64,{Convert.ToBase64String(imageBytes)}";
                }
                else
                {
                    result.DriverLicenseImageBase64 = $"File {result.DriverLicenseImagePath} not found";
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
