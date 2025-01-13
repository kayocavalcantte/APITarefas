namespace APITarefas.Models
{
    public class ResponseModel<T>
    {
        public T? Dados { get; set; }
        public bool Status { get; set; } = true;
        public string Mensagem { get; set; } = string.Empty;

    }
}
