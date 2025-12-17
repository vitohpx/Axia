using Application.Commands.Atualizar;
using Application.Commands.Excluir;
using Application.Commands.Listar;
using Application.Commands.ObterPorId;
using Axia.Application.Commands.Adicionar;
using MediatR;
using Microsoft.AspNetCore.Mvc;

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

        /// <summary>
        /// Cadastra um novo veículo
        /// </summary>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post(
            [FromBody] AdicionarVeiculoCommand command)
        {

            var id = await _mediator.Send(command);

            return CreatedAtAction(
                nameof(GetById),
                new { id },
                null
            );
        }

        /// <summary>
        /// Atualiza um veículo existente
        /// </summary>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Put(
            [FromBody] AtualizarVeiculoCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        /// <summary>
        /// Consulta um veículo por Id
        /// </summary>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _mediator.Send(
                new ObterVeiculoPorIdCommand(id));

            if (result is null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Lista todos os veículos
        /// </summary>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Get()
        {
            var result = await _mediator.Send(
                new ListarVeiculosCommand());

            return Ok(result);
        }

        /// <summary>
        /// Remove um veículo
        /// </summary>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _mediator.Send(
                new ExcluirVeiculoCommand(id));

            return NoContent();
        }
    }
}
