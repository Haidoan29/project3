using Project3_nhom4.Data;
using Project3_nhom4.Models;

namespace Project3_nhom4.Repository
{
    public interface ITrainScheduleRepository : IBaseRepository<TrainSchedule>
    {

    }
    public class TrainScheduleRepository : BaseRepository<TrainSchedule>, ITrainScheduleRepository
    {
        public TrainScheduleRepository(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor) : base(context, httpContextAccessor)
        {
        }
    }
}
