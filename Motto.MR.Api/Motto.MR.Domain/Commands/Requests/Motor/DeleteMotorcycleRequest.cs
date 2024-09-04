
namespace Motto.MR.Domain.Commands.Requests.Motor
{
    public class DeleteMotorcycleRequest
    {
        public DeleteMotorcycleRequest()
        {
        }
        public string UserIdentifier { get; set; }
        public int Id { get; set; }
    }
}
