using APITarefas.Data;
using APITarefas.Dtos.TipoAtividade;
using APITarefas.Models;
using APITarefas.Repository.TipoAtividade;

namespace APITarefas.Services.TipoAtividade
{
    public class TipoAtividadeService : ITipoAtividadeService
    {
       
        private readonly ITipoAtividadeRepository _repository;
        

        public TipoAtividadeService(ITipoAtividadeRepository repository )
        {
            _repository = repository;
        }

        public async Task<ResponseModel<List<TipoAtividadeModel>>> GetTipoAtividade()
        {
            ResponseModel<List<TipoAtividadeModel>> resposta = new ResponseModel<List<TipoAtividadeModel>>();
            var respostaRepository = await _repository.GetTipoAtividade();

            resposta.Dados = respostaRepository.Dados;
            resposta.Mensagem = respostaRepository.Mensagem;
            return resposta;
            
        }
        public async Task<ResponseModel<TipoAtividadeModel>> GetTipoAtividadeId(int idTpAtividade)
        {
            ResponseModel<TipoAtividadeModel> resposta = new ResponseModel<TipoAtividadeModel>();
            var respostaRepository = await _repository.GetTipoAtividadeId(idTpAtividade);

            resposta.Dados = respostaRepository.Dados;
            resposta.Mensagem = respostaRepository.Mensagem;
            return resposta;


        }
        public async Task<ResponseModel<TipoAtividadeModel>> EditarTipoAtividade(TipoAtividadeEditDTO tipoAtividadeEditDTO)
        {
            ResponseModel<TipoAtividadeModel> resposta = new ResponseModel<TipoAtividadeModel>();
            var respostaRepository = await _repository.EditarTipoAtividade(tipoAtividadeEditDTO);

            resposta.Dados = respostaRepository.Dados;
            resposta.Mensagem = respostaRepository.Mensagem;
            return resposta;


        }

        public async Task<ResponseModel<TipoAtividadeModel>> DeletarTipoAtividade(int idTpAtividade)
        {
            ResponseModel<TipoAtividadeModel> resposta = new ResponseModel<TipoAtividadeModel>();
            var respostaRepository = await _repository.DeletarTipoAtividade(idTpAtividade);

            resposta.Dados = respostaRepository.Dados;
            resposta.Mensagem = respostaRepository.Mensagem;
            return resposta;
        }

        public async Task<ResponseModel<TipoAtividadeModel>> CreateTipoAtividade(TipoAtividadeCreateDTO tipoAtividadeCreateDTO)
        {
            ResponseModel<TipoAtividadeModel> resposta = new ResponseModel<TipoAtividadeModel>();
            var respostaRepository = await _repository.CreateTipoAtividade(tipoAtividadeCreateDTO);

            resposta.Dados = respostaRepository.Dados;
            resposta.Mensagem = respostaRepository.Mensagem;
            return resposta;
        }
    }
}
