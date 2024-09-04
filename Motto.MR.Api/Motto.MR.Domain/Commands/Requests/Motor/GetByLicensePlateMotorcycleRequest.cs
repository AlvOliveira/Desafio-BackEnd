
namespace Motto.MR.Domain.Commands.Requests.Motor
{
    public class GetByLicensePlateMotorcycleRequest
    {
        public GetByLicensePlateMotorcycleRequest() 
        { 
        }
        public string UserIdentifier { get; set; }
        public string LicensePlate { get; set; }
    }
}
