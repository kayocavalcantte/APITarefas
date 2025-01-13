using APITarefas.Dtos.TipoAtividade;
using APITarefas.Models;

namespace APITarefas.Repository.TipoAtividade
{
    public interface ITipoAtividadeRepository
    {
        Task<ResponseModel<List<TipoAtividadeModel>>> GetTipoAtividade();
        Task<ResponseModel<TipoAtividadeModel>> GetTipoAtividadeId(int idTpAtividade);
        Task<ResponseModel<TipoAtividadeModel>> EditarTipoAtividade(TipoAtividadeEditDTO tipoAtividadeEditDTO);
        Task<ResponseModel<TipoAtividadeModel>> DeletarTipoAtividade(int idTpAtividade);
        Task<ResponseModel<TipoAtividadeModel>> CreateTipoAtividade(TipoAtividadeCreateDTO tipoAtividadeCreateDTO);


    }
}
