using Motto.MR.Shared.Models;

namespace Motto.MR.Domain.Commands.Requests.Rent
{
    public class CreateRentalPlanRequest
    {
        public CreateRentalPlanRequest()
        {
        }
        public RentalPlanOperation RentalPlanOperation { get; set; }
    }
}
