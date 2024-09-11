using Motto.MR.Shared.Models;

namespace Motto.MR.Domain.Commands.Requests.Rent
{
    public class CreateRentalRequest
    {
        public CreateRentalRequest()
        {
        }
        public RentalOperation Rental { get; set; }
    }
}
