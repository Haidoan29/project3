using Project3_nhom4.Data;
using Project3_nhom4.Models;

namespace Project3_nhom4.Repository
{
    public interface IStationReponsitory : IBaseRepository<Station>
    {

    }
    public class StationReponsitory : BaseRepository<Station>, IStationReponsitory
    {
        public StationReponsitory(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor) : base(context, httpContextAccessor)
        {
        }
    }
}
