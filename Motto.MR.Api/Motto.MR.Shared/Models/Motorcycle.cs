
namespace Motto.MR.Shared.Models
{
    public class Motorcycle
    {
        public int Id { get; private set; }
        public string Identifier { get; set; }
        public int Year { get; set; }
        public string Model { get; set; }
        public string LicensePlate { get; set; }

        public void SetId(int id)
        {
            Id = id;
        }
    }
}
