# GerenciadorFuncionarios

Este é um projeto simples em C# para gerenciar funcionários, permitindo cadastrar, listar, buscar, atualizar e remover funcionários por meio de um menu no console.

## Funcionalidades

- **Cadastrar Funcionário**: Adiciona um novo funcionário com ID, nome e cargo.
- **Listar Funcionários**: Exibe todos os funcionários cadastrados.
- **Buscar Funcionário**: Permite buscar por nome ou ID.
- **Atualizar Funcionário**: Atualiza nome e cargo de um funcionário existente.
- **Remover Funcionário**: Remove um funcionário cadastrado pelo seu ID.

## Como usar

1. Compile o arquivo `GerenciadorFuncionarios.cs`.
2. Execute o programa.
3. Utilize o menu para escolher as operações desejadas:

```
1. Cadastrar
2. Listar
3. Buscar
4. Atualizar
5. Remover
6. Sair
```

## Exemplo de Uso

- **Cadastrar:** Informe o nome, ID (número inteiro) e cargo do funcionário.
- **Buscar:** Escolha buscar por nome (digite o nome completo) ou por ID.
- **Atualizar:** Informe o ID do funcionário, novo nome e novo cargo.
- **Remover:** Informe o ID do funcionário a ser removido.

## Estrutura do Código

- **Classe Funcionario**: Representa um funcionário com propriedades ID, Nome e Cargo.
- **Classe GerenciadorFuncionarios**: Controla a lista de funcionários e implementa os métodos para gerenciar funcionários.
- **Classe Program**: Interface de console para o usuário interagir com o sistema.

## Observações

- IDs de funcionários devem ser únicos.
- O sistema armazena os dados apenas em memória (não há persistência em arquivo ou banco de dados).

## Autor

Desenvolvido por [misakimaymay](https://github.com/misakimaymay).
