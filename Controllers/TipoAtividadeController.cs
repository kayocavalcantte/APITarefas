using APITarefas.Dtos.TipoAtividade;
using APITarefas.Models;
using APITarefas.Services.TipoAtividade;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APITarefas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoAtividadeController : ControllerBase
    {

        private readonly ITipoAtividadeService _tipoAtividadeService;

        public TipoAtividadeController(ITipoAtividadeService tipoAtividadeService) 
        {
            _tipoAtividadeService = tipoAtividadeService;
        }

        [HttpGet("GetTipoAtividade")]
        public async Task<ActionResult<ResponseModel<TipoAtividadeModel>>> GetTipoAtividade()
        { 
            var tpAtividade = await _tipoAtividadeService.GetTipoAtividade();

            return Ok(tpAtividade);
        }

        [HttpGet("GetTipoAtividadeId")]
        public async Task<ActionResult<ResponseModel<TipoAtividadeModel>>> GetTipoAtividadeId(int idAtividade)
        {
            var tpAtividade = await _tipoAtividadeService.GetTipoAtividadeId(idAtividade);
            return Ok(tpAtividade);
        }

        [HttpPost("CreateTipoAtividade")]
        public async Task<ActionResult<ResponseModel<TipoAtividadeModel>>> CreateTipoAtividade(TipoAtividadeCreateDTO tipoAtividadeCreateDTO)
        {
            var tpAtividade = await _tipoAtividadeService.CreateTipoAtividade(tipoAtividadeCreateDTO);
            return Ok(tpAtividade);
        }

        [HttpPost("EditarTipoAtividade")]
        public async Task<ActionResult<ResponseModel<TipoAtividadeModel>>> EditarTipoAtividade(TipoAtividadeEditDTO tipoAtividadeEditDTO)
        {
            var tpAtividade = await _tipoAtividadeService.EditarTipoAtividade(tipoAtividadeEditDTO);
            return Ok(tpAtividade);
         
        }

        [HttpPost("DeletarTipoAtividade")]
        public async Task<ActionResult<ResponseModel<TipoAtividadeModel>>> DeletarTipoAtividade(int idAtividade)
        {
            var tpAtividade = await _tipoAtividadeService.DeletarTipoAtividade(idAtividade);
            return Ok(tpAtividade);
        }
    }
}
