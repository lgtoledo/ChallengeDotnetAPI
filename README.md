
![This is an image](https://www.alkemy.org/static/media/alkemyLogo.2daef856.svg)
# CHALLENGE BACKEND - C# .NET (API) 🚀

## Objetivo
Desarrollar una API para explorar el mundo de Disney, la cual permitirá conocer y modificar los personajes que lo componen y entender en qué películas estos participaron. Por otro lado, deberá exponer la información para que cualquier frontend pueda consumirla.

- 👉 Utilizar .NET Core.
- 👉 No es necesario armar el Frontend.
- 👉 Las rutas deberán seguir el patrón REST.
- 👉 Utilizar DataAnnotations para el manejo de Autenticación.
- 👉 Implementar el modelo CodeFirst para el modelado de datos

_
## Algunas notas sobre mi desarrollo
#### Buenas prácticas que pude aplicar y me parece interesante destacar
* Implementación del patrón Repository
* Uso de DTOs para limitar los atributos que se envían por la API y desacoplar la capa de servicio de la de datos
* Uso de la librería AutoMapper para facilitar la conversión Modelo<>DTO
* Se crea una clase como extensión de ModelState para retornar mensajes del resultado de la validación de los datos del request http

#### Oportunidades de mejora
* Separar las capas de la aplicación en diferentes proyectos
* Implementar el patrón UnitOfWork para manejar las transacciones a la base de datos de manera centralizada
* Implementación de clases Response, que incluyan el objeto de respuesta así como el resultado de la operación de los métodos de cada repository
