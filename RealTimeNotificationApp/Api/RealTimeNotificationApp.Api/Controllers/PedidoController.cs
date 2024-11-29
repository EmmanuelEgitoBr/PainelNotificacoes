using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using RealTimeNotificationApp.Api.Models;
using RealTimeNotificationApp.Api.SignalHub;
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
        private readonly IHubContext<OrderHub> _hubContext;

        public PedidoController(IOrderService orderService,
                                IDeliveryService deliveryService,
                                IHubContext<OrderHub> hubContext)
        {
            _orderService = orderService;
            _deliveryService = deliveryService;
            _hubContext = hubContext;
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

            // Enviar atualização do status para o hub
            await _hubContext.Clients.All.SendAsync(
                "ReceiveCreationNewOrder",
                pedido.NumeroPedido);

            return Ok(orderResult);
        }

        [HttpPut("alterar-status")]
        public async Task<ActionResult> Put([FromBody] UpdateStatusRequest request)
        {
            var cancellationToken = CancellationToken.None;

            var deliveryResult = await _deliveryService.UpdateStatusDelivery(request.NumeroPedido, 
                                                                            request.StatusFinal,
                                                                            cancellationToken);

            if (deliveryResult == null) { return BadRequest("Erro ao atualizar Status de entrega"); }

            // Enviar atualização do status para o hub
            await _hubContext.Clients.All.SendAsync(
                "ReceiveOrderStatusUpdate",
                deliveryResult.NumeroPedido,
                request.StatusFinal);

            return Ok("Status de entrega atualizado com sucesso!");
        }

        [HttpPut("atualizar-telefone/{telefone}/{numeroPedido}")]
        public async Task<ActionResult<OrderDto>> Put(string telefone, string numeroPedido)
        {
            var cancellationToken = CancellationToken.None;

            var orderDto = await _orderService.UpdateContactNumber(numeroPedido, telefone, cancellationToken);

            return Ok(orderDto);
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
