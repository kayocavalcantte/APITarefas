using APITarefas.Data;
using APITarefas.Dtos.Atividade;
using APITarefas.Models;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace APITarefas.Repository.Atividade
{
    public class AtividadeRepository : IAtividadeRepository
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;


        public AtividadeRepository(AppDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<ResponseModel<List<AtividadeModel>>> GetAtividade()
        {
            ResponseModel<List<AtividadeModel>> resposta = new ResponseModel<List<AtividadeModel>>();
            try
            {
                var atividades = await _context.atividade.ToListAsync();

                if (atividades.Count == 0)
                {
                    resposta.Mensagem = "Sem Atividades";
                }

                else if(atividades.Count > 0) 
                {
                    resposta.Dados = atividades;
                    resposta.Mensagem = "Atividades listas com sucesso";
                }
               
                return resposta;
            }
            catch (Exception ex) 
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }
        public async Task<ResponseModel<AtividadeModel>> GetAtividadeId(int idAtividade)
        {
            ResponseModel<AtividadeModel> resposta = new ResponseModel<AtividadeModel>();
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnections")))
            {
                //tentando executar a consulta
                try
                {
                    string query = $@"SELECT
	                                    id, tipo_atividade_id, 
	                                    descricao, data_criacao,
	                                    hora_criacao, data_alteracao,
	                                    hora_alteracao
                                    FROM 
	                                    atividades 
                                    WHERE 
	                                    id = {idAtividade};";

                    var dto = await connection.QueryFirstOrDefaultAsync<AtividadeGetByIdDTO>(query, new { id = idAtividade });

                    //verifico se o dto foi preenchido com os dados, se não foi, é porque a atividade não foi encontrada
                    if (dto == null)
                    {
                        resposta.Mensagem = "Nenhuma atividade encontrado";
                        return resposta;
                    }

                    //mapear o dto para o model após tratar os dados
                    AtividadeModel ativadadeModel = new AtividadeModel
                    {
                        id = dto.id,
                        tipo_atividade_id = dto.tipo_atividade_id,
                        descricao = dto.descricao,
                        data_criacao = DateOnly.FromDateTime(dto.data_criacao),
                        hora_criacao = dto.hora_criacao,
                        data_alteracao = DateOnly.FromDateTime(dto.data_alteracao),
                        hora_alteracao = dto.hora_alteracao
                    };

                    //após mapear, passar os dados para a resposta 
                    if (ativadadeModel == null)
                    {
                        resposta.Dados = ativadadeModel;
                        resposta.Mensagem = "Atividade não encontrada";
                    }
                    else if (ativadadeModel != null)
                    {
                        resposta.Dados = ativadadeModel;
                        resposta.Mensagem = "Atividade encontrada";
                    }

                    return resposta;
                }
                catch (Exception ex)
                {
                    resposta.Mensagem = ex.Message;
                    resposta.Status = false;
                    return resposta;
                }
            }

        }
        public async Task<ResponseModel<AtividadeModel>> CreateAtividade(AtividadeCreateDTO atividadeCreateDTO)
        {
            ResponseModel<AtividadeModel> resposta = new ResponseModel<AtividadeModel>();
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnections"))) {
                try
                {
                    var query = $@" INSERT INTO
                                        atividades
                                            (tipo_atividade_id, 
                                             descricao, 
                                             data_criacao, 
                                             hora_criacao)
                                        VALUES
                                            ({atividadeCreateDTO.tipo_atividade_id},
                                            '{atividadeCreateDTO.descricao}',
                                             CONVERT(DATE, '{DateTime.Today}', 103),
                                            '{DateTime.Now.ToString("HH:mm:ss")}')
                                    SELECT CAST(SCOPE_IDENTITY() AS INT);";

                    int id = await connection.QuerySingleAsync<int>(query);

                    if(id == 0)
                    {
                        resposta.Mensagem = "Atividade não criada";
                    }
                    else if (id > 0)
                    {
                        resposta = await GetAtividadeId(id);
                        resposta.Mensagem = "Atividade criada com sucesso";
                    }

                    return resposta;
            }
                catch (Exception ex)
                {
                    resposta.Mensagem = ex.Message;
                    resposta.Status = false;
                    return resposta;
                }
            }
        }

        public async Task<ResponseModel<AtividadeModel>> DeletarAtividade(int idAtividade)
        {
            ResponseModel<AtividadeModel> resposta = new ResponseModel<AtividadeModel>();
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnections")))
            {
                try
                {
                    string query = $@"DELETE FROM
                                        atividades
                                    WHERE
                                        id = {idAtividade}";
                    var sql = await connection.ExecuteAsync(query);

                    if (sql == 0)
                    {
                        resposta.Mensagem = "Atividade não deletada";


                    }
                    else if (sql > 0)
                    {
                        resposta.Mensagem = "Atividade deletada com sucesso";

                    }
                    return resposta;
                }
                catch (Exception ex) 
                {
                    resposta.Mensagem = ex.Message;
                    resposta.Status = false;
                    return resposta;
                }
            }
            
        }

        public async Task<ResponseModel<AtividadeModel>> EditarAtividade(AtividadeEditDTO atividadeEditDTO)
        {
            ResponseModel<AtividadeModel> resposta = new ResponseModel<AtividadeModel>();
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnections")))
            {
                try
                {
                    string query = $@"UPDATE
                                        atividades
                                    SET
                                        descricao = @Descricao, data_alteracao = @Data_alteracao,
                                        hora_alteracao = @Hora_alteracao
                                    WHERE
                                        id = @Id";

                    var parametros = new
                    {
                        Id = atividadeEditDTO.id,
                        Descricao = atividadeEditDTO.descricao,
                        Data_alteracao = atividadeEditDTO.data_alteracao,
                        Hora_alteracao = atividadeEditDTO.hora_alteracao
                    };
                    await connection.OpenAsync();

                    var sql = await connection.ExecuteAsync(query, parametros);

                    var respostaAtvById = await GetAtividadeId(atividadeEditDTO.id);

                    if (respostaAtvById == null)
                    {
                        resposta.Mensagem = "Atividade não foi editada";
                    }
                    else if (parametros != null)
                    {
                        resposta.Dados = respostaAtvById.Dados;
                        resposta.Mensagem = "Atividade editada com sucesso";
                    }
                    return resposta;

                }
                catch (Exception ex)
                {
                    resposta.Mensagem = ex.Message;
                    resposta.Status = false;
                    return resposta;
                }
            }
        }


    }
}
