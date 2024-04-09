
# GestorClientes

App Web desarrollada para  Gestionar Clientes, Esta app está dividida en 3 partes interconectadas.

Tenemos un BACKEND a modo de API desarrollada en ASP.NET donde desarrollamos el Modelo y Controlador.

Por otra parte cuenta con La base de datos en Microsoft SQL Server de forma local, donde 
se utilizan Procedimientos Almacenados para generar las Queries que consumirá la API.

Y como última pieza tenemos un FRONTEND realizado en Angular, donde se desarrolló la 

Vista.


![GESTOR](https://github.com/JeroGra/APP_GESTOR_CLIENTES/assets/97103645/0d73b5b8-49f8-4846-a04d-ecb076ef1899)


## FAQ ❔

#### ¿Que operaciones podemos realizar?

Las operaciones que podemos realizar son: 
- Iniciar sesión como Administrador.
- Iniciar sesión como Cliente.
- Como Administrador acceder a la información de Clientes
- Como Administrador Agregar, Modificar y Eliminar de forma Lógica Clientes.
- Como Administrador acceder a la información de Clientes "Eliminados".
- Como Cliente acceder a la información de nuestro perfil.



## Diagramas 📑

(Cambiar a modo claro para poder apreciarlos mejor)

Diagramas de Clases (UML):

![image](https://github.com/JeroGra/APP_GESTOR_CLIENTES/assets/97103645/82aa7360-43ba-4741-aa00-b47b489e917f)


Diagrama de Entidad Relacion de la Base de Datos (DER de Martin):

![image](https://github.com/JeroGra/APP_GESTOR_CLIENTES/assets/97103645/95817ed5-94ea-4e71-9338-a6cb572b0517)



## Screenshots App Web, Modos de uso y Aclaraciones ⚙️

Pagina Principal / LogIn:

![Captura de pantalla 2024-04-09 170250](https://github.com/JeroGra/APP_GESTOR_CLIENTES/assets/97103645/47463709-2f28-48ac-9e99-27b054af0c44)


Vision de Inicio de sesion de Adminitrador y Cliente:
(Ya hay Usuarios Hardcodeados para poder ingresar y realizar pruebas)

Administrador requiere MAIL y CLAVE :

![Captura de pantalla 2024-04-09 170305](https://github.com/JeroGra/APP_GESTOR_CLIENTES/assets/97103645/a5818eb6-f9bc-40e2-9c10-311ebff3dd4d)


Cliente requiere MAIL y DNI : 

![Captura de pantalla 2024-04-09 170312](https://github.com/JeroGra/APP_GESTOR_CLIENTES/assets/97103645/69c67e7a-e1a1-4349-891f-75a65a47e23d)


### Vista Administrador 

CRUD CLIENTE y LISTA DE CLIENTES : 

![Captura de pantalla 2024-04-09 170452](https://github.com/JeroGra/APP_GESTOR_CLIENTES/assets/97103645/0dfa1394-e90a-4078-9744-c02b2dd4cfa6)

Se accede al ingresar o tocando el icono correspondiente en la barra de herramientas superior. A la izquierda tenemos el formulario para rellenar 
con los datos de un cliente, cuál agregamos pulsando el botón verde.

A la derecha tenemos la lista de clientes, podemos hacer clic sobre uno para mostrar su información en el formulario, a su vez podemos modificar 
sus datos en el formulario (solo los que son posibles) y para realizar la modificación pulsamos el botón azul, para eliminar el cliente el rojo
y para quitar el cliente del form o des fijar el cliente apretamos el botón amarillo.

CLIENTES ELIMINADOS :

![Captura de pantalla 2024-04-09 170529](https://github.com/JeroGra/APP_GESTOR_CLIENTES/assets/97103645/d9056f0c-214f-4fbe-bd21-a99ec4281751)

Podemos fijar un cliente eliminado haciendo clic sobre el en la lista de la derecha, asi podremos ver su información.

### Vista Cliente

Perfil del cliente:
![Captura de pantalla 2024-04-09 170542](https://github.com/JeroGra/APP_GESTOR_CLIENTES/assets/97103645/cc9d45b7-de90-4262-b1f7-c5ca5944d680)


## Instalacion Comprimida 🛠️

Descargue la rama (branch) master. En ella encontrar las 3 partes:

- API_GESTOR_CLIENTES (Una vez descargada puede hacerla correr en Visual Studio), verifique instalar los paquetes de NuGet necesarios y configurar la cadena de conexión a la base de datos.

- BASE DE DATOS (encontrará los comandos utilizados a modo de ejemplo y el script para importar la base de datos de la APP).

- Gestor_Clientes (Se encuentra el frontend realizado en angular), hay que instalar los módulos de Node, ya que estos se eliminaron para que la descarga sea más rápida.

### IMPORTANTE ‼️

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

![Captura de pantalla 2024-04-09 175339](https://github.com/JeroGra/APP_GESTOR_CLIENTES/assets/97103645/828be4d5-573b-4921-bafe-0a13af32b84c)

Colocar la base de datos correctamente:

1- En el backend descargado ir al archivo appsettings.json y en ConnectionStrings , en sql colocar dentro del Data Source= su nombre de maquina.

![Captura de pantalla 2024-04-09 172457](https://github.com/JeroGra/APP_GESTOR_CLIENTES/assets/97103645/a8177c25-7348-4fa9-b577-21a9b7303f24)

El nombre de maquina es el nombre del servidor local donde correra la base de datos previamente instalada (ejecutar el script de la base de datos).

En esta imagen podemos apreciar cual es el Server Name en mi caso:

![Captura de pantalla 2024-04-09 170735](https://github.com/JeroGra/APP_GESTOR_CLIENTES/assets/97103645/cd438268-56a2-4d45-8923-9c2b1362cc41)

Asi que podes ejecutar tu SQL Server Magnamente Studio (SSMS) para poder ver tu nombre de servidor / maquina. Copialo y pegalo en donde previamente señale.



## Instalacion diferida

Podés descargar los archivos de las distintas branchs para tener las 3 partes por separado. Y seguir los pasos especificos de instalacion antes mencionados.
    
