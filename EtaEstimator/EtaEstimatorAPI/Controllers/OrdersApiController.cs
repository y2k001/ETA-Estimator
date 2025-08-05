using EtaEstimatorAPI.Models;
using EtaEstimatorAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EtaEstimatorAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersApiController : ControllerBase
    {
        private readonly EtaEstimatorService _service = new EtaEstimatorService();

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult SubmitOrder([FromBody] OrderRequest request)
        {
            var saved = OrderService.SaveOrder(request.Region, request.ProductIds, _service);
            return CreatedAtAction(nameof(GetOrderById), new { id = saved.OrderId }, saved);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetAllOrders()
        {
            return Ok(OrderService.GetAllSubmittedOrders());
        }

        [HttpGet("{id}")]
        public IActionResult GetOrderById(Guid id)
        {
            var order = OrderService.GetById(id);
            return order != null ? Ok(order) : NotFound(new { Message = "Order not found." });
        }

    }
}
