using APITarefas.Dtos.Atividade;
using APITarefas.Models;
using APITarefas.Services.Atividade;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APITarefas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AtividadeController : ControllerBase
    {
        private readonly IAtividadesService _atividadesInterface;

        public AtividadeController(IAtividadesService atividadesInterface)
        {
            _atividadesInterface = atividadesInterface;
        }

        [HttpGet("GetAtividades")]
        public async Task<ActionResult<ResponseModel<List<AtividadeModel>>>> GetAtividades()
        {
            var atividades = await _atividadesInterface.GetAtividade();
            return Ok(atividades);
        }

        [HttpGet("GetAtividadeId")]
        public async Task<ActionResult<ResponseModel<AtividadeModel>>> GetAtividadeId(int idAtividade)
        {
            var atividade = await _atividadesInterface.GetAtividadeId(idAtividade);
            return Ok(atividade);
        }

        [HttpPost("CreateAtividade")]
        public async Task<ActionResult<ResponseModel<AtividadeModel>>> CreateAtividade(AtividadeCreateDTO atividadeCreateDTO)
        {
            var atividade = await _atividadesInterface.CreateAtividade(atividadeCreateDTO);
            return Ok(atividade);
        }

        [HttpPost("EditarAtividade")]
        public async Task<ActionResult<ResponseModel<AtividadeModel>>> EditarAtividade(AtividadeEditDTO atividadeEditDTO)
        {
            var atividade = await _atividadesInterface.EditarAtividade(atividadeEditDTO);
            return Ok(atividade);
        }

        [HttpPost("DeletarAtividade")]
        public async Task<ActionResult<ResponseModel<AtividadeModel>>> DeletarAtividade(int idAtividade)
        {
            var atividade = await _atividadesInterface.DeletarAtividade(idAtividade);
            return Ok(atividade);
        }
    }
}
