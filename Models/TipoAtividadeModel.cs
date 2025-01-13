using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APITarefas.Models
{
    [Table("tipo_atividade")]
    public class TipoAtividadeModel
    {
        [Key]
        public int id { get; set; }
        public string descricao { get; set; } = string.Empty;
    }
}
