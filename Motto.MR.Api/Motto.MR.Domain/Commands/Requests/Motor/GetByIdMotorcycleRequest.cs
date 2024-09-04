
namespace Motto.MR.Domain.Commands.Requests.Motor
{
    public class GetByIdMotorcycleRequest
    {
        public GetByIdMotorcycleRequest() 
        { 
        }
        public string UserIdentifier { get; set; }
        public int Id { get; set; }
    }
}
