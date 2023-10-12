# Microservicio de Ejemplo con .NET Core

Este es un microservicio de ejemplo desarrollado en .NET Core que utiliza varias bibliotecas populares para simplificar el desarrollo y la validación de APIs, así como el acceso a una base de datos PostgreSQL.

## Bibliotecas Utilizadas

### MediatR
MediatR es una biblioteca que implementa el patrón Mediator para gestionar las solicitudes y las respuestas de forma desacoplada. En este proyecto, MediatR se utiliza para separar las operaciones de la API de sus controladores y gestionar la lógica de negocio de manera modular.

### FluentValidation.AspNetCore
FluentValidation.AspNetCore es una biblioteca que permite realizar validaciones de modelos de manera sencilla y declarativa en ASP.NET Core. En este proyecto, se utiliza para validar las solicitudes de la API y garantizar que los datos enviados sean válidos antes de procesarlos.

### Entity Framework Core
Entity Framework Core es un ORM (Mapeador Objeto-Relacional) que facilita el acceso a bases de datos relacionales desde aplicaciones .NET Core. En este proyecto, se utiliza Entity Framework Core para interactuar con una base de datos PostgreSQL y administrar las entidades de datos.

### PostgreSQL
PostgreSQL es un sistema de gestión de bases de datos relacional de código abierto. En este proyecto, se utiliza PostgreSQL como motor de base de datos para almacenar y recuperar datos relacionados con las entidades de este microservicio.

## Configuración

Antes de ejecutar este microservicio, asegúrate de configurar correctamente las siguientes dependencias:

1. **Base de Datos PostgreSQL**: Asegúrate de tener un servidor PostgreSQL en ejecución y configura la cadena de conexión en `appsettings.json` para que coincida con tu entorno.

2. **Paquetes NuGet**: Ejecuta `dotnet restore` para restaurar todas las dependencias del proyecto, incluyendo MediatR, FluentValidation.AspNetCore y Entity Framework Core.

3. **Migraciones de la Base de Datos**: Utiliza las herramientas de Entity Framework Core CLI para crear y aplicar las migraciones de la base de datos. Ejemplo: `dotnet ef migrations add InitialMigration` y `dotnet ef database update`.

## Uso

Para ejecutar este microservicio, simplemente compílalo y ejecute la aplicación:

```bash
dotnet build
dotnet run
