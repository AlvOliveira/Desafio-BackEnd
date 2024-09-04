
namespace Motto.MR.Domain.Commands.Requests.Delivery
{
    public class GetByIdDeliveryPersonRequest
    {
        public GetByIdDeliveryPersonRequest() 
        {
        }
        public string UserIdentifier { get; set; }
        public int Id { get; set; }
    }
}
