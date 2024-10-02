Program.cs
En Program.cs, configuro los componentes esenciales de la API. Primero, utilizo MongoClient para conectarme a una base de datos MongoDB usando una cadena de conexión definida en el archivo appsettings.json. Luego, inyecto esta base de datos en el contenedor de dependencias para que pueda ser utilizada en otras partes de la aplicación. También habilito controladores y configuro Swagger para generar la documentación automática de la API, lo cual es útil para la validación y pruebas de los endpoints. Finalmente, configuro el pipeline HTTP, que define cómo las solicitudes entrantes son manejadas.

appsettings.json
Este archivo es donde se definen las configuraciones clave de la aplicación. Especifico los niveles de logging para rastrear el comportamiento de la aplicación y configuro la cadena de conexión para MongoDB. Esto permite que la aplicación se conecte automáticamente a la base de datos cuando se despliega.

ClienteController.cs
El controlador ClienteController expone varios endpoints para manejar las solicitudes HTTP relacionadas con los clientes. Utilizo el patrón REST, donde defino métodos como ListarClientes, GuardarCliente y EliminarCliente para recuperar, guardar y eliminar clientes de la base de datos. Cada método interactúa con ClienteService para acceder a la base de datos.

ClienteService.cs
El servicio ClienteService encapsula la lógica de negocio para la interacción con MongoDB. Aquí es donde realmente se realizan las operaciones CRUD (crear, leer, eliminar). Utilizo una colección MongoDB llamada "Clientes" para almacenar los datos. Esta clase abstrae los detalles de cómo se manejan los datos, permitiendo que el controlador simplemente la llame sin preocuparse por los detalles de la base de datos.

Cliente.cs
Este es el modelo que representa los datos de un cliente. En MongoDB, cada cliente es un documento, y esta clase define la estructura de ese documento. Utilizo atributos como BsonId para mapear el campo Id como un identificador en MongoDB y otros atributos como BsonElement para definir los nombres de los campos en la base de datos. Esto permite que la aplicación maneje los datos de manera coherente.
