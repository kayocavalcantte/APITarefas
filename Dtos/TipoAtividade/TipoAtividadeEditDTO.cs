using System.ComponentModel.DataAnnotations.Schema;

namespace APITarefas.Dtos.TipoAtividade
{
    [Table("tipo_atividade")]
    public class TipoAtividadeEditDTO
    {
        public int id { get; set; }
        public string descricao { get; set; } = string.Empty;
    }
}
