using Motto.MR.Shared.Models;

namespace Motto.MR.Domain.Commands.Requests.Delivery
{
    public class UpdateDeliveryPersonRequest
    {
        public UpdateDeliveryPersonRequest()
        {
        }
        public int Id { get; set; }
        public DeliveryPerson DeliveryPerson { get; set; }
    }
}
