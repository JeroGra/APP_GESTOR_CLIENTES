
# GestorClientes

App Web desarrollada para  Gestionar Clientes, Esta app está dividida en 3 partes interconectadas.

Tenemos un BACKEND a modo de API desarrollada en ASP.NET donde desarrollamos el Modelo y Controlador.

Por otra parte cuenta con La base de datos en Microsoft SQL Server de forma local, donde 
se utilizan Procedimientos Almacenados para generar las Queries que consumirá la API.

Y como última pieza tenemos un FRONTEND realizado en Angular, donde se desarrolló la 

Vista.


![GESTOR](https://github.com/JeroGra/APP_GESTOR_CLIENTES/assets/97103645/0d73b5b8-49f8-4846-a04d-ecb076ef1899)


## FAQ

#### ¿Que operaciones podemos realizar?

Las operaciones que podemos realizar son: 
- Iniciar sesión como Administrador.
- Iniciar sesión como Cliente.
- Como Administrador acceder a la información de Clientes
- Como Administrador Agregar, Modificar y Eliminar de forma Lógica Clientes.
- Como Administrador acceder a la información de Clientes "Eliminados".
- Como Cliente acceder a la información de nuestro perfil.



## Diagramas

Diagramas de Clases (UML):



Diagrama de Entidad Relacion de la Base de Datos (DER de Martin):




## Screenshots App Web



## Instalacion Comprimida

Descargue la rama (branch) master. En ella encontrar las 3 partes:

- API_GESTOR_CLIENTES (Una vez descargada puede hacerla correr en Visual Studio), verifique instalar los paquetes de NuGet necesarios y configurar la cadena de conexión a la base de datos.

- BASE DE DATOS (encontrará los comandos utilizados a modo de ejemplo y el script para importar la base de datos de la APP).

- Gestor_Clientes (Se encuentra el frontend realizado en angular), hay que instalar los módulos de Node, ya que estos se eliminaron para que la descarga sea más rápida.

### IMPORTANTE

Tener instalado Angular CLI versión 16.2.12. Para poder correr el proyecto, y Visual Studio Code.

### Instalar los node modules
```bash
  npm install
```

### Instalar la base de datos

Tener SQL Server Magnament Studio 19

Ejecutar el script GESTOR_CLIENTES_BD.sql

### Instalar y correr api

Tener VisualStudio 2022.

Instalar los NuGets : 




## Instalacion diferida

Podés descargar los archivos de las distintas branchs para tener las 3 partes por separado.
    
