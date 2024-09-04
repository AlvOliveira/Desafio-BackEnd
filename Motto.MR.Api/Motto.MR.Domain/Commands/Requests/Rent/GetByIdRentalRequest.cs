
namespace Motto.MR.Domain.Commands.Requests.Rent
{
    public class GetByIdRentalRequest
    {
        public GetByIdRentalRequest() 
        { 
        }
        public string UserIdentifier { get; set; }
        public int Id { get; set; }
    }
}
