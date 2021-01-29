using DeliverIT.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using DTO = DeliverIT.Application.DTO;

namespace DeliverIT.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContasPagarController : ControllerBase
    {
        private readonly IContaPagarApp _contaPagarApp;

        public ContasPagarController(IContaPagarApp contaPagarApp)
        {
            _contaPagarApp = contaPagarApp;                
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
             var contasPagar = await _contaPagarApp.ListarAsync();
            return Ok(contasPagar);
        }

        [HttpGet("{id}", Name = "GetContaPagar")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var contasPagar = await _contaPagarApp.ObterAsync(id);

            if (contasPagar == null)
                return NotFound();
            else
                return Ok(contasPagar);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] DTO.ContaPagar contaPagar)
        {
            if (ModelState.IsValid)
            {
                contaPagar.Id = 0;
                var contaPagarAtualizado = await _contaPagarApp.AdicionarAsync(contaPagar);
                return CreatedAtRoute("GetContaPagar", new { id = contaPagarAtualizado.Id }, contaPagarAtualizado);
            }
            else
            {
                return BadRequest(ModelState);
            }            
        }

    }
}
