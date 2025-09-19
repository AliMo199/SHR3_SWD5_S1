using HRPrac.Business.Models;
using HRPrac.Business.Interfaces;
using HRPrac.Data.Presistence;
namespace HRPrac.Data.Repository
{
    public class HealthBenefitRepository : IHealthBenefitRepository
    {
        public HRSystemDBContext _Context;
        public HealthBenefitRepository(HRSystemDBContext context)
        {
            _Context = context;
        }
        public List<HealthBenefit> GetAll()
        {
            return _Context.HealthBenefits.ToList();
        }
    }
}
