
namespace Motto.MR.Shared.Models
{
    public class Rental
    {
        public int Id { get; private set; }
        public int MotorcycleId { get; set; }
        public Motorcycle Motorcycle { get; set; }
        public int DeliveryPersonId { get; set; }
        public int RentalPlanId { get; set; }
        public RentalPlan RentalPlan { get; set; }
        public DeliveryPerson DeliveryPerson { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime ExpectedEndDate { get; set; }
        public decimal TotalRentalCost { get; set; }
        public decimal TotalFines { get; set; }

        public void SetId(int id)
        {
            Id = id;
        }
    }

    public class RentalOperation
    {
        public int MotorcycleId { get; set; }
        public int DeliveryPersonId { get; set; }
        public int RentalPlanId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime ExpectedEndDate { get; set; }
        public decimal TotalRentalCost { get; set; }
        public decimal TotalFines { get; set; }

        public Rental GetRental(int id)
        {
            var rental = new Rental()
            {
                MotorcycleId = MotorcycleId,
                DeliveryPersonId = DeliveryPersonId,
                RentalPlanId = RentalPlanId,
                StartDate = StartDate,
                EndDate = EndDate,
                ExpectedEndDate = ExpectedEndDate,
                TotalRentalCost = TotalRentalCost,
                TotalFines = TotalFines
            };

            rental.SetId(id);

            return rental;
        }
    }
}
