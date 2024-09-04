
namespace Motto.MR.Domain.Commands.Requests.Rent
{
    public class DeleteRentalRequest
    {
        public DeleteRentalRequest()
        {
        }
        public string UserIdentifier { get; set; }
        public int Id { get; set; }
    }
}
