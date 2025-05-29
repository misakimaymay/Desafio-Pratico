namespace BibliotecaLivros
{
    public class Livro
    {
        public string Título { get; set; }
        public string Autor { get; set; }
        public string ISBN { get; set; }
    }

    public class Biblioteca
    {
        private List<Livro> livros = new List<Livro>();
        public void CadastrarLivro(string titulo, string autor, string isbn)
        {
            var novoLivro = new Livro
            {
                Título = titulo,
                Autor = autor,
                ISBN = isbn
            };
            livros.Add(novoLivro);
        }
        public void ListarLivros()
        {
            if (livros.Count == 0)
            {
                Console.WriteLine("Nenhum livro cadastrado.");
                return;
            }

            foreach (var livro in livros)
            {
                Console.WriteLine($"Título: {livro.Título}, Autor: {livro.Autor}, ISBN: {livro.ISBN}");
            }
        }
        public List<Livro> BuscarLivros(string termoBusca)
        {
            return livros
                .Where(l => l.Título.Contains(termoBusca, StringComparison.OrdinalIgnoreCase) ||
                            l.Autor.Contains(termoBusca, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }
        public bool AtualizarLivro(string isbn, string novoTítulo, string novoAutor)
        {
            var livro = livros.FirstOrDefault(l => l.ISBN == isbn);
            if (livro == null)
            {
                Console.WriteLine("Livro não encontrado.");
                return false;
            }

            livro.Título = novoTítulo;
            livro.Autor = novoAutor;
            Console.WriteLine("Livro atualizado com sucesso.");
            return true;
        }
        public bool RemoverLivro(string isbn)
        {
            var livro = livros.FirstOrDefault(l => l.ISBN == isbn);
            if (livro == null)
            {
                Console.WriteLine("Livro não encontrado.");
                return false;
            }
            livros.Remove(livro);
            Console.WriteLine("Livro removido com sucesso.");
            return true;
        }
        class Program
        {
            static void Main(string[] args)
            {
                var biblioteca = new Biblioteca();
                bool sair = false;

                while (!sair)
                {
                    Console.WriteLine("\n--- Biblioteca de Livros ---");
                    Console.WriteLine("1. Cadastrar Livro");
                    Console.WriteLine("2. Listar Livros");
                    Console.WriteLine("3. Buscar Livros");
                    Console.WriteLine("4. Atualizar Livro");
                    Console.WriteLine("5. Remover Livro");
                    Console.WriteLine("6. Sair");
                    Console.Write("Escolha uma opção: ");
                    var opcao = Console.ReadLine();

                    switch (opcao)
                    {
                        case "1":
                            Console.Write("Título: ");
                            var titulo = Console.ReadLine();
                            Console.Write("Autor: ");
                            var autor = Console.ReadLine();
                            Console.Write("ISBN: ");
                            var isbn = Console.ReadLine();
                            biblioteca.CadastrarLivro(titulo, autor, isbn);
                            break;

                        case "2":
                            biblioteca.ListarLivros();
                            break;

                        case "3":
                            Console.Write("Digite o termo de busca: ");
                            var termoBusca = Console.ReadLine();
                            var resultados = biblioteca.BuscarLivros(termoBusca);
                            if (resultados.Count == 0)
                            {
                                Console.WriteLine("Nenhum livro encontrado.");
                            }
                            else
                            {
                                foreach (var livro in resultados)
                                {
                                    Console.WriteLine($"Título: {livro.Título}, Autor: {livro.Autor}, ISBN: {livro.ISBN}");
                                }
                            }
                            break;

                        case "4":
                            Console.Write("Digite o ISBN do livro a ser atualizado: ");
                            var isbnAtualizar = Console.ReadLine();
                            Console.Write("Novo Título: ");
                            var novoTitulo = Console.ReadLine();
                            Console.Write("Novo Autor: ");
                            var novoAutor = Console.ReadLine();
                            biblioteca.AtualizarLivro(isbnAtualizar, novoTitulo, novoAutor);
                            break;

                        case "5":
                            Console.Write("Digite o ISBN do livro a ser removido: ");
                            var isbnRemover = Console.ReadLine();
                            biblioteca.RemoverLivro(isbnRemover);
                            break;

                        case "0":
                            sair = true;
                            break;

                        default:
                            Console.WriteLine("Opção inválida. Tente novamente.");
                            break;
                    }
                }
            }
        }
    }
}
