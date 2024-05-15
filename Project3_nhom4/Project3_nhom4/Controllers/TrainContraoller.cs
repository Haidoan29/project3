using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project3_nhom4.Models;
using Project3_nhom4.Repository;

namespace Project3_nhom4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainContraoller : BaseController<Train>
    {
        public TrainContraoller(IBaseRepository<Train> repository) : base(repository)
        {
        }
    }
}
