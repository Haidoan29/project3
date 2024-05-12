using Project3_nhom4.Data;
using Project3_nhom4.Models;

namespace Project3_nhom4.Repository
{
    public interface IFareDetailRepository : IBaseRepository<FareDetail>
    {

    }
    public class FareDetailRepository : BaseRepository<FareDetail>, IFareDetailRepository
    {
        public FareDetailRepository(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor) : base(context, httpContextAccessor)
        {
        }
    }
}
