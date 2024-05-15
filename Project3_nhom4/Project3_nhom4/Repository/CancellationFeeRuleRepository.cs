using Project3_nhom4.Data;
using Project3_nhom4.Models;

namespace Project3_nhom4.Repository
{
    public interface ICancellationFeeRuleRepository : IBaseRepository<CancellationFeeRule>
    {

    }
    public class CancellationFeeRuleRepository : BaseRepository<CancellationFeeRule>, ICancellationFeeRuleRepository
    {
        public CancellationFeeRuleRepository(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor) : base(context, httpContextAccessor)
        {
        }
    }
}
