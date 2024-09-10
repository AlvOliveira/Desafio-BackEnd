using Motto.MR.Shared.Models;

namespace Motto.MR.Domain.Commands.Requests.Motor
{
    public class UpdateMotorcycleRequest
    {
        public UpdateMotorcycleRequest()
        {
        }
        public int Id { get; set; }
        public Motorcycle Motorcycle { get; set; }
    }
}
