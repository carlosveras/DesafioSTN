using DesafioSTN.Application.DTOs;
using DesafioSTN.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static DesafioSTN.Helper;


namespace DesafioSTN.WebUI.Controllers
{
    public class PedidoController : Controller
    {

        private readonly IPedidoService _pedidoService;

        public PedidoController(IPedidoService pedidoService)
        {
            _pedidoService = pedidoService;
        }

        public async Task<IActionResult> IndexAsync()
        {
            return View(await _pedidoService.GetPedidos());
        }

        [NoDirectAccess]
        public async Task<IActionResult> AddOrEdit(int id = 0)
        {
            if (id == 0)
                return View(new PedidoDTO());
            else
            {
                var transactionModel = await _pedidoService.GetPedidoById(id);
                if (transactionModel == null)
                {
                    return NotFound();
                }
                return View(transactionModel);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(int id, [Bind("Id,NomeCliente,EmailCliente")] PedidoDTO pedidoDTO)
        {
            if (ModelState.IsValid)
            {
                if (id == 0)
                    await _pedidoService.Add(pedidoDTO);
                else
                {
                    try
                    {
                        PedidoUpdateDTO pedidoUpdateDTO = new PedidoUpdateDTO();
                        await _pedidoService.Update(pedidoUpdateDTO);
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!await TransactionModelExistsAsync(pedidoDTO.Id))
                        { return NotFound(); }
                        else
                        { throw; }
                    }
                }
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", _pedidoService.GetPedidos()) });
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "AddOrEdit", pedidoDTO) });
        }

        private async Task<bool> TransactionModelExistsAsync(int id)
        {
            var pedido = await _pedidoService.GetPedidoById(id);
            if (pedido == null)
                return false;
            return true;
        }

    }
}
