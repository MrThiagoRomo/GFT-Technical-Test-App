using GFT_Technical_Test_App.ApplicationService;
using GFT_Technical_Test_App.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace GFT_Technical_Test_App2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {

        private readonly IOrderAppService _orderAppService;

        public OrdersController(IOrderAppService orderAppService)
        {
            this._orderAppService = orderAppService;
        }

        [HttpPost]
        public Post PostOrder([FromBody] Post post)
        {
            return _orderAppService.OrderWorkflow(post);
        }

    }
}
