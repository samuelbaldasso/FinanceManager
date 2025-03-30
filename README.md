# Finance Manager - C#, .NET, Entity In-Memory DB, MVC

## Sobre o Projeto

O **Finance Manager** é uma aplicação para gerenciamento de finanças pessoais desenvolvida em **C#** com o framework **.NET**. O projeto utiliza um banco de dados em memória com Entity Framework e segue o padrão arquitetural **MVC** (Model-View-Controller) para estruturar a aplicação.

O objetivo principal é oferecer um sistema simples e eficiente para controlar receitas, despesas e relatórios financeiros.

---

## Funcionalidades

- Cadastro de receitas e despesas.
- Visualização de saldo atual.
- Relatórios financeiros (mensais, anuais, categorias, etc.).
- Filtros para pesquisa por período ou categoria.
- Validação de dados ao inserir transações.

---

## Tecnologias Utilizadas

- **C#**: Linguagem principal para desenvolvimento.
- **.NET Framework/Core**: Ambiente de execução e desenvolvimento.
- **Entity Framework**: ORM para gerenciar o banco de dados em memória.
- **In-Memory Database**: Simula um banco de dados para facilitar o desenvolvimento e testes.
- **MVC**: Padrão arquitetural para separação de responsabilidades.

---

## Pré-requisitos

Antes de executar o projeto, certifique-se de ter instalado:

- **.NET SDK** (v6.0 ou superior)
- Um editor como **Visual Studio** ou **Visual Studio Code**

---

## Como Executar o Projeto

### 1. Clone o repositório

```bash
git clone https://github.com/samuelbaldasso/FinanceManager.git
```

### 2. Acesse o diretório do projeto

```bash
cd FinanceManager
```

### 3. Restaure as dependências

```bash
dotnet restore
```

### 4. Execute o projeto

```bash
dotnet run
```

A aplicação estará disponível em `http://localhost:5094`.

---

## Estrutura do Projeto

```plaintext
FinanceManager/
├── Controllers/        # Controladores responsáveis pela lógica de negócio
├── Models/             # Modelos representando entidades e regras de negócio
├── Views/              # Interface com o usuário (HTML, Razor)
├── Data/               # Configuração do banco de dados em memória
├── Services/           # Serviços para lógica adicional (opcional)
├── Program.cs          # Ponto de entrada da aplicação
├── Startup.cs          # Configuração de middleware e serviços
├── appsettings.json    # Configurações da aplicação
└── README.md           # Documentação do projeto
```

---

## Banco de Dados em Memória

Este projeto utiliza o **In-Memory Database** fornecido pelo Entity Framework Core. Ele é ideal para prototipagem e testes. Para persistir dados permanentemente, você pode alterar para um banco de dados relacional (como SQL Server ou PostgreSQL) configurando o `DbContext` no arquivo `Startup.cs`.

### Exemplo de Configuração do DbContext:

```csharp
services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("FinanceDB"));
```

---

## Scripts Disponíveis

- **`dotnet build`**: Compila o projeto.
- **`dotnet run`**: Executa o servidor.
- **`dotnet test`**: Executa os testes unitários (se houver).

---

## Próximos Passos

- Implementar autenticação e autorização.
- Adicionar suporte para exportação de relatórios (PDF/Excel).
- Migrar para um banco de dados relacional (ex.: SQL Server).
- Melhorar a interface do usuário com bibliotecas modernas como Bootstrap ou TailwindCSS.

---

## Contribuindo

Contribuições são sempre bem-vindas! Siga os passos abaixo para colaborar:

1. Faça um fork do projeto.
2. Crie uma branch para a sua feature (`git checkout -b minha-feature`).
3. Commit suas alterações (`git commit -m 'Adiciona minha feature'`).
4. Envie para o repositório remoto (`git push origin minha-feature`).
5. Abra um Pull Request.

---

## Licença

Este projeto está licenciado sob a [MIT License](./LICENSE).
