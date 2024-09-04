
namespace Motto.MR.Shared.Models
{
    public class Rental
    {
        public int Id { get; private set; }
        public int MotorcycleId { get; set; }
        public Motorcycle Motorcycle { get; set; }
        public int DeliveryPersonId { get; set; }
        public DeliveryPerson DeliveryPerson { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime ExpectedEndDate { get; set; }
        public decimal Cost { get; set; }
        public decimal Fine { get; set; }

        public void SetId(int id)
        {
            Id = id;
        }
    }
}
