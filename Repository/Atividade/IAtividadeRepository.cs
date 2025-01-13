using APITarefas.Dtos.Atividade;
using APITarefas.Models;

namespace APITarefas.Repository.Atividade
{
    public interface IAtividadeRepository
    {
        Task<ResponseModel<List<AtividadeModel>>> GetAtividade();
        Task<ResponseModel<AtividadeModel>> GetAtividadeId(int idAtividade);
        Task<ResponseModel<AtividadeModel>> EditarAtividade(AtividadeEditDTO atividadeEditDTO);
        Task<ResponseModel<AtividadeModel>> DeletarAtividade(int idAtividade);
        Task<ResponseModel<AtividadeModel>> CreateAtividade(AtividadeCreateDTO atividadeCreateDTO);
    }
}
