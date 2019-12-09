# Previsão do Tempo!

### Será que vai chover?

Esse aplicativo possui um back-end em .NET Core 3.1 Web Api e o front-end em Angular 8.

---

### Para rodar o projeto

1. Verifique se possui o .NET Core 3.1 SDK instalado, outras versões podem causar erros na compilação, é recomendado atualizar;
    - Para verificar se possui o .net core instalado utilize o comando ```dotnet --version```

2. Verifique se possui o NodeJS instalado;
    - Para verificar se possui o node instalado (e consequentemente o NPM) utilize o ```comando npm -v```

3. Para rodar a API acesse a pasta do projeto WebApi (PrevisaoDoTempo\API.PrevisaoDoTempo.WebApi), abra um terminal (cmd) e execute o comando: ```dotnet run``` (a base de dados será criada em tempo de execução);

4. Para rodar o site acesse a pasta do projeto Visual (PrevisaoDoTempo\Visual-PrevisaoDoTempo), abra um terminal (cmd) e execute os seguintes comandos em sequência:
    - ```npm install``` (instala as dependências, inclusive o AngularCLI);
    - ```npm start``` (ou ```ng serve``` caso já possua o AngularCLI instalado);

5. No navegador abra o link http://localhost:4200, a API usa por padrão http://localhost:5000.

---

### Estrutura do projeto

#### Back-end

Seguindo o DDD (Domain Driven Design) a estruturação de arquivos foi feita da seguinte forma:
    
- No root da aplicação constam os projetos de WebApi, Domain, Application e a pasta Infra que possui 2 projetos.

1. **Application**
    - A camada de aplicação (Service Layer Pattern) fornece um conjunto de serviços de aplicação responsáveis pela comunicação das requisições de clientes com as demais camadas (neste caso, as requisição são feitas através dos endpoints da API).

2. **Domain**
    - Camada onde residem os objetos de negócio.

3. **Infra:** é dividida em dois projetos:
    - **Data:** Realiza a persistência com o banco de dados, no nosso caso utilizando EF Core e SQLServer Local. Utilização do Repository Pattern para prover abstração do tratamento de dados.
    - **External:** uma camada que não obedece a hierarquia de camada. Responsável por consumir uma API externa (no caso OpenWeather).

##### Open WeatherAPI

Localizada no Infra.External está organizada na pasta OpenWeatherAPI. Possui uma classe abstrata que fornece o HttpClient e possui também uma classe de configuração com informações recuperadas no Startup através do arquivo de configuração (appsettings.json).

##### Banco de Dados

A API utiliza um banco de dados SQLServer Local alimentado por Migrations e inicializado ao rodar a aplicação, conta apenas com a tabela City.

---

#### Front-end

Aplicativo Angular 9 seguindo os padrões de desenvolvimento especificados nos [docs](https://angular.io/docs) da Angular.