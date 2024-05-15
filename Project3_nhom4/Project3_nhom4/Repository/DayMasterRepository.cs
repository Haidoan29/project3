using Project3_nhom4.Data;
using Project3_nhom4.Models;

namespace Project3_nhom4.Repository
{
    public interface IDayMasterRepository : IBaseRepository<DayMaster>
    {

    }
    public class DayMasterRepository : BaseRepository<DayMaster>, IDayMasterRepository
    {
        public DayMasterRepository(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor) : base(context, httpContextAccessor)
        {
        }
    }
}
