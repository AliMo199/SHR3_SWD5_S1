namespace HRPrac.Business.Models
{
    public class HealthBenefit
    {
        [Key]
        public int BenefitId { get; set; }
        public string PlanType { get; set; }
        public string? Info_Coverage { get; set; }
        public double Amount { get; set; }
    }
}
