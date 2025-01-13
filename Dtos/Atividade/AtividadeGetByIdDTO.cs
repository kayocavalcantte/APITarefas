using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APITarefas.Dtos.Atividade
{
    [Table("atividades")]
    public class AtividadeGetByIdDTO
    {
        public int id { get; set; }
        public int tipo_atividade_id { get; set; }
        public string descricao { get; set; } = string.Empty;
        public DateTime data_criacao { get; set; }
        public TimeSpan hora_criacao { get; set; }
        public DateTime data_alteracao { get; set; }
        public TimeSpan hora_alteracao { get; set; }
    }
}
