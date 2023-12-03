# FrameworkPA-MVC-master
### Este documento fornece instruções detalhadas para o uso do Framework MVC de Cadastro/CRUD. O framework foi desenvolvido seguindo o padrão de projeto Model-View-Controller (MVC) e utiliza o banco de dados MySQL para armazenar os dados.
---
# Estrutura do Framework
## Classes Abstratas
**MeuPaiAbstratoController:** Controller abstrato que contém métodos obrigatórios para operações CRUD relacionadas à entidade Pai.

_Métodos obrigatórios:_
* Create: Método para exibir o formulário de criação de um novo Pai.
* Delete: Método para excluir um Pai específico.
* Details: Método para exibir detalhes de um Pai específico.
* Edit: Método para editar as informações de um Pai específico.
* Filhos: Método para exibir os descendentes (Filhos) de um Pai específico.
* Index: Método para exibir a lista de todos os Pais.
* MostrarFormularioDeBuscaPai: Método para exibir o formulário de busca de Pais.

***MeuFilhoAbstratoController:*** Controller abstrato que contém métodos obrigatórios para operações CRUD relacionadas à entidade Filho.

_Métodos obrigatórios:_
* Create: Método para exibir o formulário de criação de um novo Filho.
* Delete: Método para excluir um Filho específico.
* Details: Método para exibir detalhes de um Filho específico.
* Edit: Método para editar as informações de um Filho específico.
* Index: Método para exibir a lista de todos os Filhos.
* MostrarFormularioDeBuscaPaiFilho: Método para exibir o formulário de busca de Filhos.

## Controllers Concretos

Na pasta de Controllers crie as suas implementações concretas de métodos para herdar das classes abstratas.
  
**HomeController:** Controller utilizado para a inicialização e navegação inicial.

## Models

Na pasta de Models crie suas implementações concretas de dados e acesso.

**ErrorViewModel:** Tem a finalidade de fornecer um modelo estruturado para representar informações de erro que podem ser exibidas ao usuário.

__Propriedades da Classe:__

__RequestId:__
* Tipo: string? (pode ser nula)
* Descrição: Representa um identificador único associado à solicitação que resultou em um erro. Esse identificador pode ser usado para rastrear e depurar problemas específicos.

__ShowRequestId:__
* Tipo: bool
* Descrição: Propriedade de leitura que indica se o identificador de solicitação (RequestId) é válido e deve ser exibido. Retorna true se houver um RequestId não nulo, indicando que há informações disponíveis para mostrar.

__Utilização:__
Durante o tratamento de erros em controladores ou serviços, uma instância de ErrorViewModel pode ser criada e populada com informações relevantes sobre o erro. Essa instância pode então ser passada para uma view, onde as informações podem ser apresentadas ao usuário de maneira amigável.
Exemplo de utilização em um controlador:
~~~~csharp
public IActionResult SomeAction()
{
    try
    {
        // Lógica que pode gerar um erro
        // ...

        return View();
    }
    catch (Exception ex)
    {
        // Criar um ErrorViewModel com informações do erro
        var errorModel = new ErrorViewModel
        {
            RequestId = Guid.NewGuid().ToString(), // Pode ser um identificador único gerado dinamicamente
        };

        // Log do erro (opcional)
        Logger.LogError(ex, "Ocorreu um erro durante a execução de SomeAction.");

        // Passar o modelo de erro para a view de erro
        return View("Error", errorModel);
    }
}
~~~~
__View Padrão de Erro:__ No exemplo acima, a view "Error" seria uma página especializada para exibir mensagens amigáveis ao usuário com base nas informações contidas no ErrorViewModel. Essa view pode ser personalizada conforme necessário para atender aos requisitos específicos do aplicativo.
---
# Configuração do Banco de Dados
O framework utiliza o banco de dados MySQL. Certifique-se de configurar a string de conexão no arquivo appsettings.json conforme necessário. Exemplo:
~~~~jason
{
  "ConnectionStrings": {
    "SuaConexao": "Server=localhost;Database=SeuBancoDeDados;User=SeuUsuario;Password=SuaSenha;"
  }
}
~~~~
**Lembre-se de nomear as tabelas no banco de dados de acordo com o nome criado no código.**

Configuração do ASP.NET Core MVC para utilizar o Entity Framework Core e conectar-se a um banco de dados MySQL.**

__Classe Program__
* Aqui, um novo aplicativo web é construído usando o padrão do ASP.NET Core:
~~~~csharp
var builder = WebApplication.CreateBuilder(args);
~~~~
* Nesta parte, você está configurando o serviço de contexto do Entity Framework Core (FrameorkWAContext). Isso inclui a definição da conexão com o banco de dados MySQL.
* Certifique-se de que essa chave e a string de conexão correspondente estejam corretas no arquivo de configuração.
~~~~csharp
builder.Services.AddDbContext<FrameorkWAContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("SuaConexao") ?? throw new InvalidOperationException("Connection string 'SuaConexao' not found.");
    options.UseMySql(connectionString, new MySqlServerVersion(new Version(6, 0, 0)));
});
~~~~
* Adicionando os serviços necessários para o MVC, incluindo controladores e visualizações.
~~~~csharp
builder.Services.AddControllersWithViews();
~~~~
* O aplicativo é construído
~~~~csharp
var app = builder.Build();
~~~~
* Nesta parte, configurações de segurança estão sendo aplicadas. Em ambiente de desenvolvimento, as exceções são tratadas pela página de erro padrão. Em produção, o aplicativo usa uma página de erro específica (/Home/Error) em caso de exceções.
~~~~csharp
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
~~~~
* Essas linhas configuram diferentes aspectos do pipeline de solicitação, incluindo redirecionamento HTTPS, servir arquivos estáticos, roteamento, e autorização.
~~~~csharp
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
~~~~
* Aqui, uma rota padrão para controladores MVC é configurada. Isso significa que, por padrão, o controlador Home e a ação Index serão executados quando nenhum controlador ou ação específicos forem especificados na URL.
~~~~csharp
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
~~~~
* Execução
~~~~csharp
app.Run();
~~~~
---
# Uso do Framework
**Migrações:**

Antes de iniciar, execute as migrações para criar o esquema do banco de dados. Além de criar suas tabelas no banco.
~~~~bash
dotnet ef migrations add InitialCreate
dotnet ef database update
~~~~
## Controllers e Views:

* Utilize os controllers para realizar operações CRUD.
* As views estão conectadas às ações dos controllers e facilitam a interação com o usuário.

**Herança e Extensão:**

Ao criar novas entidades com operações CRUD semelhantes, herde das classes abstratas correspondentes para reutilizar lógica.

**Inicialização:**

Utilize o HomeController para configurações iniciais e navegação inicial.

**Exemplo de Models**

_PaisController_

_FilhosController_

---
## Considerações Finais
Este framework fornece uma estrutura organizada e reutilizável para operações CRUD em entidades relacionadas. Certifique-se de seguir as instruções de configuração do banco de dados e utilize as classes abstratas para criar novas funcionalidades com facilidade.
