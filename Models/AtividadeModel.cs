using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APITarefas.Models
{
    [Table("atividades")]
    public class AtividadeModel
    {
        [Key]
        public int id { get; set; }
        public int tipo_atividade_id { get; set; }
        public string descricao { get; set; } = string.Empty;
        public DateOnly data_criacao { get; set; }
        public TimeSpan hora_criacao { get; set; }
        public DateOnly data_alteracao { get; set; }
        public TimeSpan hora_alteracao { get; set; }

    }
}
