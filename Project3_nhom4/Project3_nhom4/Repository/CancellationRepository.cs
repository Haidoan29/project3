using Project3_nhom4.Data;
using Project3_nhom4.Models;

namespace Project3_nhom4.Repository
{
    public interface ICancellationRepository : IBaseRepository<Cancellation>
    {

    }
    public class CancellationRepository : BaseRepository<Cancellation>, ICancellationRepository
    {
        public CancellationRepository(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor) : base(context, httpContextAccessor)
        {
        }
    }
}
