using Project3_nhom4.Data;
using Project3_nhom4.Models;

namespace Project3_nhom4.Repository
{
    public interface IDailyCashTransactionRepository : IBaseRepository<DailyCashTransaction>
    {

    }
    public class DailyCashTransactionRepository : BaseRepository<DailyCashTransaction>, IDailyCashTransactionRepository
    {
        public DailyCashTransactionRepository(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor) : base(context, httpContextAccessor)
        {
        }
    }
}
