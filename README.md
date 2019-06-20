# Cashback Vinil
[![Build Status](https://travis-ci.org/TiagoSFranca/CB-Vinil.svg?branch=master)](https://travis-ci.org/TiagoSFranca/CB-Vinil)

Cashback Vinil (CBVinil) é uma API  desenvolvida em .NET Core 2.2 para possibilitar a venda de Discos de Vinil com cashback para o comprador.

## Requisitos
* [.NET Core 2.2 (SDK, Runtime & Hosting)](https://dotnet.microsoft.com/download/dotnet-core/2.2)
* [MS SQL Server](https://www.microsoft.com/pt-br/sql-server/sql-server-downloads)

## Instalação

Para instalar basta baixar ou clonar o projeto.

```
git clone https://github.com/TiagoSFranca/CB-Vinil.git
```

## Utilização
É necessário que esteja instalado o [MS SQL Server](https://www.microsoft.com/pt-br/sql-server/sql-server-downloads), pois a aplicação utiliza migrações para criação e preenchimento da base de dados, cuja a string de conexão está em:
```
"CB Vinil"/CBVinil.API/appsettings.json
"CBVinilConnection" no ramo "ConnectionStrings"
```
### Configurando a conexão com o banco
Por padrão, a conexão com o banco está apontando para a base de dados local

```
"Server=localhost;Database=CBVinil;Trusted_Connection=True;Application Name=CBVinil;"
```

Caso seja necessário, alterar os dados da conexão de acordo

```
"Server=XXXXX;Database=XXXXX;User Id=XXXXX;Password=XXXXX;"
Server= [DNS ou IP do servidor de banco de dados]
Database= [Nome da base de dados]
User Id= [Login]
Password= [Senha]
```
Caso o banco não possua autenticação, a conexão não deve ter User Id e Password

```
"Server=XXXXX;Database=XXXXX;"
Server= [DNS ou IP do servidor de banco de dados]
Database= [Nome da base de dados]
```

### Inicializando o projeto
Após o download, siga os passos abaixo
```
cd "CB Vinil"
dotnet run --project CBVinil.API/CBVinil.API.csproj
```

Acesse o navegador na rota
```
https://localhost:5001/swagger
```
## Executando os testes

Para executar os testes, acesse a raiz do repositório e siga os passos abaixo:

```
cd "CB Vinil"
dotnet test /p:CollectCoverage=true /p:Exclude="[xunit.*]*%2C[CBVinil.Persistence]*%2C[CBVinil.Infrastructure]*"
```

Os projetos abaixo foram remidos da coberturna por não serem testáveis
```
CBVinil.Persistence
CBVinil.Infrastructure
```

## Desenvolvido com

* [.NET Core 2.2](https://docs.microsoft.com/pt-br/aspnet/core/?view=aspnetcore-2.2)
* [Clean Architecture](https://docs.microsoft.com/pt-br/dotnet/standard/modern-web-apps-azure-architecture/common-web-application-architectures)
* [EF Core](https://docs.microsoft.com/pt-br/ef/core/) - Acesso a dados
* [LINQ](https://docs.microsoft.com/pt-br/dotnet/csharp/linq/) - Consulta de dados
* [CQRS](https://docs.microsoft.com/pt-br/dotnet/standard/microservices-architecture/microservice-ddd-cqrs-patterns/apply-simplified-microservice-cqrs-ddd-patterns)  - Segregação de Responsabilidades de consulta e escrita de dados
* [Mediatr](https://github.com/jbogard/MediatR/wiki) - Plugin para aplicar o pattern [Mediator](https://sourcemaking.com/design_patterns/mediator)
* [XUnit](https://xunit.net/docs/getting-started/netcore/cmdline) - Framework de testes