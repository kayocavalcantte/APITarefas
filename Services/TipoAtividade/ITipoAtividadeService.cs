using APITarefas.Dtos.TipoAtividade;
using APITarefas.Models;

namespace APITarefas.Services.TipoAtividade
{
    public interface ITipoAtividadeService
    {
        Task<ResponseModel<List<TipoAtividadeModel>>> GetTipoAtividade();
        Task<ResponseModel<TipoAtividadeModel>> GetTipoAtividadeId(int idTpAtividade);
        Task<ResponseModel<TipoAtividadeModel>> EditarTipoAtividade(TipoAtividadeEditDTO tipoAtividadeEditDTO);
        Task<ResponseModel<TipoAtividadeModel>> DeletarTipoAtividade(int idTpAtividade);
        Task<ResponseModel<TipoAtividadeModel>> CreateTipoAtividade(TipoAtividadeCreateDTO tipoAtividadeCreateDTO);
    }
}
