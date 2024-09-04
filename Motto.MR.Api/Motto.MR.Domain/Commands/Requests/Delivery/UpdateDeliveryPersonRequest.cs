using Motto.MR.Shared.Models;

namespace Motto.MR.Domain.Commands.Requests.Delivery
{
    public class UpdateDeliveryPersonRequest
    {
        public UpdateDeliveryPersonRequest()
        {
        }
        public string UserIdentifier { get; set; }
        public int Id { get; set; }
        public DeliveryPerson DeliveryPerson { get; set; }
    }
}
