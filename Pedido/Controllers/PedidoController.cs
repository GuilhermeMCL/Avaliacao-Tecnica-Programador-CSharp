using Microsoft.AspNetCore.Mvc;
using Pedido.Domain.Entities;
using Pedido.Service;

namespace Pedido.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PedidoController : ControllerBase
    {
        private readonly PedidoService _service;

        public PedidoController()
        {
            _service = new PedidoService();
        }

        [HttpPost]
        public IActionResult Criar([FromBody] Pedido.Domain.Entities.Pedido pedido)
        {
            try
            {
                var id = _service.CriarPedido(pedido);
                return Ok(new { mensagem = "Pedido criado!", id });
            }
            catch (Exception ex)
            {
                return BadRequest(new { erro = ex.Message });
            }
        }

        [HttpPut("{id}/status")]
        public IActionResult AtualizarStatus(int id, [FromBody] string status)
        {
            try
            {
                _service.AtualizarStatus(id, status);
                return Ok(new { mensagem = "Status atualizado!" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { erro = ex.Message });
            }
        }
    }
}
