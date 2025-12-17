using Application.Commands.Atualizar;
using Application.Commands.Excluir;
using Axia.Application.Queries.Listar;
using Axia.Application.Queries.ObterPorId;
using Axia.Application.Commands.Adicionar;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Axia.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VeiculosController : ControllerBase
    {
        private readonly IMediator _mediator;

        public VeiculosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [SwaggerOperation(
            Summary = "Cadastra um novo veículo",
            Description = "Recebe os dados do veículo e cadastra no sistema, retornando o Id gerado.")]
        public async Task<IActionResult> Post([FromBody] AdicionarVeiculoCommand command)
        {
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id }, null);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [SwaggerOperation(Summary = "Atualiza um veículo existente")]
        public async Task<IActionResult> Put([FromBody] AtualizarVeiculoCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [SwaggerOperation(Summary = "Consulta um veículo por Id")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _mediator.Send(new ObterVeiculoPorIdCommand(id));
            if (result is null) return NotFound();
            return Ok(result);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [SwaggerOperation(Summary = "Lista todos os veículos")]
        public async Task<IActionResult> Get()
        {
            var result = await _mediator.Send(new ListarVeiculosCommand());
            return Ok(result);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [SwaggerOperation(Summary = "Remove um veículo")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _mediator.Send(new ExcluirVeiculoCommand(id));
            return NoContent();
        }
    }
}
