using Project3_nhom4.Data;
using Project3_nhom4.Models;

namespace Project3_nhom4.Repository
{
    public interface ITrainReponsitory : IBaseRepository<Train>
    {

    }
    public class TrainReponsitory : BaseRepository<Train>, ITrainReponsitory
    {
        public TrainReponsitory(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor) : base(context, httpContextAccessor)
        {
        }
    }
}
