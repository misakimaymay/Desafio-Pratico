using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using static GerenciamentoFuncionamento.Funcionario;

namespace GerenciamentoFuncionamento
{
    public class Funcionario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cargo { get; set; }

        public class GerenciadorFuncionarios
        {
            private readonly List<Funcionario> funcionarios = new();
            private readonly Dictionary<int, Funcionario> funcionariosPorId = new();
            public List<Funcionario> BuscarPorNome(string nome)
            {
                return funcionarios.FindAll(f => f.Nome.Equals(nome, StringComparison.OrdinalIgnoreCase));
            }

            public void CadastrarFuncionario(int id, string nome, string cargo)
            {
                if (funcionariosPorId.ContainsKey(id))
                {
                    Console.WriteLine("Funcionário já cadastrado.");
                    return;
                }
                var funcionario = new Funcionario { Id = id, Nome = nome, Cargo = cargo };
                funcionarios.Add(funcionario);
                funcionariosPorId[funcionario.Id] = funcionario;
                Console.WriteLine($"Funcionário {nome} cadastrado com sucesso.");
            }

            public void ListarFuncionarios()
            {
                if (funcionarios.Count == 0)
                {
                    Console.WriteLine("Nenhum funcionário cadastrado.");
                    return;
                }
                Console.WriteLine("Lista de Funcionários:");
                foreach (var funcionario in funcionarios)
                {
                    Console.WriteLine($"ID: {funcionario.Id}, Nome: {funcionario.Nome}, Cargo: {funcionario.Cargo}");
                }
            }

            public Funcionario BuscarPorId(int id)
            {
                if (funcionariosPorId.TryGetValue(id, out var funcionario))
                {
                    return funcionario;
                }
                return null;
            }


            public void AtualizarFuncionario(int id, string novoNome, string novoCargo)
            {
                if (funcionariosPorId.TryGetValue(id, out var funcionario))
                {
                    funcionario.Nome = novoNome;
                    funcionario.Cargo = novoCargo;
                    Console.WriteLine($"Funcionário {id} atualizado com sucesso.");
                }
                else
                {
                    Console.WriteLine("Funcionário não encontrado.");
                }
            }

            public void RemoverFuncionario(int id)
            {
                if (funcionariosPorId.TryGetValue(id, out var funcionario))
                {
                    funcionarios.Remove(funcionario);
                    funcionariosPorId.Remove(id);
                    Console.WriteLine($"Funcionário {id} removido com sucesso.");
                }
                else
                {
                    Console.WriteLine("Funcionário não encontrado.");
                }
            }
        }
        }
    }
internal class Program
{
    static void Main(string[] args)
    {
        var gerenciador = new GerenciadorFuncionarios();
        while (true)
        {
            Console.WriteLine("\n1. Cadastrar\n2. Listar\n3. Buscar\n4. Atualizar\n5. Remover\n6. Sair");
            Console.Write("Escolha uma opção: ");
            var opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    Console.Write("Nome: ");
                    var nome = Console.ReadLine();
                    Console.Write("ID: ");
                    int.TryParse(Console.ReadLine(), out var id);
                    Console.Write("Cargo: ");
                    var cargo = Console.ReadLine();
                    gerenciador.CadastrarFuncionario(id, nome, cargo);
                    break;
                case "2":
                    gerenciador.ListarFuncionarios();
                    break;
                case "3":
                    Console.Write("Buscar por (1) Nome ou (2) ID? ");
                    var tipoBusca = Console.ReadLine();
                    if (tipoBusca == "1")
                    {
                        Console.Write("Nome: ");
                        var buscaNome = Console.ReadLine();
                        var encontrados = gerenciador.BuscarPorNome(buscaNome);
                        if (encontrados.Count == 0)
                            Console.WriteLine("Nenhum funcionário encontrado.");
                        else
                            foreach (var f in encontrados)
                                Console.WriteLine($"ID: {f.Id}, Nome: {f.Nome}, Cargo: {f.Cargo}");
                    }
                    else if (tipoBusca == "2")
                    {
                        Console.Write("ID: ");
                        int.TryParse(Console.ReadLine(), out var buscaId);
                        var f = gerenciador.BuscarPorId(buscaId);
                        if (f == null)
                            Console.WriteLine("Funcionário não encontrado.");
                        else
                            Console.WriteLine($"ID: {f.Id}, Nome: {f.Nome}, Cargo: {f.Cargo}");
                    }
                    break;
                case "4":
                    Console.Write("ID do funcionário a atualizar: ");
                    int.TryParse(Console.ReadLine(), out var idAtualizar);
                    Console.Write("Novo nome: ");
                    var novoNome = Console.ReadLine();
                    Console.Write("Novo cargo: ");
                    var novoCargo = Console.ReadLine();
                    gerenciador.AtualizarFuncionario(idAtualizar, novoNome, novoCargo);
                    break;
                case "5":
                    Console.Write("ID do funcionário a remover: ");
                    int.TryParse(Console.ReadLine(), out var idRemover);
                    gerenciador.RemoverFuncionario(idRemover);
                    break;
                case "6":
                    return;
                default:
                    Console.WriteLine("Opção inválida.");
                    break;
            }
        }
    }
}
