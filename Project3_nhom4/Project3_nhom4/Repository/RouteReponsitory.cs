using Project3_nhom4.Data;
using Project3_nhom4.Models;

namespace Project3_nhom4.Repository
{
    public interface IRouteReponsitory : IBaseRepository<Routes>
    {

    }
    public class RouteReponsitory : BaseRepository<Routes>, IRouteReponsitory
    {
        public RouteReponsitory(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor) : base(context, httpContextAccessor)
        {
        }
    }
}
