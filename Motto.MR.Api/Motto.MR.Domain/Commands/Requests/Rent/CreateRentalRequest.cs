using Motto.MR.Shared.Models;

namespace Motto.MR.Domain.Commands.Requests.Rent
{
    public class CreateRentalRequest
    {
        public CreateRentalRequest()
        {
        }
        public string UserIdentifier { get; set; }
        public Rental Rental { get; set; }
    }
}
