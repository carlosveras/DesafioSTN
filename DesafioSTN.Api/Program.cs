using DesafioSTN.Infra.IoC;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddControllersWithViews()
    .AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);


builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "DesafioSTN.Api",
        Version = "v1",
        Contact = new OpenApiContact
        {
            Name = "Carlos Veras",
            Email = "carlos.veras@outlook.com",
            Url = new Uri("https://www.linkedin.com/in/carlosaveras/")
        }
    });

    var xmlFile = "DesafioSTN.Api.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

var app = builder.Build();

//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapControllers(); // Mapeia os controllers usando o roteamento padrão

//    endpoints.MapControllerRoute(
//        name: "default",
//        pattern: "api/{controller}/{action}/{id?}"
//    );
//});




if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
