namespace Gerenciador_de_Tarefas
{
    internal class Program
    {
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
                            break;
                        case "2":
                            Console.WriteLine("Cadastrar uma nova tarefa");
                            break;
                        case "3":
                            Console.WriteLine("Excluir uma tarefa.");
                            break;
                        case "4":
                            Console.WriteLine("Atualizar o status de uma tarefa");
                            break;
                        case "5":
                            Console.WriteLine("Listar tarefas.");
                            break;
                        default: 
                            opcao = "Inválido";
                            Console.WriteLine("Escolha uma opção de 0 até 5:");
                            break;
                    }
                } catch (Exception ex) {
                    Console.WriteLine($"Exceção 1 - Exception\n{ex}");
                }
            }
        }

    }
}
