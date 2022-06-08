# ChallengeDotnetAPI
## Implementaciones
* Implementación del patrón Repository
* Uso de DTOs para limitar los atributos que se envían por la API y desacoplar la capa de servicio de la de datos
* Uso de la librería AutoMapper para facilitar la conversión Modelo<>DTO
* Se crea una clase como extensión de ModelState para retornar mensajes del resultado de la validación de los datos del request http

## Oportunidades de mejora
* Separar las capas de la aplicación en diferentes proyectos
* Implementar el patrón UnitOfWork para manejar las transacciones a la base de datos de manera centralizada
* Implementación de clases Response, que incluyan el objeto de respuesta así como el resultado de le operación 
