using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

//Adiciona o serviço de Controller
builder.Services.AddControllers();

//Adiciona o serviço de Swagger
builder.Services.AddSwaggerGen(options =>
{
    //Adiciona informações sobre api no swagger
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1", //versão
        Title = "API Filmes Lucas",
        Description = "API para gerenciamento de filmes - introdução da sprint 2 - Backend API",
        //TermsOfService = new Uri("https://example.com/terms"),
        Contact = new OpenApiContact
        {
            Name = "Lucas Lacerda",
            Url = new Uri("https://github.com/lrlacerda")
        },
        //License = new OpenApiLicense
        //{
        //    Name = "Example License",
        //    Url = new Uri("https://example.com/license")
        //}
    });

    // Configure o Swagger para usar o arquivo XML gerado
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

var app = builder.Build();

//Começa a configuração do Swagger
//Habilita o middleware para atender ao documento JSON gerado e à interface do usuário do Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
});
//Finaliza a configuração do Swagger

//Adiciona mapeamento dos controllers
app.MapControllers();

app.UseHttpsRedirection();

app.Run();
