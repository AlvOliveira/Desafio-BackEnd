using Motto.MR.Shared.Models;

namespace Motto.MR.Domain.Commands.Requests.Delivery
{
    public class CreateDeliveryPersonRequest
    {
        public CreateDeliveryPersonRequest()
        {
        }
        public DeliveryPerson DeliveryPerson { get; set; }
    }
}
