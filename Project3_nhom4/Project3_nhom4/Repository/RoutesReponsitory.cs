using Project3_nhom4.Data;
using Project3_nhom4.Models;

namespace Project3_nhom4.Repository
{
    public interface IRouteReponsitory : IBaseRepository<Routes>
    {

    }
    public class RoutesReponsitory : BaseRepository<Routes>, IRouteReponsitory
    {
        public RoutesReponsitory(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor) : base(context, httpContextAccessor)
        {
        }
    }
}
