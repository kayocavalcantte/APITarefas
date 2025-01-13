using System.ComponentModel.DataAnnotations.Schema;

namespace APITarefas.Dtos.Atividade
{
    [Table("atividades")]
    public class AtividadeEditDTO
    {
        public int id { get; set; }
        public string descricao { get; set; } = string.Empty;
        public DateTime data_alteracao { get; set; }
        public TimeSpan hora_alteracao { get; set; }
    }
}
