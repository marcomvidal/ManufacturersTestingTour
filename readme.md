# Manufacturers Testing Tour

REST API para reconhecimento de implementação de testes multi-níveis.

## Ferramentas utilizadas
- .NET Core 3.1
- ASP.NET Core 3.1
- C# 8.0
- FluentAssertions 5.10.3
- Xunit 2.4.0
- Xbehave 2.4.1

## Componentes
A aplicação está divida é em três partes essenciais:
- `Api`: Aplicação de Web API estruturada em arquitetura com Models, Controllers e Services;
- `Domain`: Classes de domínio e infraestrutura compartilhadas;
- `Test`: Testes da Web API em diferentes níveis.

## Setup
1. Instale o .NET Core 3.1;
2. Instale as ferramentas do Entity Framework Core globalmente com o comando `dotnet tool install --global dotnet-ef`;
3. Gere o banco de dados e os dados de teste (seeds) emitindo `dotnet-ef database update`;
4. Restaure as dependências do NuGet instaladas em Cars.Api e Cars.Test com os comandos `dotnet restore` e `dotnet build`;

## Arquitetura de testes
A aplicação foi testada em três níveis:
- `Unidade`: chamada a métodos específicos aplicada em classes de domínio;
- `Integração`: testagem de classes que dependem de recursos externos em perspectiva de caixa branca. Uso de mocking para aceleração da execução;
- `Aceitação`: testagem da execução da aplicação em perspectiva de caixa preta. Uso de BDD com Xbehave para aceitação por profissionais não-técnicos.

## Execução
1. Entre no diretório de `Cars.Api` e execute a aplicação emitindo `dotnet run`;
2. A aplicação pode ser acessada em `http://localhost:5000` ou `https://localhost:5001`.

## Execução dos testes
Entre no diretório de `Cars.Test` e execute a bateria de testes com o comando `dotnet test`.

## Objetos de estudos
- Orientação a objetos
- Programação funcional
- TDD: Test-Driven Development
- BDD: Behavior-Driven Development
