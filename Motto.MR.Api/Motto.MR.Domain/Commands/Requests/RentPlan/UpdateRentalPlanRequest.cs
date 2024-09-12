using Motto.MR.Shared.Models;

namespace Motto.MR.Domain.Commands.Requests.Rent
{
    public class UpdateRentalPlanRequest
    {
        public UpdateRentalPlanRequest()
        {
        }
        public int Id { get; set; }
        public RentalPlanOperation RentalPlanOperation { get; set; }
    }
}
