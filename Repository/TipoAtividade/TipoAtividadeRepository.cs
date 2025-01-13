using System.Collections.Generic;
using APITarefas.Data;
using APITarefas.Dtos.TipoAtividade;
using APITarefas.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace APITarefas.Repository.TipoAtividade
{
    public class TipoAtividadeRepository : ITipoAtividadeRepository
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;

        public TipoAtividadeRepository(AppDbContext appDbContext, IConfiguration configuration)
        {
            _context = appDbContext;
            _configuration = configuration;
        }
        public async Task<ResponseModel<List<TipoAtividadeModel>>> GetTipoAtividade()
        {
            ResponseModel<List<TipoAtividadeModel>> resposta = new ResponseModel<List<TipoAtividadeModel>> ();
            try
            {
                var tipoAtividade = await _context.tipo_atividade.ToListAsync();

                if (tipoAtividade.Count == 0) 
                {
                    resposta.Mensagem = "Listagem não realizada";
                }
                else if(tipoAtividade.Count > 0)
                {
                    resposta.Dados = tipoAtividade;
                    resposta.Mensagem = "Listagem realizada com sucesso";
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
        public async Task<ResponseModel<TipoAtividadeModel>> GetTipoAtividadeId(int idTpAtividade)
        {
            ResponseModel<TipoAtividadeModel> resposta = new ResponseModel<TipoAtividadeModel>();
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnections")))
                try
                {
                    string query = $@"Select 
                                    id,descricao
                               FROM 
                                    tipo_atividade
                               WHERE
                                     id = {idTpAtividade}";

                    var dto = await connection.QueryFirstOrDefaultAsync<TipoAtividadeGetByIdDTO>(query, new { id = idTpAtividade });

                    if (dto == null)
                    {
                        resposta.Status = false;
                        return resposta;
                    }

                    TipoAtividadeModel tipoAtividadeModel = new TipoAtividadeModel
                    {
                        id = dto.id,
                        descricao = dto.descricao
                    };

                    if (tipoAtividadeModel == null)
                    {
                        resposta.Mensagem = "Listagem não sucessida";
                    }
                    else if (tipoAtividadeModel != null)
                    {
                        resposta.Dados = tipoAtividadeModel;
                        resposta.Mensagem = "Listagem bem sucessida";
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
        public async Task<ResponseModel<TipoAtividadeModel>> EditarTipoAtividade(TipoAtividadeEditDTO tipoAtividadeEditDTO)
        {
            ResponseModel<TipoAtividadeModel> resposta = new ResponseModel<TipoAtividadeModel>();
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnections")))
                try
                {
                    string query = $@"UPDATE    
                                    tipo_atividade
                               SET
                                    descricao = @Descricao
                               WHERE
                                     id = @Id";

                    var parametros = new
                    {
                        Descricao = tipoAtividadeEditDTO.descricao,
                        Id = tipoAtividadeEditDTO.id
                    };
                    await connection.OpenAsync();
                    var sql = await connection.ExecuteAsync(query, parametros);

                    var respostaGetTpAtvById = await GetTipoAtividadeId(tipoAtividadeEditDTO.id);

                    if (sql == 0)
                    {
                        resposta.Mensagem = "Tipo atividade não foi editada";

                    }
                    else if(sql > 0)
                    {
                        resposta.Dados = respostaGetTpAtvById.Dados;
                        resposta.Mensagem = "Tipo atividade editada com sucesso";

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

        public async Task<ResponseModel<TipoAtividadeModel>> DeletarTipoAtividade(int idTpAtividade)
        {
            ResponseModel<TipoAtividadeModel> resposta = new ResponseModel<TipoAtividadeModel>();
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnections")))
            {
                try
                {
                    var query = $@" DELETE FROM
                                    tipo_atividade
                                WHERE
                                    id = {idTpAtividade}";

                    var sql = await connection.ExecuteAsync(query);

                    if(sql == 0)
                    {
                        resposta.Mensagem = "Tipo Atividade não deletada";
                    }
                    else if (sql > 0)
                    {
                        resposta.Mensagem = "Tipo Atividade deletada com sucesso";
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

        public async Task<ResponseModel<TipoAtividadeModel>> CreateTipoAtividade(TipoAtividadeCreateDTO tipoAtividadeCreateDTO)
        {
            ResponseModel<TipoAtividadeModel> resposta = new ResponseModel<TipoAtividadeModel>();
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnections")))
            {
                try
                {
                    var query = $@" INSERT INTO tipo_atividade
                                        (descricao)
                                    VALUES
                                        ('{tipoAtividadeCreateDTO.descricao}')
                                    SELECT CAST(SCOPE_IDENTITY() AS INT)";
                    
                    var id = await connection.QuerySingleAsync<int>(query);

                    if(id == 0)
                    {
                        resposta.Mensagem = "Tipo atividade não criada";
                    }
                    else if(id > 0)
                    {
                        resposta = await GetTipoAtividadeId(id);
                        resposta.Mensagem = "Tipo atividade criada";
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
