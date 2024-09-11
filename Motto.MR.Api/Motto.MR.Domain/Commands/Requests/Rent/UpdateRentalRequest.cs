using Motto.MR.Shared.Models;

namespace Motto.MR.Domain.Commands.Requests.Rent
{
    public class UpdateRentalRequest
    {
        public UpdateRentalRequest()
        {
        }
        public int Id { get; set; }
        public RentalOperation Rental { get; set; }
    }
}
