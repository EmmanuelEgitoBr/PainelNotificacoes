using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealTimeNotificationApp.Application.Dtos;
using RealTimeNotificationApp.Application.Interfaces;

namespace RealTimeNotificationApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IDeliveryService _deliveryService;

        public PedidoController(IOrderService orderService, IDeliveryService deliveryService)
        {
            _orderService = orderService;
            _deliveryService = deliveryService;
        }

        [HttpGet("resumo-completo/{numeroPedido}")]
        public async Task<ActionResult<FinalOrderDto>> Get(string numeroPedido)
        {
            var cancellationToken = CancellationToken.None;

            var order = await _orderService.GetOrder(numeroPedido, cancellationToken);
            var delivery = await _deliveryService.GetDelivery(numeroPedido, cancellationToken);

            var totalOrder = new FinalOrderDto
            {
                Pedido = order,
                Entrega = delivery
            };

            return Ok(totalOrder);
        }

        [HttpPost("registrar-pedido")]
        public async Task<ActionResult<FinalOrderDto>> Post([FromBody] OrderDto orderDto)
        {
            var cancellationToken = CancellationToken.None;
            
            var pedido = await _orderService.RegisterOrder(orderDto
                                                            , cancellationToken);
            
            var entrega = await _deliveryService.RegisterDelivery(pedido.NumeroPedido
                                                                        , pedido.CriadoEm
                                                                        , cancellationToken);

            FinalOrderDto orderResult = new FinalOrderDto
            {
                Pedido = pedido,
                Entrega = entrega
            };

            return Ok(orderResult);
        }

        [HttpPut("alterar-status/{statusFinal}")]
        public async Task<ActionResult> Put([FromBody] DeliveryDto deliveryDto, int statusFinal)
        {
            var cancellationToken = CancellationToken.None;
            var deliveryResult = await _deliveryService.UpdateStatusDelivery(deliveryDto, 
                                                                            statusFinal,
                                                                            cancellationToken);

            if (deliveryResult == null) { return BadRequest("Erro ao atualizar Status de entrega"); }

            return Ok("Status de entrega atualizado com sucesso!");
        }

        [HttpDelete("apagar-pedido/{numeroPedido}")]
        public async Task<ActionResult> Delete(string numeroPedido)
        {
            await _orderService.DeleteOrder(numeroPedido);
            
            await _deliveryService.DeleteDelivery(numeroPedido);

            return Ok();
        }

    }
}
