
![This is an image](https://www.alkemy.org/static/media/alkemyLogo.2daef856.svg)
# CHALLENGE BACKEND - C# .NET (API) 馃殌

## Objetivo
Desarrollar una API para explorar el mundo de Disney, la cual permitir谩 conocer y modificar los personajes que lo componen y entender en qu茅 pel铆culas estos participaron. Por otro lado, deber谩 exponer la informaci贸n para que cualquier frontend pueda consumirla.

- 馃憠 Utilizar .NET Core.
- 馃憠 No es necesario armar el Frontend.
- 馃憠 Las rutas deber谩n seguir el patr贸n REST.
- 馃憠 Utilizar DataAnnotations para el manejo de Autenticaci贸n.
- 馃憠 Implementar el modelo CodeFirst para el modelado de datos

_
## Algunas notas sobre mi desarrollo
#### Buenas pr谩cticas que pude aplicar y me parece interesante destacar
* Implementaci贸n del patr贸n Repository
* Uso de DTOs para limitar los atributos que se env铆an por la API y desacoplar la capa de servicio de la de datos
* Uso de la librer铆a AutoMapper para facilitar la conversi贸n Modelo<>DTO
* Se crea una clase como extensi贸n de ModelState para retornar mensajes del resultado de la validaci贸n de los datos del request http

#### Oportunidades de mejora
* Separar las capas de la aplicaci贸n en diferentes proyectos
* Implementar el patr贸n UnitOfWork para manejar las transacciones a la base de datos de manera centralizada
* Implementaci贸n de clases Response, que incluyan el objeto de respuesta as铆 como el resultado de la operaci贸n de los m茅todos de cada repository
* Implementaci贸n de excepciones personalizadas
* Utilizar librer铆a para trabajar con logs, para guardar informaci贸n relevante para el diagn贸stico de errores, as铆 como para analizar eventos de seguridad
