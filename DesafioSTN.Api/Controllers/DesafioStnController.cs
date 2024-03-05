using DesafioSTN.Application.DTOs;
using DesafioSTN.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;

namespace DesafioSTN.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DesafioStnController : ControllerBase
    {
        private readonly IPedidoService _pedidoService;
 
        public DesafioStnController(IPedidoService pedidoService)
        {
            _pedidoService = pedidoService;
        }

        /// <summary>
        /// Obter todos os pedidos
        /// </summary>
        /// <returns>Coleção de pedidos</returns>
        /// <response code="200">OK</response>
        /// <response code="500">InternalServerError</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> GetAll()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                return Ok(await _pedidoService.GetPedidos());
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Obter um Pedido
        /// </summary>
        /// <remarks>
        /// {"Id": "int"}
        /// </remarks>
        /// <param name="id">Identificador do pedido</param>
        /// <returns>Dados do pedido</returns>
        /// <response code="200">OK</response>
        /// <response code="404">NotFound</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> GetById(int id)
        {
            var pedido = await _pedidoService.GetPedidoById(id);

            if (pedido == null)
                return NotFound("Pedido inexistente");

            return Ok(pedido);
        }

        /// <summary>
        /// Inserir um pedido
        /// </summary>
        /// <remarks>
        /// {"id": 0, "nomeCliente": "string", "emailCliente": "user@example.com","pago": true,"valorTotal": 0}
        /// </remarks>
        /// <param name="pedidoCreateDTO"></param>
        /// <returns>Objeto recém-criado</returns>
        /// <response code="201">Created</response>
        /// <response code="500">InternalServerError</response>
        [HttpPost("Pedido")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<PedidoDTO>> Add(PedidoCreateDTO pedidoCreateDTO)
        {
            if (ModelState.IsValid)
            {
                var novoPedido = await _pedidoService.Create(pedidoCreateDTO);
                return Ok(novoPedido);
            }
            return StatusCode(500, "Internal Server Error");
        }

        /// <summary>
        /// Alterar um pedido
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <returns>Objeto recém-criado</returns>
        /// <response code="201">Sucesso</response>
        /// <response code="404">Não encontrado</response>
        /// <response code="400">Bad Request</response>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Put(PedidoUpdateDTO pedidoUpdateDto)
        {
            if (ModelState.IsValid)
            {
                var pedido = await _pedidoService.GetPedidoById(pedidoUpdateDto.Id);

                if (pedido == null)
                    return NotFound("Pedido não encontrado");

                await _pedidoService.Update(pedidoUpdateDto);
                return Ok(pedidoUpdateDto);
            }
            return StatusCode(400, "Bad Request");
        }


        /// <summary>
        /// Excluir um Pedido
        /// </summary>
        /// <remarks>
        /// {"Id": "int"}
        /// </remarks>
        /// <param name="id">Identificador do pedido</param>
        /// <returns>Dados do pedido</returns>
        /// <response code="200">OK</response>
        /// <response code="404">NotFound</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteById(int id)
        {
            var pedido = await _pedidoService.GetPedidoById(id);

            if (pedido == null)
                return NotFound("Pedido inexistente");

            await _pedidoService.Remove(id);

            return Ok("Pedido excluido com sucesso");
        }

    }
}