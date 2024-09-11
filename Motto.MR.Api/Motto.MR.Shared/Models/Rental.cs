
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

    public class RentalOperation
    {
        public int MotorcycleId { get; set; }
        public int DeliveryPersonId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime ExpectedEndDate { get; set; }
        public decimal Cost { get; set; }
        public decimal Fine { get; set; }

        public Rental GetRental()
        {
            var rental = new Rental()
            {
                MotorcycleId = MotorcycleId,
                DeliveryPersonId = DeliveryPersonId,
                StartDate = StartDate,
                EndDate = EndDate,
                ExpectedEndDate = ExpectedEndDate,
                Cost = Cost,
                Fine = Fine
            };

            return rental;
        }
    }
}
