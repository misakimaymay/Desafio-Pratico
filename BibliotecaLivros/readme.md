# BibliotecaLivros

Este projeto é um sistema simples de gerenciamento de livros em C#, que permite cadastrar, listar, buscar, atualizar e remover livros de uma biblioteca. O sistema é executado em modo console e utiliza uma lista em memória para armazenar os dados dos livros.

## Funcionalidades

- **Cadastrar Livro:** Adicione um novo livro informando título, autor e ISBN.
- **Listar Livros:** Exibe todos os livros cadastrados.
- **Buscar Livros:** Procure livros pelo título ou autor.
- **Atualizar Livro:** Atualize as informações de um livro a partir do ISBN.
- **Remover Livro:** Remova um livro utilizando o ISBN.
- **Sair:** Encerra o programa.

## Como Executar

1. Certifique-se de ter o [.NET SDK](https://dotnet.microsoft.com/download) instalado em sua máquina.
2. Clone este repositório:
   ```bash
   git clone https://github.com/misakimaymay/Desafio-Pratico.git
   ```
3. Acesse o diretório do projeto:
   ```bash
   cd Desafio-Pratico/BibliotecaLivros
   ```
4. Compile e execute o programa:
   ```bash
   dotnet run
   ```

## Exemplo de Uso

Ao executar, o menu principal será exibido:

```
--- Biblioteca de Livros ---
1. Cadastrar Livro
2. Listar Livros
3. Buscar Livros
4. Atualizar Livro
5. Remover Livro
6. Sair
Escolha uma opção:
```

Basta seguir as instruções para utilizar as funcionalidades desejadas.

## Estrutura do Código

- `Livro`: Classe que representa um livro, com propriedades de Título, Autor e ISBN.
- `Biblioteca`: Classe responsável pela lógica de cadastro, busca, listagem, atualização e remoção de livros.
- `Program`: Classe com o método `Main`, responsável pela interface com o usuário via console.

## Observações

- Os dados dos livros são armazenados apenas em memória. Ao fechar o programa, os dados cadastrados serão perdidos.
- O ISBN é utilizado como identificador único para atualização e remoção de livros.

## Licença

Este projeto é apenas para fins educacionais e de demonstração.

---
