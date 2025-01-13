using APITarefas.Dtos.Atividade;
using APITarefas.Models;

namespace APITarefas.Services.Atividade
{
    public interface IAtividadesService
    {
        Task<ResponseModel<List<AtividadeModel>>> GetAtividade();
        Task<ResponseModel<AtividadeModel>> GetAtividadeId(int idAtividade);
        Task<ResponseModel<AtividadeModel>> EditarAtividade(AtividadeEditDTO atividadeEditDTO);
        Task<ResponseModel<AtividadeModel>> DeletarAtividade(int idAtividade);
        Task<ResponseModel<AtividadeModel>> CreateAtividade(AtividadeCreateDTO atividadeCreateDTO);

    }
}
