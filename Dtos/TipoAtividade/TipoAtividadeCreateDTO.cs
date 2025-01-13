using System.ComponentModel.DataAnnotations.Schema;

namespace APITarefas.Dtos.TipoAtividade
{
    [Table("tipo_atividade")]
    public class TipoAtividadeCreateDTO
    {
        public string descricao { get; set; } = string.Empty;
    }
}
