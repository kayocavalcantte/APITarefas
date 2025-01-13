using System.ComponentModel.DataAnnotations.Schema;

namespace APITarefas.Dtos.Atividade
{
    [Table("atividades")]
    public class AtividadeCreateDTO
    {
        public int tipo_atividade_id { get; set; }
        public string descricao { get; set; } = string.Empty;
    }
}
