<h2 align="center">SmartGym Project</h2>

___




<h3 align="center">
  <a href="#about">Sobre</a>&nbsp;|&nbsp;
  <a href="#reason">Motivo</a>&nbsp;|&nbsp;
  <a href="#requirements">Requisitos</a>&nbsp;|&nbsp;
  <a href="#technologies">Tecnologias</a>&nbsp;|&nbsp;
	<a href="#references">Referências</a>&nbsp;|&nbsp;
</h3>

___


<h2 id="about">🔎 Sobre</h2>

É um projeto que tem como objetivo demonstrar que é possível criar uma arquitetura mais simples do que outras, utilizando alguns conceitos como DDD (Design Driven Design).


Este projeto é uma gestão simples de Academia. A ideia principal é cadastrar students(alunos), personal trainers(treinadores pessoais) e training centers(academias). Onde um aluno está relacionado para um treinador pessoal, e um treinador pessoal ligado para uma academia.

<h2 id="reason">🎯 Motivo</h2>

O objetivo aqui é desenvolver um projeto, utilizando os conceitos de DDD (Design Driven Design Assim, praticar e comprovar minhas habilidades desenvolvidas durante o Bootcamp Decola Dev Avanade 2021, que foi proposta através da DigitalInnovationOne.

<h2 id="requirements">⚙ Requisitos</h2>

git clone ou baixar esse repositório, depois disso:

1. Precisa ter instalado Microsoft SQL Server Management Studio 18;
2. Pode utilizar a conexão que já está no SmartGym.API/appsettings.json ou
configurar uma;

3. 
```bash
dotnet clean
dotnet build
dotnet run
```
E utilizar uma ferramenta, como o Postman, para realizar requisições HTTP. 😊

Ou utilizar o swagger para fazer seus Testes 😊

<h3> SQL Server Migrations</h3>
Com o entity framework instalado globalmente:

  1. Abra seu terminal na pasta da solution;
  2. Execute o seguinte comando:
  ```bash
    dotnet ef migrations add FirstMigration -s .\SmartGym.API\ -p .\SmartGym.Infra.Data\

  ```
  3. Execute o seguinte comando: 
  ```bash
  dotnet ef database update -s .\SmartGym.API\ -p .\SmartGym.Infra.Data\
  ```

<h2 id="technologies">🚀 Tecnologias</h2>

O projeto foi desenvolvido em:

- ASP.NET NET 5.0 (com .NET 5.0)
- Entity Framework Core 5.0.1
- Flunt Validation 1.0.5
- Swagger UI 5.6.3
- SqlServer Database Connection
- .NET Core Native DI
- SpecFlow for BDD
- GitHub Actions

<h3> Arquitetura </h3>

- Layer architecture
- S.O.L.I.D. principles
- Clean Code
- Domain Validations
- Domain Notifications
- Domain Driven Design
- Repository Pattern
- Notification Pattern
- Mapper by Extension Methods
- Value Types
- BDD (Behavior Driven Development)


<h2 id="references">📚 Referências</h2>

https://github.com/alexalvess/aurora-api-project -> repositório passado na aula como referência de estudo;

https://alexalvess.medium.com/criando-uma-api-em-net-core-baseado-na-arquitetura-ddd-2c6a409c686 -> contribuiente do projeto Aurora

https://www.youtube.com/watch?v=rqKWMynFLNA ->  Relacionamentos no Entity Framework -> André Baltieri

https://www.eduardopires.net.br/2014/10/tutorial-asp-net-mvc-5-ddd-ef-automapper-ioc-dicas-e-truques/ -> Tutorial ASP NET MVC 5 + DDD + EF + AutoMapper + IoC + Dicas e Truques



https://docs.atlas.mongodb.com/

-----------------------------------------------
Links Uteis:

- postman - https://www.postman.com/downloads/
