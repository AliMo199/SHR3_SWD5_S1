using HRPrac.Business.Models;

namespace HRPrac.Business.Interfaces
{
    public interface IHealthBenefitRepository
    {
        List<HealthBenefit> GetAll();
    }
}