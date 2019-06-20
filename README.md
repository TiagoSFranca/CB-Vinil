# Cashback Vinil

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
dotnet test /p:CollectCoverage=true /p:Exclude="[xunit.*]*" 
```
## Desenvolvido com

* [.NET Core 2.2](https://docs.microsoft.com/pt-br/aspnet/core/?view=aspnetcore-2.2)
* [Clean Architecture](https://docs.microsoft.com/pt-br/dotnet/standard/modern-web-apps-azure-architecture/common-web-application-architectures)
* [EF Core](https://docs.microsoft.com/pt-br/ef/core/) - Acesso a dados
* [LINQ](https://docs.microsoft.com/pt-br/dotnet/csharp/linq/) - Consulta de dados
* [CQRS](https://docs.microsoft.com/pt-br/dotnet/standard/microservices-architecture/microservice-ddd-cqrs-patterns/apply-simplified-microservice-cqrs-ddd-patterns)  - Segregação de Responsabilidades de consulta e escrita de dados
* [Mediatr](https://github.com/jbogard/MediatR/wiki) - Plugin para aplicar o pattern [Mediator](https://sourcemaking.com/design_patterns/mediator)
* [XUnit](https://xunit.net/docs/getting-started/netcore/cmdline) - Framework de testes