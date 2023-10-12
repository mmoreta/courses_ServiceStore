# ServiceStore - Ejemplo de un Proyecto de Microservicios

Bienvenidos al proyecto **Service Store**, este es un ejemplo de una aplicación creada con microservicios.
Desarrollada en:
.NET Core 6.
PostgreSQL para la base de datos.
Docker para contenerización.
RabbitMQ para mensajería.
API Gateway para gestionar los microservicios.
Sendgrid para el envío de correos electrónicos.

## Desarrollado por: 
- **Nombre **: Miguel Moreta
- **E-mailo**: mmroeta@gmail.com

## Descripción del Proyecto

ServiceStore este proyecto es con la finalidad uso didactico y practico, es un ejemplo que demuestra cómo 
construir una aplicación de microservicios utilizando diversas tecnologías.
La aplicación se centra en la gestión de una tienda en línea y se divide en varios microservicios que trabajan
juntos para proporcionar una funcionalidad completa.

Estos microservicios incluyen:
- **Servicio de Catálogo de libros**: Gestiona la información de los libros.
- **Servicio de Autores**: Administra los autores de los libros.
- **Servicio de Carro de compra**: Maneja las compras.
- **API Gateway**: Actúa como un punto de entrada único para los microservicios.
- **Base de Datos PostgreSQL**: Almacena datos críticos.

## Tecnologías Utilizadas

- **.NET Core 6**: Plataforma de desarrollo.
- **PostgreSQL**: Base de datos relacional.
- **Docker**: Contenerización de aplicaciones.
- **RabbitMQ**: Sistema de mensajería.
- **API Gateway**: Puerta de enlace para los microservicios.
- **Sendgrid**: Envío de correos electrónicos.

## Configuración

Antes de ejecutar la aplicación, asegúrate de configurar las variables de entorno y ajustar la configuración de cada microservicio según tus necesidades.

## Instrucciones de Ejecución

1. Clona este repositorio: `git clone https://github.com/tu-usuario/examples_ServiceStore.git`
2. Configura las variables de entorno.
3. Inicia cada microservicio por separado.
4. Configura el API Gateway para enrutar las solicitudes a los microservicios correspondientes.

## Contribuciones

Si deseas contribuir a este proyecto, siéntete libre de hacerlo. Abriremos con gusto nuevas solicitudes de extracción.

## Licencia

Este proyecto se distribuye bajo la Licencia MIT. Consulta el archivo `LICENSE` para obtener más detalles.

¡Gracias por tu interés en ServiceStore!

