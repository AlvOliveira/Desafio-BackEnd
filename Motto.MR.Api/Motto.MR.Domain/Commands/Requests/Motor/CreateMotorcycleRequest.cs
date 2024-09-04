using Motto.MR.Shared.Models;

namespace Motto.MR.Domain.Commands.Requests.Motor
{
    public class CreateMotorcycleRequest
    {
        public CreateMotorcycleRequest()
        {
        }
        public string UserIdentifier { get; set; }
        public Motorcycle Motorcycle { get; set; }
    }
}
