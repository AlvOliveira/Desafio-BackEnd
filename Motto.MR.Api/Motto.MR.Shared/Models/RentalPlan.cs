
namespace Motto.MR.Shared.Models
{
    public class RentalPlan
    {
        public int Id { get; set; }
        public int Days { get; set; }
        public decimal DailyCost { get; set; }
        public decimal? PenaltyPercentage { get; set; }
        public decimal AdditionalDailyCost { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }

        public void SetId(int id)
        {
            this.Id = id;
        }
    }

    public class RentalPlanOperation
    {
        public int Days { get; set; }
        public decimal DailyCost { get; set; }
        public decimal? PenaltyPercentage { get; set; }
        public decimal AdditionalDailyCost { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }

        public RentalPlan GetRentalPlan(int id)
        {
            var RentalPlan = new RentalPlan()
            {
                Id = id,
                Days = Days,
                DailyCost = DailyCost,
                PenaltyPercentage = PenaltyPercentage,
                AdditionalDailyCost = AdditionalDailyCost,
                Created = Created,
                Updated = Updated

            };
            
            return RentalPlan;
        }
    }
}
