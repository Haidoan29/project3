using Project3_nhom4.Data;
using Project3_nhom4.Models;

namespace Project3_nhom4.Repository
{
    public interface IReservationSuperFastFeeRepository : IBaseRepository<ReservationSuperFastFee>
    {

    }
    public class ReservationSuperFastFeeRepository : BaseRepository<ReservationSuperFastFee>, IReservationSuperFastFeeRepository
    {
        public ReservationSuperFastFeeRepository(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor) : base(context, httpContextAccessor)
        {
        }
    }
}
