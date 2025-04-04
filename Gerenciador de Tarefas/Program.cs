namespace Gerenciador_de_Tarefas
{
    internal class Program
    {
        static List<NovoResponsavel> usuarios = new List<NovoResponsavel>();
        static List<NovaTarefa> tarefas = new List<NovaTarefa>();
        static List<NovaTarefa> tarefasPendentes = new List<NovaTarefa>();
        static List<NovaTarefa> tarefasConcluidas = new List<NovaTarefa>();

        static void Main()
        {
            while (true)
            {
                Console.WriteLine($@"
                 Digite o número da opção que deseja:
                 1 - Cadastrar um novo usuário.
                 2 - Cadastrar uma nova tarefa.
                 3 - Excluir uma tarefa.
                 4 - Atualizar o status de uma tarefa.
                 5 - Listar tarefas.
                 0 - Sair.
                ");

                // fazer o tratamento de erros

                string opcao = Console.ReadLine();

                try
                {
                    switch (opcao)
                    {
                        case "0":
                            Console.WriteLine("Saindo...");
                            return;
                        case "1":
                            Console.WriteLine("Cadastrar um novo usuário");
                            CadastrarUsuário();
                            break;
                        case "2":
                            Console.WriteLine("Cadastrar uma nova tarefa");
                            NovaTarefa();
                            break;
                        case "3":
                            Console.WriteLine("Excluir uma tarefa.");
                            break;
                        case "4":
                            Console.WriteLine("Atualizar o status de uma tarefa");
                            break;
                        case "5":
                            Console.WriteLine("Listar tarefas.");
                            ListarTarefa();
                            break;
                        default:
                            opcao = "Inválido";
                            Console.WriteLine("Escolha uma opção de 0 até 5:");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Exceção 1 - Exception\n{ex}");
                }
            }
        }
        static void CadastrarUsuário()
        {

            Console.WriteLine("\nDigite o nome: ");
            string nome = Console.ReadLine();

            Console.WriteLine("\nDigite seu email: ");
            string email = Console.ReadLine();

            NovoResponsavel novoResponsavel = new NovoResponsavel(nome, email);
            Console.WriteLine(novoResponsavel.ExibirInformacoes());

            usuarios.Add(novoResponsavel);
            Console.WriteLine("\nUsuário cadastrado.");
        }
        static void NovaTarefa()
        {
            Console.WriteLine("\nTítulo:");
            string titulo = Console.ReadLine();

            Console.WriteLine("\nData Limite:");
            string dataLimite = Console.ReadLine();

            Console.WriteLine($"\nStatus da tarefa:\n- Pendente.\n- Em andamento.\n- Concluída.");
            string status = Console.ReadLine();

            Console.WriteLine($"\nPrioridade:\n- Baixa.\n- Média.\n- Alta.");
            string prioridade = Console.ReadLine();

            Console.WriteLine("\nNome do usuário:");
            string nome = Console.ReadLine();

            NovaTarefa novaTarefa = new NovaTarefa(titulo, dataLimite, status, prioridade, nome);
            Console.WriteLine(novaTarefa.ExibirInformacoes());

            tarefas.Add(novaTarefa);
            Console.WriteLine("\nTarefa cadastrada.");

            if (status == "Pendente")
            {
                tarefasPendentes.Add(novaTarefa);
            }
            else if (status == "Concluída")
            {
                tarefasConcluidas.Add(novaTarefa);
            }
        }
        static void ListarTarefa()
        {
            Console.WriteLine("Digite seu nome para ver suas listas de tarefas:");
            string nome = Console.ReadLine();
            Console.WriteLine("\nEscolha uma das opções:\n0.Sair\n1.Listar todas as tarefas\n2.Listar tarefas pendentes\n3.Listar tarefas concluídas");
            string opcao;
            while (true)
            {
                try
                {
                    opcao = Console.ReadLine();
                    if (opcao == "0")
                    {
                        Console.WriteLine("Saindo...");
                        return;
                    }
                    else if (opcao == "1")
                    {
                        foreach (var tarefa in tarefas)
                        {
                            if (tarefa.nome == nome)
                            {
                                Console.WriteLine($"{tarefa.titulo} - {tarefa.dataLimite} - {tarefa.status} - {tarefa.prioridade} - {tarefa.nome}");
                            }
                        }
                    }
                    else if (opcao == "2")
                    {
                        foreach (var tarefa in tarefasPendentes)
                        {
                            if (tarefa.nome == nome)
                            {
                                Console.WriteLine($"{tarefa.titulo} - {tarefa.dataLimite} - {tarefa.status} - {tarefa.prioridade} - {tarefa.nome}");
                            }
                        }
                    }
                    else if (opcao == "3")
                    {
                        foreach (var tarefa in tarefasConcluidas)
                        {
                            if (tarefa.nome == nome)
                            {
                                Console.WriteLine($"{tarefa.titulo} - {tarefa.dataLimite} - {tarefa.status} - {tarefa.prioridade} - {tarefa.nome}");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Inválido! Escolha uma das opções de 0 até 3.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Digite a opção novamente:");
                }
            }
        }
    }
}