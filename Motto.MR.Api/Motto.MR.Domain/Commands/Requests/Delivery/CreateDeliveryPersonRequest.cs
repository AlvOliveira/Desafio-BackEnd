using Motto.MR.Shared.Models;

namespace Motto.MR.Domain.Commands.Requests.Delivery
{
    public class CreateDeliveryPersonRequest
    {
        public CreateDeliveryPersonRequest()
        {
        }
        public string UserIdentifier { get; set; }
        public DeliveryPerson DeliveryPerson { get; set; }
    }
}
