using Project3.Data;
using Project3.Models;

namespace Project3.Repository
{
    public interface IRoutesReponsitory : IBaseRepository<Routers>
    {

    }
    public class RoutesReponsitory : BaseRepository<Routers>, IRoutesReponsitory
    {
        public RoutesReponsitory(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor) : base(context, httpContextAccessor)
        {
        }
    }
}
