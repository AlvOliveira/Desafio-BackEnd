
namespace Motto.MR.Domain.Commands.Requests.Delivery
{
    public class DeleteDeliveryPersonRequest
    {
        public DeleteDeliveryPersonRequest()
        {
        }
        public string UserIdentifier { get; set; }
        public int Id { get; set; }
    }
}
