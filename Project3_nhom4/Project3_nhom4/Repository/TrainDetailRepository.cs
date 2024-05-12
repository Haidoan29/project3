using Project3_nhom4.Data;
using Project3_nhom4.Models;

namespace Project3_nhom4.Repository
{
    public interface ITrainDetailRepository : IBaseRepository<TrainDetail>
    {

    }
    public class TrainDetailRepository:BaseRepository<TrainDetail> , ITrainDetailRepository
    {
        public TrainDetailRepository(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor) : base(context, httpContextAccessor)
        {
        }
    }
}
