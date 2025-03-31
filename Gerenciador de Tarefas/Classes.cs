namespace Gerenciador_de_Tarefas
{
    internal class NovoResponsavel
    {
        public string Nome { get; set; }
        public string Email { get; set; }

        public NovoResponsavel(string Nome, string Email)
        {
            this.Nome = Nome;
            this.Email = Email;
        }

        public string ExibirInformacoes()
        {
            return $"\nNome: {this.Nome}\nEmail: {this.Email}";
        }
    }

    class NovaTarefa
    {
        public string titulo { get; set; }
        public string dataLimite { get; set; }
        public string status { get; set; }
        public string prioridade { get; set; }
        public string nome { get; set; }

        public NovaTarefa(string titulo, string dataLimite, string status, string prioridade, string nome)
        {
            this.titulo = titulo;
            this.dataLimite = dataLimite;
            this.status = status;
            this.prioridade = prioridade;
            this.nome = nome;
        }

        public string ExibirInformacoes()
        {
            return $"\n\nTítulo: {this.titulo}\nData limite: {this.dataLimite}\nStatus: {this.status}\nPrioridade: {this.prioridade}\nResponsável: {this.nome}";
        }
    }
}