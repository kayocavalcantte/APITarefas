using APITarefas.Data;
using APITarefas.Dtos.Atividade;
using APITarefas.Models;
using APITarefas.Repository.Atividade;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace APITarefas.Services.Atividade
{
    public class AtividadeService : IAtividadesService
    {

        private readonly IAtividadeRepository _repository;

        public AtividadeService(IAtividadeRepository atividadeRepository)
        {
            _repository = atividadeRepository;
        }

        public async Task<ResponseModel<List<AtividadeModel>>> GetAtividade()
        {
            ResponseModel<List<AtividadeModel>> resposta = new ResponseModel<List<AtividadeModel>>();

            var repositoryResponse = await _repository.GetAtividade();

            resposta.Dados = repositoryResponse.Dados;
            resposta.Mensagem = repositoryResponse.Mensagem;
            resposta.Status = repositoryResponse.Status;

            return resposta;

        }

        public async Task<ResponseModel<AtividadeModel>> GetAtividadeId(int idAtividade)
        {
            ResponseModel<AtividadeModel> resposta = new ResponseModel<AtividadeModel>();
            var repositoryResponse = await _repository.GetAtividadeId(idAtividade);

            resposta.Dados = repositoryResponse.Dados;
            resposta.Mensagem = repositoryResponse.Mensagem;
            resposta.Status = repositoryResponse.Status;

            return resposta;

        }

        public async Task<ResponseModel<AtividadeModel>> EditarAtividade(AtividadeEditDTO atividadeEditDTO)
        {
            ResponseModel<AtividadeModel> resposta = new ResponseModel<AtividadeModel>();
            var repositoryResponse = await _repository.EditarAtividade(atividadeEditDTO);

            resposta.Dados = repositoryResponse.Dados;
            resposta.Mensagem = repositoryResponse.Mensagem;
            resposta.Status = repositoryResponse.Status;

            return resposta;

        }

        public async Task<ResponseModel<AtividadeModel>> DeletarAtividade(int idAtividade)
        {
            ResponseModel<AtividadeModel> resposta = new ResponseModel<AtividadeModel>();

            var repositoryResponse = await _repository.DeletarAtividade(idAtividade);
            
            resposta.Dados = repositoryResponse.Dados;
            resposta.Mensagem = repositoryResponse.Mensagem;
            resposta.Status = repositoryResponse.Status;

            return resposta;

        }

        public async Task<ResponseModel<AtividadeModel>> CreateAtividade(AtividadeCreateDTO atividadeCreateDTO)
        {
            ResponseModel<AtividadeModel> resposta = new ResponseModel<AtividadeModel>();
            var repositoryResponse = await _repository.CreateAtividade(atividadeCreateDTO);

            resposta.Dados = repositoryResponse.Dados;
            resposta.Mensagem = repositoryResponse.Mensagem;
            resposta.Status = repositoryResponse.Status;

            return resposta;

        }
    }
}
