//configuro los componentes esenciales de la api. primero, utilizo mongoclient para conectarme a una base de datos mongodb
//sando una cadena de conexi�n definida en el archivo appsettings.json. luego, inyecto esta base de datos en el contenedor
//de dependencias para que pueda ser utilizada en otras partes de la aplicaci�n. tambi�n habilito controladores
//y configuro swagger para generar la documentaci�n autom�tica de la api, lo cual es �til para la validaci�n y pruebas de los endpoints.
//finalmente, configuro el pipeline http, que define c�mo las solicitudes entrantes son manejadas.

using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

// Configurar MongoDB
var mongoClient = new MongoClient(builder.Configuration.GetConnectionString("MongoDbConnection"));
var database = mongoClient.GetDatabase("nombre_de_tu_base_de_datos");

// Inyectar la base de datos en los servicios de la aplicaci�n
builder.Services.AddSingleton(database);

// Agregar controladores
builder.Services.AddControllers();

// Configurar Swagger para la documentaci�n de la API
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configurar el pipeline de solicitudes HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
