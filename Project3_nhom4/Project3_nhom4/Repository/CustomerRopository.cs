using Project3_nhom4.Data;
using Project3_nhom4.Models;

namespace Project3_nhom4.Repository
{
    public interface ICustomerRopository : IBaseRepository<Customer>
    {

    }
    public class CustomerRopository : BaseRepository<Customer>, ICustomerRopository
    {
        public CustomerRopository(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor) : base(context, httpContextAccessor)
        {
        }
    }
}
