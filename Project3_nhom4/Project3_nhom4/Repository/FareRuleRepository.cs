using Project3_nhom4.Data;
using Project3_nhom4.Models;

namespace Project3_nhom4.Repository
{
    public interface IFareRuleRepository : IBaseRepository<FareRule>
    {

    }
    public class FareRuleRepository : BaseRepository<FareRule>, IFareRuleRepository
    {
        public FareRuleRepository(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor) : base(context, httpContextAccessor)
        {
        }
    }
}
