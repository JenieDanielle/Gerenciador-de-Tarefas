namespace Gerenciador_de_Tarefas
{
    internal class Program
    {
        static List<NovoResponsavel> usuarios = new List<NovoResponsavel>();
        static List<NovaTarefa> tarefas = new List<NovaTarefa>();
        static List<NovaTarefa> tarefasPendentes = new List<NovaTarefa>();
        static List<NovaTarefa> tarefasConcluidas = new List<NovaTarefa>();

        static void DadosTeste()
        {
            usuarios.Add(new NovoResponsavel("Simone", "simoninha@gmail.com"));
            usuarios.Add(new NovoResponsavel("user teste", "teste@gmail.com"));

            var tarefa1 = new NovaTarefa("Fazer este trabalho", "08/04/2025", "Pendente", "Alta", "user teste");
            var tarefa2 = new NovaTarefa("Tarefa teste", "01/05/2025", "Concluido", "Média", "Simone");
            var tarefa3 = new NovaTarefa("Fazer este trabalho2", "08/04/2025", "Em andamento", "Alta", "Simone");
            var tarefa4 = new NovaTarefa("Tarefa teste2", "01/05/2025", "Em andamento", "Média", "Simone");
            var tarefa5 = new NovaTarefa("Tarefa teste3", "01/05/2025", "Em andamento", "Média", "Simone");

            tarefas.Add(tarefa1);
            tarefas.Add(tarefa2);
            tarefas.Add(tarefa3);
            tarefas.Add(tarefa4);
            tarefas.Add(tarefa5);

            tarefasPendentes.Add(tarefa1);
            tarefasConcluidas.Add(tarefa2);
        }
        static void Main()
        {
            DadosTeste();

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
                            CadastrarUsuario();
                            break;
                        case "2":
                            Console.WriteLine("Cadastrar uma nova tarefa");
                            NovaTarefa();
                            break;
                        case "3":
                            Console.WriteLine("Excluir uma tarefa.");
                            ExcluirTarefa();
                            break;
                        case "4":
                            Console.WriteLine("Atualizar o status de uma tarefa");
                            AtualizarStatusTarefa();
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
        static void CadastrarUsuario()
        {

            Console.WriteLine("\nDigite o nome: ");
            string nome = Console.ReadLine();

            Console.WriteLine("\nDigite seu email: ");
            string email = Console.ReadLine();

            NovoResponsavel novoResponsavel = new NovoResponsavel(nome, email);
            Console.WriteLine(novoResponsavel.ExibirInformacoes());

            usuarios.Add(novoResponsavel);
            Console.WriteLine("\nUsuário cadastrado!");
        }
        static void NovaTarefa()
        {
            try
            {
                Console.WriteLine("\nTítulo:");
                string titulo = Console.ReadLine();

                string dataLimiteString;
                DateTime dataLimite;

                while (true)
                {
                    Console.WriteLine("\nData Limite (formato: dd/mm/yyyy):");
                    dataLimiteString = Console.ReadLine();

                    dataLimite = DateTime.Now;
                    try
                    {
                        dataLimite = Convert.ToDateTime(dataLimiteString);

                        if (dataLimite < DateTime.Now.Date)
                        {
                            Console.WriteLine("A data limite não pode estar no passado");
                            continue;
                        }
                        break;

                    }
                    catch
                    {
                        Console.WriteLine("Data inválida. Use o formato dia/mês/ano.");
                    }
                }


                Console.WriteLine($"\nStatus da tarefa:\n- Pendente.\n- Em andamento.\n- Concluída.");
                string status = Console.ReadLine();

                Console.WriteLine($"\nPrioridade:\n- Baixa.\n- Média.\n- Alta.");
                string prioridade = Console.ReadLine();

                string nome;
                bool nomeValido = false;

                while (true)
                {
                    Console.WriteLine("\nNome do usuário responsável:");
                    nome = Console.ReadLine();

                    foreach (var usuario in usuarios)
                    {
                        if (usuario.Nome == nome)
                        {
                            nomeValido = true;
                            break;
                        }
                    }

                    if (nomeValido == false)
                    {
                        Console.WriteLine("Esse responsável não existe. Deseja tentar com outro nome? (S - Sim / N - Não)");
                        string resposta = Console.ReadLine();

                        if (resposta.ToUpper() == "N")
                        {
                            Console.WriteLine("\nRetornando ao menu...");
                            return;
                        }
                        else
                        {
                            continue;
                        }
                    }

                    int tarefasEmAndamento = 0;

                    foreach (var tarefa in tarefas)
                    {
                        if (tarefa.nome == nome && tarefa.status == "Em andamento")
                        {
                            tarefasEmAndamento++;
                        }
                    }

                    if (status == "Em andamento" && tarefasEmAndamento >= 3)
                    {
                        Console.WriteLine($"\nO responsável {nome} já possui 3 tarefas em andamento. Conclua alguma tarefa antes ou coloque essa tarefa para outro usúário.");
                        Console.WriteLine("Deseja tentar com outro responsável? (S - Sim / N - Não)");
                        string resposta = Console.ReadLine();

                        if (resposta.ToUpper() == "N")
                        {
                            Console.WriteLine("\nRetornando ao menu...");
                            return;
                        }
                        else
                        {
                            continue;
                        }
                    }
                    break;
                }


                if (prioridade == "Alta" && (dataLimite - DateTime.Now).TotalDays > 7)
                {
                    Console.WriteLine("Tarefas de alta prioridade não podem ter data limite maior que uma semana.");
                    return;
                }

                NovaTarefa novaTarefa = new NovaTarefa(titulo, dataLimiteString, status, prioridade, nome);
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
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao cadastrar tarefa: {ex.Message}");
            }
        }


        static void ExcluirTarefa()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Digite o nome do usuário responsável pela tarefa que deseja excluir ou 0 para sair: ");
                    string nome = Console.ReadLine();
                    if (nome == "0") break;

                    Console.WriteLine("Digite o título da tarefa que deseja excluir ou 0 para sair: ");
                    string titulo = Console.ReadLine();
                    if (titulo == "0") break;

                    NovaTarefa tarefaParaExcluir = null;

                    if (nome == "0") break;

                    foreach (var tarefa in tarefas)
                    {
                        if (tarefa.nome == nome && tarefa.titulo == titulo)
                        {
                            tarefaParaExcluir = tarefa;
                            break;
                        }
                    }

                    if (tarefaParaExcluir != null)
                    {
                        Console.WriteLine($"\nTítulo: {tarefaParaExcluir.titulo}\nData Limite: {tarefaParaExcluir.dataLimite}\nStatus: {tarefaParaExcluir.status}\nPrioridade: {tarefaParaExcluir.prioridade}\nNome: {tarefaParaExcluir.nome}\n\nDeseja excluir essa tarefa?\nS - Sim N - Não");
                        string confirmacao = Console.ReadLine();

                        if (confirmacao.ToUpper() == "S")
                        {
                            tarefas.Remove(tarefaParaExcluir);
                            tarefasPendentes.Remove(tarefaParaExcluir);
                            tarefasConcluidas.Remove(tarefaParaExcluir);
                            Console.WriteLine($"Tarefa {tarefaParaExcluir.titulo} excluída com sucesso!");
                        }
                        else
                        {
                            Console.WriteLine("Exclusão cancelada");
                        }

                        Console.WriteLine("\n\nDeseja excluir mais alguma tarefa? S - Sim N - Não");
                        string repetir = Console.ReadLine();
                        if (repetir.ToUpper() != "S")
                        {
                            break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Tarefa não encontrada :(");
                        break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"\nOcorreu um erro ao tentar excluir a tarefa: {ex.Message}");
                }
            }
        }

        static void AtualizarStatusTarefa()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Digite o nome do responsável pela tarefa que deseja atualizar ou 0 para sair: ");
                    string nome = Console.ReadLine();
                    if (nome == "0") break;

                    Console.WriteLine("Digite o titulo da tarefa que deseja atualizar ou 0 para sair:");
                    string titulo = Console.ReadLine();
                    if (nome == "0") break;

                    NovaTarefa tarefaParaAtualizar = null;

                    foreach (var tarefa in tarefas)
                    {
                        if (tarefa.nome == nome && tarefa.titulo == titulo)
                        {
                            tarefaParaAtualizar = tarefa;
                            break;
                        }
                    }

                    if (tarefaParaAtualizar != null)
                    {
                        Console.WriteLine($"\nTítulo: {tarefaParaAtualizar.titulo}\nData Limite: {tarefaParaAtualizar.dataLimite}\nStatus: {tarefaParaAtualizar.status}\nPrioridade: {tarefaParaAtualizar.prioridade}\nNome: {tarefaParaAtualizar.nome}");
                        Console.WriteLine($"\n\nStatus atual da tarefa: {tarefaParaAtualizar.status}\nDigite o novo status da tarefa (1 - Pendente, 2 - Em andamento, 3 - Concluída)");
                        string novoStatus = "";

                        while (true)
                        {
                            string escolhaStatus = Console.ReadLine();
                            switch (escolhaStatus)
                            {
                                case "1":
                                    novoStatus = "Pendente";
                                    break;
                                case "2":
                                    novoStatus = "Em andamento";
                                    break;
                                case "3":
                                    novoStatus = "Concluída";
                                    break;
                                default:
                                    Console.WriteLine("Opção inválida. Digite 1 - Pendente, 2 - Em andamento, 3 - Concluída.");
                                    continue;
                            }
                            break;
                        }

                        string statusAnterior = tarefaParaAtualizar.status;
                        tarefaParaAtualizar.status = novoStatus;

                        if (statusAnterior == "Pendente")
                        {
                            tarefasPendentes.Remove(tarefaParaAtualizar);
                        }
                        else if (statusAnterior == "Concluída")
                        {
                            tarefasConcluidas.Remove(tarefaParaAtualizar);
                        }

                        if (novoStatus == "Pendente")
                        {
                            tarefasPendentes.Add(tarefaParaAtualizar);
                        }
                        else if (novoStatus == "Concluída")
                        {
                            tarefasConcluidas.Add(tarefaParaAtualizar);
                        }

                        Console.WriteLine("Status da tarefa atualizado!");
                        Console.WriteLine($"\nTítulo: {tarefaParaAtualizar.titulo}\nData Limite: {tarefaParaAtualizar.dataLimite}\nStatus: {tarefaParaAtualizar.status}\nPrioridade: {tarefaParaAtualizar.prioridade}\nNome: {tarefaParaAtualizar.nome}");

                        Console.WriteLine("\nDeseja atualizar o status de outra tarefa? (S - Sim / N - Não)");
                        string repetir = Console.ReadLine();

                        if (repetir.ToUpper() != "S")
                        {
                            break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro ao atualizar status: {ex.Message}");
                }
            }
        }
        static void ListarTarefa()
        {
            Console.WriteLine("\nEscolha uma das opções:\n0.Sair\n1.Listar todas as tarefas.\n2.Listar todas as tarefas de um usuário específico.");

            while (true)
            {
                try
                {
                    string opcao;
                    opcao = Console.ReadLine();

                    if (opcao == "0") return;

                    else if (opcao == "1")
                    {
                        while (true)
                        {
                            Console.WriteLine("\nEscolha uma das opções:\n0.Sair\n1.Listar todas as tarefas\n2.Listar tarefas pendentes\n3.Listar tarefas concluídas");
                            string opcao1 = Console.ReadLine();

                            if (opcao1 == "0") break;

                            else if (opcao1 == "1")
                            {
                                foreach (var tarefa in tarefas)
                                {
                                    Console.WriteLine($"\nTítulo: {tarefa.titulo}\nData Limite: {tarefa.dataLimite}\nStatus: {tarefa.status}\nPrioridade: {tarefa.prioridade}\nNome: {tarefa.nome}");
                                }
                            }
                            else if (opcao1 == "2")
                            {
                                foreach (var tarefa in tarefasPendentes)
                                {
                                    Console.WriteLine($"\nTítulo: {tarefa.titulo}\nData Limite: {tarefa.dataLimite}\nStatus: {tarefa.status}\nPrioridade: {tarefa.prioridade}\nNome: {tarefa.nome}");
                                }
                            }
                            else if (opcao1 == "3")
                            {
                                foreach (var tarefa in tarefasConcluidas)
                                {
                                    Console.WriteLine($"\nTítulo: {tarefa.titulo}\nData Limite: {tarefa.dataLimite}\nStatus: {tarefa.status}\nPrioridade: {tarefa.prioridade}\nNome: {tarefa.nome}");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Inválido! Escolha uma das opções de 0 até 3.");
                            }
                        }
                    }
                    else if (opcao == "2")
                    {

                        Console.WriteLine("\nDigite seu nome de usuário:");
                        string nome = Console.ReadLine();

                        while (true)
                        {
                            Console.WriteLine("\nEscolha uma das opções:\n0.Sair\n1.Listar todas as tarefas\n2.Listar tarefas pendentes\n3.Listar tarefas concluídas");
                            string opcao2 = Console.ReadLine();

                            if (opcao2 == "0") break;

                            else if (opcao2 == "1")
                            {
                                foreach (var tarefa in tarefas)
                                {
                                    if (tarefa.nome == nome)
                                    {
                                        Console.WriteLine($"\nTítulo: {tarefa.titulo}\nData Limite: {tarefa.dataLimite}\nStatus: {tarefa.status}\nPrioridade: {tarefa.prioridade}\nNome: {tarefa.nome}");
                                    }
                                }
                            }
                            else if (opcao2 == "2")
                            {
                                foreach (var tarefa in tarefasPendentes)
                                {
                                    if (tarefa.nome == nome)
                                    {
                                        Console.WriteLine($"\nTítulo: {tarefa.titulo}\nData Limite: {tarefa.dataLimite}\nStatus: {tarefa.status}\nPrioridade: {tarefa.prioridade}\nNome: {tarefa.nome}");
                                    }
                                }
                            }
                            else if (opcao2 == "3")
                            {
                                foreach (var tarefa in tarefasConcluidas)
                                {
                                    if (tarefa.nome == nome)
                                    {
                                        Console.WriteLine($"\nTítulo: {tarefa.titulo}\nData Limite: {tarefa.dataLimite}\nStatus: {tarefa.status}\nPrioridade: {tarefa.prioridade}\nNome: {tarefa.nome}");
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("Inválido! Escolha uma das opções de 0 até 3.");
                            }
                        }
                    }   
                    else
                    {
                        Console.WriteLine("Inválido! Escolha uma das opções de 0 até 2.");
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