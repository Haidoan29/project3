using Project3_nhom4.Data;
using Project3_nhom4.Models;

namespace Project3_nhom4.Repository
{
    public interface IPassengerDetailRepository : IBaseRepository<PassengerDetail>
    {

    }
    public class PassengerDetailRepository : BaseRepository<PassengerDetail>, IPassengerDetailRepository
    {
        public PassengerDetailRepository(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor) : base(context, httpContextAccessor)
        {
        }
    }
}
